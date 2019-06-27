using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    Rigidbody rb;
    public float speed = -5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(speed, rb.velocity.y, 0);
    }

    void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        if (rb)
        {
            Gizmos.DrawLine(transform.position, transform.position + rb.velocity);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<movement>())
        {
            other.GetComponent<movement>().transform.position = other.GetComponent<movement>().respawn;
        }
    }
}
