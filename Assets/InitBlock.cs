using UnityEngine;
using System.Collections;

public class InitBlock : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Destroy(gameObject);
    }
}
