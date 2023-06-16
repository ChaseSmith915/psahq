using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Transform owner;

    [SerializeField] private Vector3 shift;
    //shift is how much you want to move the healthBar from the owner.
    //E.g. if the shift is just 0, then the health bar would just be in the middle of the owner.

    public void setHealth(float cur_hp, float maxHP)
    {
        this.healthBar.value = cur_hp / maxHP;
        //This method is public because the other scripts will have an Object
        //reference to the HealthBar class.
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
        //where the owner of the health bar is. The shift is just how far
        //away you want the health bar from the owner.
    }
}
