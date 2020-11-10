using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

//class contains all the needed data and components of Enemy objects
public class EnemyBehaviour : MonoBehaviour
{
<<<<<<< HEAD
    //enemy health
    public int health;
    //animator component to control animations
    protected Animator animate;
    //collider component to control hitbox
    protected Collider2D _collider;
    //audio source component
    public AudioSource sound;

    private void Awake()
    {
        health = 2;
        animate = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();
        sound = GetComponent<AudioSource>();
    }
=======
    [System.Serializable]
    public class EnemyStats
    {
        public int health = 10;
        public float speed = 1.0f;
        public int atk_damage = 1;
    }

    public EnemyStats stats = new EnemyStats();
    //animator component to control animations
    [HideInInspector]
    public Animator animate;
    //Rigidbody component to control movement
    [HideInInspector]
    public Rigidbody2D rb;
    //audio source array to store enemy sounds
    public AudioSource[] sound;
    //bool for if enemy is attacking somethinh
    public static bool isAttacking = false;
    //bool for is the enemy is moving or not
    public static bool isMoving = true;
    //collider component as feet to prevent falling through ground
    //allows other colliders to work as triggers so player can pass through them
    public Collider2D feet;
    private void Awake()
    {
        animate = GetComponent<Animator>();
        //_collider = GetComponent<Collider2D>();
        sound = GetComponents<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    //method to decrement the amount of health 
    //destroys enemy when health is zero
    protected virtual void takeDamage(int damage)
    {
        //decrement our max health by damage amount
        stats.health -= damage;
        if(stats.health <= 0)
        {
            //play death animation and sound
            animate.Play("Death");
            //call killenemy to destroy this
            GameManager.KillEnemy(this);
        }
    }


>>>>>>> main
}
