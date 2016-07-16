using UnityEngine;
using System.Collections;

public class hold : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(12, 5, 0);
    }

    void Update()
    {
        if (active1.del)
        {
            Debug.Log("5");
            Destroy(transform.gameObject);
            active1.del = false;
        }
    }
}
