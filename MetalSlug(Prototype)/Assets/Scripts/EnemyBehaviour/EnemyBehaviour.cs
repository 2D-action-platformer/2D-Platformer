using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

//class contains all the needed data and components of Enemy objects
public class EnemyBehaviour : MonoBehaviour
{
    //enemy health
    public int health;
    //animator component to control animations
    protected Animator animate;
    //collider component to control hitbox
    protected Collider2D _collider;
    //audio source component
    public AudioSource sound;

    private void Awake()
    {
        health = 2;
        animate = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();
        sound = GetComponent<AudioSource>();
    }
}
