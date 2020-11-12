using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerController playerController;
    public float MaxHealth = 10f;
    public float CurrentHealth = 10f;
    private BoxCollider2D bc2d;
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
            playerController.enabled = false;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            CurrentHealth = CurrentHealth - 1;
        }
    }
}
