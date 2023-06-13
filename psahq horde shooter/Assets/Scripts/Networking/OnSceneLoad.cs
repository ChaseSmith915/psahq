using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OnGameStart : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab; //I wonder what horse ross thinks of this
    void Start()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, new Vector2(UnityEngine.Random.Range(-5f, 5f), transform.position.y), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
