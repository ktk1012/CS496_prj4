using UnityEngine;
using System.Collections;

public class Racket : MonoBehaviour {


    private float speed = 15;

 

    void FixedUpdate()
    {
//        float h = Input.GetAxisRaw("Horizontal");
		Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();

		if (Input.GetKey (KeyCode.RightArrow)) {
			rigidBody.velocity = new Vector2 (speed, 0);
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			rigidBody.velocity = new Vector2 (-1 * speed, 0);
		} else {
			rigidBody.velocity = new Vector2 (0, 0);
		}

    }
}
