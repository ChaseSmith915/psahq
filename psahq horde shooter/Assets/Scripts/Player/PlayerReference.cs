using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReference : MonoBehaviour
{
    public static PlayerReference Instance;
    public GameObject myPlayer;
    public Camera playerCam;
    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);

        GameObject[] players = GameObject.FindGameObjectsWithTag("player");
        foreach (GameObject player in players)
        {
            if (player.GetComponent<PhotonView>().IsMine == true)
            {
                myPlayer = player;
            }
        }
        if(myPlayer != null)
        {
            playerCam = myPlayer.GetComponentsInChildren<Camera>()[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
