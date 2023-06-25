using Photon.Pun;
using System;
using UnityEngine;

public class Projectiles : MonoBehaviourPun
{
    public event Action<string, GameObject> OnProjectileHit;
    [SerializeField] private float projectileLifetime, pierce, damage;
    private int id;


    // Update is called once per frame
    void Update()
    {
        this.projectileLifetime -= Time.deltaTime;
        if (projectileLifetime < 0 || this.pierce <= 0)
        {
            Destroy(this.gameObject);
            //GetComponent<PhotonView>().RPC("destroyProjectile", RpcTarget.All);
        }
    }

    public int getID()
    {
        return this.id;
    }

    public void setID(int num)
    {
        this.id = num;
    }

    private void destroyProjectileRPC()
    {
        //photonView.RPC("destroyProjectile", RpcTarget.All);
    }

    [PunRPC]
    private void destroyProjectile()
    {
        //PhotonNetwork.Destroy(this.gameObject);
    }

    // I am not still not a C# gamer. I still make getters and setters like a Java person.
    public float getDamage()
    {
        return this.damage;
    }

    public void setPierce(float pierce)
    {
        this.pierce = pierce;
    }

    public float getPierce()
    {
        return this.pierce;
    }

}
