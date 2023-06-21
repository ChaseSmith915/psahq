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
    private bool isKeyDown;
    IEnumerator Start()
    {
        Debug.Log("g");
        while(!(isKeyDown && (pv.IsMine)))
        {
            yield return null;
          
        }
        Debug.Log("p");
        OnGameStart?.Invoke();
        StartCoroutine("sendWaves");
        
    }

    private void Update()
    {
        isKeyDown = Input.GetKey(KeyCode.Space); //I need to do it like this because input will not be detected inside of a coroutine. I think. i tried
    }
    private IEnumerator sendWaves()
    {
        foreach(Wave wave in waves)
        {
            wave.sendWave();
            Debug.Log("new wave sent");
            yield return new WaitForSeconds(wave.WaveDuration);
        }
        yield return new WaitForSeconds(100);
        Debug.Log("win");
        OnGameWin?.Invoke();
    }
}
