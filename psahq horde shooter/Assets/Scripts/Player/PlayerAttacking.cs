using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerAttacking : MonoBehaviour
{
    [SerializeField] private PhotonView photonView;
    [SerializeField] private KeyCode shootButton;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileCooldown;
    private float timer;

    protected void Update()
    {
        timer -= Time.deltaTime;
    }
    void FixedUpdate()
    {
        playerAttack();
    }

    private void playerAttack()
    {
        if (Input.GetKey(shootButton))
        {
            rossAttack();
        }
    }

    private void rossAttack()
    {
        if (timer <= 0)
        {
            timer = projectileCooldown;
            GameObject projectile = PhotonNetwork.Instantiate(projectilePrefab.name, this.gameObject.transform.position, Quaternion.identity);
        }
    }
}
