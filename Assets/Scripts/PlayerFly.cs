using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFly : MonoBehaviour
{
    public float wingStrength;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(0)||Input.GetKeyDown(KeyCode.Space))
        { 
            rb.velocity = Vector2.up * wingStrength;
        
        }
    }
}
