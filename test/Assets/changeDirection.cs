using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeDirection : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<enemyScript>())
        {
            other.GetComponent<enemyScript>().speed *= -1;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, Vector3.one);
    }
}
