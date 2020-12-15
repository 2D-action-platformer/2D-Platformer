using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        EnemyBehaviour  enemy = hitInfo.GetComponent<EnemyBehaviour>();
        Debug.Log(hitInfo);
        if(enemy == null){
            return;
        }
        enemy.takeDamage(1);
        Destroy(gameObject);
    }
}
