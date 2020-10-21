using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
public class Tiling : MonoBehaviour
{
    //offset to determine if paralex scrolling should happen
    //two bools to check if the camera has background elements of to the side
    public int offsetX = 2;
    public bool hasARightBuddy = false;
    public bool hasALeftBuddy = false;
    //used if object is not tileable
    public bool reverseScale = false;
    //the width of our element
    private float spriteWidth = 0f;
    private Camera cam;
    private Transform mytransform;

    private void Awake()
    {
        cam = Camera.main;
        mytransform = transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sRender = GetComponent<SpriteRenderer>();
        spriteWidth = sRender.sprite.bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        //does the camera need buddies
        if(hasALeftBuddy == false || hasARightBuddy == false)
        {
            //calculate the distance from center of camera to edge of screen (World coordinates)
            float camHorizontalExtent = cam.orthographicSize * Screen.width / Screen.height;

            //calculate the x position where camera can see edge of sprite
            float edgeVisibleRight = (mytransform.position.x + spriteWidth / 2) - camHorizontalExtent;
            float edgeVisibleLeft = (mytransform.position.x - spriteWidth / 2) - camHorizontalExtent;

        }
    }
}
