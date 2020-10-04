using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    float speed = 10f;
    private Rigidbody2D rigidbody2D;
    float jumpVelocity = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"),
           Input.GetAxis("Vertical"), 0);

        transform.position += move
            * speed * Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            rigidbody2D.velocity = Vector2.up * jumpVelocity;
        }

    }
}
