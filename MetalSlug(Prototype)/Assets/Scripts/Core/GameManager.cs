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
    public Transform spawnPoint;
    public float spawnDelay = 1.5f;
    public GameObject currentCheckpoint;
    public IEnumerator RespawnPlayer(GameObject player)
    {
        Debug.Log("Add spawn sound and animation");
        yield return new WaitForSeconds(spawnDelay);

        Debug.Log(playerPrefab.name);
        //Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        player.transform.position = currentCheckpoint.transform.position;
        player.SetActive(true);
        Debug.Log("add effects");
    }

    //methods to kill player and enemy 
    public static void KillEnemy(EnemyBehaviour enemy)
    {
        Destroy(enemy.gameObject);
    }
    
    public static void KillPlayer(GameObject player)
    {
        player.SetActive(false);
        gm.RespawnPlayer(player);
    }
}
