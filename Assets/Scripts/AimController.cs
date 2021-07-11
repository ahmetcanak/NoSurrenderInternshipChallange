using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    public float rotateSpeed = 50f;
    public float maxAngle = -45f;
    public float maxAngleReset = -65f;
    private GameObject targetEnemy;

    public bool left = false;
    public bool right = false;
    public bool canShoot = false;

    private Quaternion lookAt;
    private Quaternion targetRotation;
    public Vector3 targetDir;

    ProjectileController projContrl;
    PlayerController playerContrl;

    void Start()
    {
        playerContrl = FindObjectOfType<PlayerController>();
        projContrl = FindObjectOfType<ProjectileController>();
    }

    void Update()
    {
        
        targetEnemy = projContrl.getNearest();
        if(targetEnemy != null){
            targetDir = targetEnemy.transform.position;
        }
        Vector3 direction = targetDir - transform.position;
                        
        if(targetEnemy != null && direction.magnitude < 21f){
            playerContrl.movSpeed = 0.045f;
            canShoot = true;
            targetRotation = Quaternion.LookRotation(direction);
            lookAt = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime*rotateSpeed);
            transform.rotation = lookAt;
        }
        else
        {
            playerContrl.movSpeed = 0.035f;
            canShoot = false;
            Quaternion targetRotation = Quaternion.Euler(0f,0f, 90f);
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, Time.deltaTime * rotateSpeed);
        }
    
    }

}
