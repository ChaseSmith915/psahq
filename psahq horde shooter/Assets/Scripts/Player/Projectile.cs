using Photon.Pun;
using System;
using UnityEngine;

public class Projectiles : MonoBehaviourPun
{
    public event Action<string, GameObject> OnProjectileHit;
    [SerializeField] private float projectileLifetime;


    // Update is called once per frame
    void Update()
    {
        projectileLifetime -= Time.deltaTime;
        if (projectileLifetime < 0)
        {
            GetComponent<PhotonView>().RPC("destroyProjectile", RpcTarget.All);
        }
    }

    private void destroyProjectileRPC()
    {
        //photonView.RPC("destroyProjectile", RpcTarget.All);
    }

    [PunRPC]
    private void destroyProjectile()
    {

        Destroy(this.gameObject);
    }


}
