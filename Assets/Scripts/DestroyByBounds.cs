﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBounds : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Enemy") 
        {
        Destroy(other.gameObject);
        }
    }
}
