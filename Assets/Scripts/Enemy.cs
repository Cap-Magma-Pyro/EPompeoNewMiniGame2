﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector2 direction;
    public GameObject shot;
    public Transform shotSpawn;
    public Transform shotStart;
    public float shotDelay;

    bool canFire = true;

    Rigidbody2D rb;
    public BoxCollider2D playArea;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction.x = Random.Range(-direction.x, direction.x);
        rb.velocity = direction;

        playArea = GameObject.Find("PlayArea").GetComponent<BoxCollider2D>();

        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.position.x > playArea.bounds.max.x && rb.velocity.x > 0)
        {
            direction.x = -Mathf.Abs(direction.x);
            rb.velocity = direction;
        }
        else if (rb.position.x < playArea.bounds.min.x && rb.velocity.x < 0)
        {
            direction.x = Mathf.Abs(direction.x);
            rb.velocity = direction;
        }

    }
    
    IEnumerator Shoot()
    {
        while (true)
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            Instantiate(shot, shotStart.position, shotStart.rotation);
            yield return new WaitForSeconds(shotDelay);
        }
    }
}