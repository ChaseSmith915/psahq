using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UIElements;

public class PlayerProjectile : MonoBehaviour
{
    public float cooldown = 0.5f, cur_cooldown = 0f, speed = 8f;
    public GameObject projectile;
    public Camera cam;
    public Animator animator;
    [SerializeField] private RossSounds rossSounds;

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (this.cur_cooldown > 0)
        {
            cur_cooldown -= Time.deltaTime;
        }
        else
        {
            animator.SetBool("firing", false);
        }

        if (Input.GetMouseButton(0) && this.cur_cooldown <= 0)
        {
            this.fire();
            this.cur_cooldown = this.cooldown;

            animator.SetBool("firing", true);
        }
    }

    public virtual void fire()
    {
        rossSounds.playShootSound();
        GameObject shot = PhotonNetwork.Instantiate(this.projectile.name, transform.position, transform.rotation);
        Rigidbody2D hitbox = shot.GetComponent<Rigidbody2D>();
        Vector2 relative = (this.cam.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        float angle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg - 90f;
        shot.transform.rotation = Quaternion.Euler(0,0,angle);
        hitbox.AddForce(relative.normalized * speed, ForceMode2D.Impulse);
    }
}
