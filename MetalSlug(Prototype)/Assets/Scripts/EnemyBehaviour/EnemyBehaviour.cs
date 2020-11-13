using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

//class contains all the needed data and components of Enemy objects
public class EnemyBehaviour : MonoBehaviour
{
    [System.Serializable]
    public class EnemyStats
    {
        public int health;
        public float speed;
        public int atk_damage;
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
    public bool isAttacking = false;
    //bool for is the enemy is moving or not
    public bool isMoving = true;
    private void Awake()
    {
        animate = this.gameObject.GetComponent<Animator>();
        sound = this.gameObject.GetComponents<AudioSource>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
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
}
