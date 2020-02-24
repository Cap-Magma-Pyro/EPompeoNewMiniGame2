using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed;
    public BoxCollider2D playArea;
    public GameObject shot;
    public Transform shotSpawn;
    public float shotDelay;
    bool canFire = true;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(moveH, moveV);
        rb.velocity = move * speed;

        float clampX = Mathf.Clamp(rb.position.x, playArea.bounds.min.x, playArea.bounds.max.x);
        float clampY = Mathf.Clamp(rb.position.y, playArea.bounds.min.y, playArea.bounds.max.y);
        rb.position = new Vector2(clampX, clampY);

        // if (Input.GetButtonDown("Jump"))
        // {
        //     Shoot();
        // }

        if (Input.GetButton("Jump") && canFire)
        {
            Shoot();
            StartCoroutine(ShotCooldown());
        }
    }
    void Shoot()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

    }
    
    IEnumerator ShotCooldown()
    {
        canFire = false;
        yield return new WaitForSeconds(shotDelay);
        canFire = true;
    }
}
