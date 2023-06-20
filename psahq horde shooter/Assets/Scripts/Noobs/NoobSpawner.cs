using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NoobSpawner : MonoBehaviour
{
    [SerializeField] private float maxTimer;
    [SerializeField] private GameObject[] noobPrefabs;
    [SerializeField] private Transform spawnPoint;
    private float timer;
    void Start()
    {
        timer = maxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;


        if(timer < 0 )
        {
            timer = maxTimer;
            float direction = Random.Range(0, 360);
            this.transform.eulerAngles = new Vector3 ( 0, 0, direction );

            int noobType = (int)Random.Range(0, this.noobPrefabs.Length);

            PhotonNetwork.InstantiateRoomObject(noobPrefabs[noobType].name, spawnPoint.position, Quaternion.identity);
        }
    }
}
