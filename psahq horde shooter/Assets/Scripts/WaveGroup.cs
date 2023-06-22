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
}
