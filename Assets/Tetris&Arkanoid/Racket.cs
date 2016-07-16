using UnityEngine;
using System.Collections;

public class Racket : MonoBehaviour {


    private float speed = 40;

 

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        
        GetComponent<Rigidbody2D>().velocity = Vector2.right * h *speed;

    }
}
