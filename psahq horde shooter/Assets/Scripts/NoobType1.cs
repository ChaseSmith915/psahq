using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoobType1 : Noob
{
    // Start is called before the first frame update
    void Start()
    {
        this.rigB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
