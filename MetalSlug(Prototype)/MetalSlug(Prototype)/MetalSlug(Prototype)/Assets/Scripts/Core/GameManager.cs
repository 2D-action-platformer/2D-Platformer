using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used to manage frequently used functions such as spawning and destroying objects
public class GameManager : MonoBehaviour
{
    //create partial singleton to prevent multiple instances
    public static GameManager gm;
    private void Start()
    {
        if (gm == null)
            gm = FindObjectOfType<GameManager>();
    }

    public GameObject playerPrefab;
    public PlayerHealth health;
    public Transform spawnPoint;
    public float spawnDelay = 1.5f;
    public GameObject currentCheckpoint;
    public IEnumerator RespawnPlayer(GameObject player)
    {
        //Debug.Log("Add spawn sound and animation");
        yield return new WaitForSeconds(spawnDelay);
        

        //Debug.Log(playerPrefab.name);
        player.transform.position = currentCheckpoint.transform.position;
        player.SetActive(true);
        health = player.GetComponent<PlayerHealth>();
        health.enabled = true;
        health.CurrentHealth = health.MaxHealth;
        Debug.Log("add effects");
    }

    //methods to kill player and enemy 
    public IEnumerator KillEnemy(EnemyBehaviour enemy)
    {
        Debug.Log(enemy.animate.GetCurrentAnimatorStateInfo(0).length);
        yield return new WaitForSeconds(enemy.animate.GetCurrentAnimatorStateInfo(0).length);
        enemy.gameObject.SetActive(false);
    }
    
    public static void KillPlayer(GameObject player)
    {
        player.SetActive(false);
       // gm.RespawnPlayer(player);
    }

    public IEnumerator WaitForSpawn(GameObject player)
    {
        yield return new WaitForSeconds(spawnDelay);
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
