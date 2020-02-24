using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public Enemy boss; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerShot")
        {
            Debug.Log ("hit Weakspot");
        boss.Damage();
        Destroy (other.gameObject);
        }
    }
}
