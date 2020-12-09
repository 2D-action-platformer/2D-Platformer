using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : EnemyBehaviour
{
    /* public override void takeDamage(int damage)
     {
         //play hurt sound 
         //play animation if available
         //if the sound is playing don't play again till over otherwise play sound
         if(!sound[0].isPlaying)
             sound[0].Play();
         //call base.takeDamage to decrement health
         base.takeDamage(damage);
     }*/

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log(collision.name);
            isAttacking = true;
            isMoving = false;
            attackPlayer();
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        isAttacking = false;
        isMoving = true;
        attackPlayer();
    }

    private void attackPlayer()
    {
        if (isAttacking)
        {
            animate.SetBool("isAttacking", true);
            animate.SetBool("isMoving", false);
        }
        else
        {
            animate.SetBool("isAttacking", false);
            animate.SetBool("isMoving", true);
        }
    }

   
}
