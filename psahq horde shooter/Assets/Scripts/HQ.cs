using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HQ : MonoBehaviour
{
    [SerializeField] private float hp;

    // Start is called before the first frame update
    void Start()
    {
        this.hp = 100f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void changeHP(float amount)
    {
        this.hp += amount;
        //This method can also be called for when the HQ takes damage.
        //It just needs a negative number in the argument.
    }
}
