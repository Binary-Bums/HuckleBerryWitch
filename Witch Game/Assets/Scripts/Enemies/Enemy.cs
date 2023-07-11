using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected GameObject player;
    public float speed = 1f;
    public float health = 1f;
    public float damage = 30f;
    public float range = .5f;
    public float hitCooldown = 1f;
    protected float nextAttackTime = 0;


    public void TakeDamage(float damage){
        health -= damage;

        if (health <= 0) Defeated();
    }

    protected void Defeated(){
        Destroy(gameObject);
    }
    protected void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) > range) NeutralMovement();

        else DetectPlayer();
    }
    
    protected virtual void NeutralMovement(){}

    protected virtual void DetectPlayer(){}
}

