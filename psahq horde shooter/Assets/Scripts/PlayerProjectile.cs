using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Camera cam;
    [SerializeField] private float damage = 2f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        //This just makes it that the Game Object is not visible.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void click()
    {
        Vector3 relative = this.cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;
        this.rb.rotation = angle;
        relative.Normalize();

        Vector3 mouseXY = this.player.position;
        transform.position = mouseXY;
        this.gameObject.SetActive(true);
    }
}
