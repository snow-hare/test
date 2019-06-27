using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    int jumping;
    bool onGround = false;
    public float speed = 5;
    KeyCode up = KeyCode.UpArrow;
    KeyCode right = KeyCode.RightArrow;
    KeyCode left = KeyCode.LeftArrow;
    public Vector3 respawn;
    Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        respawn = transform.position;
        collider = GetComponent<Collider>();
    }

    public void Respawn()
    {
        transform.position = respawn;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newVel = new Vector2(0, GetComponent<Rigidbody>().velocity.y);

        if (Input.GetKey("a") || Input.GetKey(left))
        {
            // Left
            newVel.x = -speed;
        }
        if (Input.GetKey("d") || Input.GetKey(right))
        {
            // Right
            newVel.x = speed;
        }
        if ((Input.GetKey("w") || Input.GetKey(up)) && onGround)
        {
            // Up
            newVel.y = 8;
        }
        if (newVel.y < -15)
        {
            newVel.y = -15;
        }
        GetComponent<Rigidbody>().velocity = new Vector3(newVel.x, newVel.y, 0);
        if (transform.position.y < -50)
        {
            Respawn();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Physics.Raycast(transform.position, Vector3.down, transform.localScale.y / 2f + 0.1f) || Physics.Raycast(transform.position + Vector3.left * 0.5f * transform.localScale.x, Vector3.down, transform.localScale.y / 2f + 0.1f) || Physics.Raycast(transform.position + Vector3.right * 0.5f * transform.localScale.x, Vector3.down, transform.localScale.y / 2f + 0.1f))
        {
            onGround = true;
        }
        if (collision.transform.GetComponent<enemyScript>())
        {
            Respawn();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (!(Physics.Raycast(transform.position, Vector3.down, transform.localScale.y / 2f + 0.1f) || Physics.Raycast(transform.position + Vector3.left * 0.5f * transform.localScale.x, Vector3.down, transform.localScale.y / 2f + 0.1f) || Physics.Raycast(transform.position + Vector3.right * 0.5f * transform.localScale.x, Vector3.down, transform.localScale.y / 2f + 0.1f)))
        {
            onGround = false;
        }
    }
}
