using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerController playerController;
    public float MaxHealth = 10f;
    public float CurrentHealth = 10f;
    private BoxCollider2D bc2d;
    //public int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        bc2d = GetComponent<BoxCollider2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentHealth == 0)
        {
            //playerController.enabled = false;
            StartCoroutine(Dead());
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            CurrentHealth = CurrentHealth - 1;
        }
    }

    IEnumerator Dead()
    {
        Debug.Log("DEAD");
        GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(3);
        Debug.Log("RESPAWN");
        GetComponent<Renderer>().enabled = true;
        CurrentHealth = 10f;
    }
}

