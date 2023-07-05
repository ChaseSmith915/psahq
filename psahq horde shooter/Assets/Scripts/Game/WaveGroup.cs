using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGroup : MonoBehaviour 
{
    [SerializeField] private int groupSize;
    [SerializeField] private float startTimer;
    [SerializeField] private float sendInterval;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform spawner;
    private GameObject noobSpawner;

    private void Start()
    {
        noobSpawner = GameObject.Find("Noobspawner");
    }


    public IEnumerator sendGroup()
    {
        yield return new WaitForSeconds(startTimer);
        for(int i = 0; i < groupSize; i++)
        {
            yield return new WaitForSeconds(sendInterval);
            spawnNoob();
        }
    }
    public void spawnNoob()
    {
        spawner.eulerAngles = new Vector3(0, 0, UnityEngine.Random.Range(0, 360));
        PhotonNetwork.InstantiateRoomObject(prefab.name, spawnPoint.position, Quaternion.identity);
    }

    public void generateRandomWave()
    {
        groupSize = Mathf.RoundToInt(UnityEngine.Random.Range(10, 30) * noobSpawner.GetComponent<NoobSpawner>().enemyAmountIncreaseByWave);
        startTimer = UnityEngine.Random.Range(0, 4);
        sendInterval = Mathf.Pow(noobSpawner.GetComponent<NoobSpawner>().startInterval, noobSpawner.GetComponent<NoobSpawner>().intervalDecay);
    }
}
