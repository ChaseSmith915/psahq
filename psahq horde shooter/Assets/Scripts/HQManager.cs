using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class HQManager : MonoBehaviour, IPunObservable
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Collider2D col;
    [SerializeField] private int maxHealth;
    [SerializeField] private PhotonView pv;
    private int health;
    void Start()
    {
        healthBar.setHealth(maxHealth, maxHealth);
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(pv.IsMine))
        {
            return;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PhotonNetwork.Destroy(collision.gameObject);
            health -= 1;
            healthBar.setHealth(health, maxHealth);
        }
        if(health  <= 0) 
        {
            pv.RPC("gameLoseRPC", RpcTarget.All);
        }
    }

    #region IPunObservable implementation
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(this.health);
        }
        else
        {
            health = (int)stream.ReceiveNext();
            if (healthBar == null)
            {
                return;
            }
            this.healthBar.setHealth(this.health, this.maxHealth);
        }
    }

    #endregion

    [PunRPC]
    private void gameLoseRPC()
    {
        Application.Quit();
    }
}
