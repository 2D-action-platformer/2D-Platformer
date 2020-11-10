using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

<<<<<<< HEAD
public class PlatformPatrol : EnemyBehaviour
{
=======
public class PlatformPatrol : MonoBehaviour
{
    EnemyBehaviour.EnemyStats _stats = new EnemyBehaviour.EnemyStats();
    private Animator animate;
    private Rigidbody2D rb;
>>>>>>> main
    public float speed;
    private float distance = 1.0f;
    private bool movingRight = true;
    private RaycastHit2D hit;
    public Transform groundDetection;
<<<<<<< HEAD
=======
    bool isMoving;

    public void Start()
    {
        speed = _stats.speed;
        animate = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
       // Debug.Log(animate.name);
        isMoving = EnemyBehaviour.isMoving;
    }
>>>>>>> main
    // Update is called once per frame
    void Update()
    {
        patrol();
    }
    void patrol()
    {
<<<<<<< HEAD
        animate.SetBool("isGrounded", true);
        animate.SetBool("isMoving", true);

        if (animate.GetBool("isMoving") == true)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            animate.Play("walk");
        }
=======
        isMoving = animate.GetBool("isMoving");
        if (isMoving == true)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            //animate.Play("walk");
        }
        else
            stopPatrol(isMoving);
>>>>>>> main

        hit = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (hit.collider == null)
        {
<<<<<<< HEAD
            //Debug.Log(hit.collider);
=======
           // Debug.Log(hit.collider);
>>>>>>> main
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
<<<<<<< HEAD
=======

    void stopPatrol(bool not_moving)
    {
        if(not_moving)
        {
            rb.velocity = Vector2.zero;
            animate.SetBool("isMoving", false);
        }
    }
>>>>>>> main
}

