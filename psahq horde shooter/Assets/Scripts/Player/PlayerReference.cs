using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReference : MonoBehaviour
{
    public static PlayerReference Instance;
    public GameObject myPlayer;
    public Camera playerCam;
    private GameObject[] players;

    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);

        this.players = GameObject.FindGameObjectsWithTag("player");
        int i = 0;

        foreach (GameObject player in this.players)
        {
            if (player.GetComponent<PhotonView>().IsMine == true)
            {
                myPlayer = player;
            }

            PlayerProjectile blast = player.GetComponent<PlayerProjectile>();
            if (blast)
            {
                blast.projectile.setID(i++);
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

    public GameObject getPlayer(int index)
    {
        return this.players[index];
    }

}
