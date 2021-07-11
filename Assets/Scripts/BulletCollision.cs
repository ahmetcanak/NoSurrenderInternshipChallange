﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("bullet"))
        {
            Destroy(gameObject);
        }
    }
}
