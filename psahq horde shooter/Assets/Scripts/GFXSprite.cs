using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GFXSprite : MonoBehaviour
{
    //This script is for the sprites because they have a child object called GFX.
    //The GFX gameObject has a SpriteRenderer component and when you flip the X or Y from there,
    //it also flips the Noob sprite. Flipping the XY value in the SpriteRenderer Component belonging
    //to the Noob itself does not work for some reason and so this script works around it.

    private float angle;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        this.sprite = GetComponent<SpriteRenderer>();
    }

    public void setAngle(float angle)
    {
        this.angle = angle;
        if (this.angle >= -90 && this.angle <= 90)
        {
            this.sprite.flipX = false;
        } else
        {
            this.sprite.flipX = true;
        }
    }
}
