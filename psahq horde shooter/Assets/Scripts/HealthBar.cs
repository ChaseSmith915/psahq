using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] private Transform owner;
    [SerializeField] private Vector3 shift;

    public void setHealth(float cur_hp, float maxHP)
    {
        this.healthBar.value = cur_hp / maxHP;
        //This method is public because the enemies will have an Object
        //reference to the HealthBar class. This cannot be static because
        //non-static fields are being used in this method.
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
        //This is so that the health bar basically NEVER rotates.

        transform.position = this.owner.position + this.shift;
        //This basically sets the XY position of the health bar to
        //the owner of the health bar. The shift is just how far
        //away you want the health bar from the owner.
    }
}
