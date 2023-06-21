using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveGroup : MonoBehaviour
{
    [SerializeField] private List<int> noobQueueList = new List<int>();
    private Queue<int> NoobQueue = new Queue<int>();
    [SerializeField] private float startTimer;
    [SerializeField] private float sendInterval;
    [SerializeField] private GameObject[] noobPrefabs;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform spawner;

    private void Start()
    {
        foreach(var item in noobQueueList) //you can't serialize a queue so I make a list and transfer its contents to a queue.
        {
            NoobQueue.Enqueue(item);
        }
    }

    public IEnumerator sendGroup()
    {
        yield return new WaitForSeconds(startTimer);
        while (NoobQueue.Count > 0)
        {
            yield return new WaitForSeconds(sendInterval);
            spawner.eulerAngles = new Vector3(0, 0, UnityEngine.Random.Range(0, 360));
            spawnNoob(NoobQueue.First());
            NoobQueue.Dequeue();
        }
    }
    public void spawnNoob(int index)
    {
        PhotonNetwork.InstantiateRoomObject(noobPrefabs[index].name, spawnPoint.position, Quaternion.identity);
    }
}
