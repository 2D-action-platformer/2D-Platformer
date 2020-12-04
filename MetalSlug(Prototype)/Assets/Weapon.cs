using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Transform player;
    public Animator animator;

    private bool isShooting = false;

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isShooting", isShooting);
        if(Input.GetKey("space")){
            Shoot();
            isShooting = true; 
        }
        else isShooting = false;

        bool playerRight = player.transform.rotation.eulerAngles.y < 180;
       
        if( Input.GetKey("t") && Input.GetKey("h") && playerRight){
            firePoint.transform.rotation = Quaternion.identity;
            firePoint.transform.Rotate (Vector3.forward * 45);
        } else  if( Input.GetKey("t") && Input.GetKey("f") && !playerRight){
            firePoint.transform.rotation = Quaternion.identity;
            firePoint.transform.Rotate (Vector3.forward * 135);
        } else if(Input.GetKey("t")){
            firePoint.transform.rotation = Quaternion.identity;
            firePoint.transform.Rotate (Vector3.forward * 90);  
        } else if(Input.GetKey("g") && Input.GetKey("h") && playerRight){
            firePoint.transform.rotation = Quaternion.identity;
            firePoint.transform.Rotate (Vector3.forward * -45);  
        } else if(Input.GetKey("g") && Input.GetKey("f") && !playerRight){
            firePoint.transform.rotation = Quaternion.identity;
            firePoint.transform.Rotate (Vector3.forward * -135);  
        }  else if(Input.GetKey("g")){
            firePoint.transform.rotation = Quaternion.identity;
            firePoint.transform.Rotate (Vector3.forward * -90);  
        }  else {
            if(playerRight){
                firePoint.transform.rotation = Quaternion.identity;
            }else {
                firePoint.transform.rotation = Quaternion.identity;
                firePoint.transform.Rotate (Vector3.forward * 180);
            }
        }
        
    }

    void Shoot(){
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
