using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private float damage = 2f, cooldown = 0.5f, cur_cooldown = 0f, speed = 8f;
    [SerializeField] GameObject projectile;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.gameObject.SetActive(true);
        //This just makes it that the Game Object is not visible.
    }

    // Update is called once per frame
    void Update()
    {
        
        if (this.cur_cooldown > 0)
        {
            cur_cooldown -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && this.cur_cooldown <= 0)
        {
            this.fire();
            this.cur_cooldown = this.cooldown;
        }
    }

    private void fire()
    {
        GameObject shot = PhotonNetwork.Instantiate(this.projectile.name, transform.position, transform.rotation);
        Rigidbody2D hitbox = shot.GetComponent<Rigidbody2D>();
        hitbox.AddForce(transform.up * this.speed, ForceMode2D.Impulse);
        //This creates a new projectile object and then moves it.
    }
}
