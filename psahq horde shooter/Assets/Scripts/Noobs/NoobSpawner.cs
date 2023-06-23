using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using System.Linq;

public class NoobSpawner : MonoBehaviour
{
    [SerializeField] private List<Wave> waves = new List<Wave>();
    [SerializeField] private float maxTimer;
    [SerializeField] private GameObject[] noobPrefabs;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private PhotonView pv;
    public int wave;
    public event Action OnGameStart;
    public event Action OnGameWin;
    public event Action OnWaveSent;
    private bool isKeyDown;
    public static NoobSpawner Instance;
    IEnumerator Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        Debug.Log("g");
        while(!(isKeyDown && (pv.IsMine)))
        {
            yield return null;
          
        }
        pv.RPC("startGameRPC", RpcTarget.All);
        yield return new WaitForEndOfFrame();
        StartCoroutine("sendWaves");
        
    }

    private void Update()
    {
        isKeyDown = Input.GetKeyDown(KeyCode.Space); //I need to do it like this because input will not be detected inside of a coroutine. I think. i tried
    }
    private IEnumerator sendWaves()
    {
        foreach(Wave wave in waves)
        {
            yield return new WaitForEndOfFrame();
            wave.sendWave();
            OnWaveSent?.Invoke();
            Debug.Log("new wave sent");
            while (!(isKeyDown && (pv.IsMine)))
            {
                yield return null;
            }
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(100);
        Debug.Log("win");
        pv.RPC("gameWinRPC", RpcTarget.All);
    }

    [PunRPC]
    private void startGameRPC()
    {
        OnGameStart?.Invoke();

    }
    [PunRPC]
    private void gameWinRPC()
    {
        OnGameWin?.Invoke();
    }
}
