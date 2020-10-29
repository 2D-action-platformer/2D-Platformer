using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlatformPatrol : EnemyBehaviour
{
    public float speed;
    private float distance = 1.0f;
    private bool movingRight = true;
    private RaycastHit2D hit;
    public Transform groundDetection;
    // Update is called once per frame
    void Update()
    {
        patrol();
    }
    void patrol()
    {
        animate.SetBool("isGrounded", true);
        animate.SetBool("isMoving", true);

        if (animate.GetBool("isMoving") == true)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            animate.Play("walk");
        }

        hit = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (hit.collider == null)
        {
            //Debug.Log(hit.collider);
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
            //Debug.Log(hit.collider.name);
    }
}

