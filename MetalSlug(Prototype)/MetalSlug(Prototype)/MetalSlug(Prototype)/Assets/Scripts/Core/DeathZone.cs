using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        Debug.Log(gameObject.activeSelf);
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("executes if statement");
            collision.gameObject.SetActive(false);
            Debug.Log(gameObject.activeSelf);
            GameManager.gm.StartCoroutine(GameManager.gm.RespawnPlayer(collision.gameObject));
        }
    }
}
