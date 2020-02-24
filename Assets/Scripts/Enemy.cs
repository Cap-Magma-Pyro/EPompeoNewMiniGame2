using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector2 direction;
    public GameObject shot;
    public GameObject bigShot;
    public Transform shotSpawn;
    public Transform shotStart;
    public Transform bigShotSpawn;
    
    public float bigShotDelay;
    public float shotDelay;
    public float speed;

    public float damageCount = 0;

    public int bossAggro = 0;

    bool canFire = true;

    Rigidbody2D rb;
    public BoxCollider2D playArea;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction.x *= Mathf.Sign(Random.Range(-direction.x, direction.x));
        rb.velocity = direction * speed;
        speed = 1;

        playArea = GameObject.Find("PlayArea").GetComponent<BoxCollider2D>();

        StartCoroutine(Shoot());

        StartCoroutine(BigShoot());
        BossPhase();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.position.x > playArea.bounds.max.x && rb.velocity.x > 0)
        {
            direction.x = -Mathf.Abs(direction.x);
            rb.velocity = direction * speed;
        }
        else if (rb.position.x < playArea.bounds.min.x && rb.velocity.x < 0)
        {
            direction.x = Mathf.Abs(direction.x);
            rb.velocity = direction * speed;
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

    IEnumerator BigShoot()
    {
        while(true)
        {
            Instantiate(bigShot, bigShotSpawn.position, bigShotSpawn.rotation);
            yield return new WaitForSeconds(bigShotDelay);
        }
    }

    public void Damage()
    {
        damageCount++;
        Debug.Log ("Damage");

        if (damageCount > 3)
        {
            damageCount = 0;
            bossAggro++;
        }
        BossPhase();
    }

    void BossPhase()
    {
        switch (bossAggro)
        {
            case 0:

                break;
            case 1:
                shotDelay = 0.8f;
                speed = 2; 
                break;
            case 2:
                shotDelay = 0.7f;
                speed = 3;

                break;
            case 3:
                shotDelay = 0.6f;
                speed = 3;
                bigShotDelay = 0.5f;

                break;
            case 4:
                shotDelay = 0.5f;
                speed = 3;
                bigShotDelay = 0.2f;

                break;
            case 5:
                shotDelay = 0.4f;
                speed = 3;
                bigShotDelay = 0.1f;

                break;
        }
    }
}
