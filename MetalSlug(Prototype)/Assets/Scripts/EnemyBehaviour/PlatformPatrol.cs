using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlatformPatrol : MonoBehaviour
{
    EnemyBehaviour.EnemyStats _stats = new EnemyBehaviour.EnemyStats();
    private Animator animate;
    private Rigidbody2D rb;
    public float speed;
    private float distance = 1.0f;
    private bool movingRight = true;
    private RaycastHit2D hit;
    public Transform groundDetection;
    bool isMoving;

    public void Start()
    {
        speed = _stats.speed;
        animate = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
       // Debug.Log(animate.name);
        isMoving = EnemyBehaviour.isMoving;
    }
    // Update is called once per frame
    void Update()
    {
        patrol();
    }
    void patrol()
    {
        isMoving = animate.GetBool("isMoving");
        if (isMoving == true)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            //animate.Play("walk");
        }
        else
            stopPatrol(isMoving);

        hit = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (hit.collider == null)
        {
           // Debug.Log(hit.collider);
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

    void stopPatrol(bool not_moving)
    {
        if(not_moving)
        {
            rb.velocity = Vector2.zero;
            animate.SetBool("isMoving", false);
        }
    }
}

