using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log(collision.name);
        if (collision.gameObject.name == "Hero")
        {
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
            GameManager.gm.StartCoroutine(GameManager.gm.RespawnPlayer(collision.gameObject));
        }
    }
}
