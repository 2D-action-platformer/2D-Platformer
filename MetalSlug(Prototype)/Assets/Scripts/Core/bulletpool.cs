using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletpool : MonoBehaviour
{
    public static bulletpool poolInstance;

    [SerializeField]
    private GameObject poolBullet;
    private bool notEnoughBullets = true;

    private List<GameObject> bullets;

    private void Awake()
    {
        poolInstance = this;
    }

    private void Start()
    {
        bullets = new List<GameObject>();
    }

    public GameObject GetBullet()
    {
        if(bullets.Count > 0)
        {
            for(int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                    return bullets[i];
            }
        }

        if(notEnoughBullets)
        {
            GameObject bul = Instantiate(poolBullet);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }
        return null;
    }
}
