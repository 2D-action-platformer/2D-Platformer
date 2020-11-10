using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
<<<<<<< HEAD
        if(collision.name == "Hero")
        {
=======
        Debug.Log(collision.name);
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log(collision.gameObject.tag);
>>>>>>> main
            gm.currentCheckpoint = gameObject;
        }
    }
}
