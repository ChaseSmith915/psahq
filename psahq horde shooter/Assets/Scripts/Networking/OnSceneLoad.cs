using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OnGameStart : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab; //I wonder what horse ross thinks of this
    [SerializeField] private GameObject skengPrefab; //I wonder what Inversonia thinks of this
    void Start()
    {
        switch(GlobalVariables.Instance.characterChoice)
        {
            case "Ross":
                {
                    PhotonNetwork.Instantiate(playerPrefab.name, new Vector2(UnityEngine.Random.Range(-5f, 5f), transform.position.y), Quaternion.identity);
                }
                break;
            case "Skeng":
                {
                    PhotonNetwork.Instantiate(skengPrefab.name, new Vector2(UnityEngine.Random.Range(-5f, 5f), transform.position.y), Quaternion.identity);
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
