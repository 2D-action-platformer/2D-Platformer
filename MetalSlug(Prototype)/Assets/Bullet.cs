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
        Zombie  enemy = hitInfo.GetComponent<Zombie>();
        if(enemy == null){
            return;
        }
        enemy.damageEnemy(1);
        Destroy(gameObject);

    }
}
