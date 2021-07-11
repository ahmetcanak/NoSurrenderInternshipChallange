using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishCollision : MonoBehaviour
{
    PlayerController playerContrl;
    void Start()
    {
        playerContrl = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            playerContrl.kill();
        }
    }
}
