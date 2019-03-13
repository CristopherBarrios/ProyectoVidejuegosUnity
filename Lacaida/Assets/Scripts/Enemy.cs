using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{


    public int health;
    public GameObject deathEffect;
    public GameObject explosion;
    public float movespeed = 1f;
    Transform LeftWayPoint, RightWayPoint;
    Vector3 localScale;
    bool movingRight = true;
    Rigidbody2D rb;
    

    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        LeftWayPoint = GameObject.Find("LeftWayPoint").GetComponent<Transform>();
        RightWayPoint = GameObject.Find("RightWayPoint").GetComponent<Transform>();
    }


    void Update()
    {
        if (transform.position.x > RightWayPoint.position.x)
            movingRight = false;
        if (transform.position.x < LeftWayPoint.position.x)
            movingRight = true;

        if (movingRight)
            moveRight();
        else
            moveLeft();
    
        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {

        Instantiate(explosion, transform.position, Quaternion.identity);
        health -= damage;
    }
    
    void moveRight()
    {
        movingRight = true;
        localScale.x = 6;
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x * movespeed, rb.velocity.y);
    }
    void moveLeft()
    {
        movingRight = false;
        localScale.x = -6;
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x * movespeed, rb.velocity.y);
    }
}