using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public GameObject nisan;
    public GameObject proj;
    public GameObject nearestObj;
    public float force;
    EnemyManager em;
    AimController aim;
    public List<GameObject> myList;

    public float fireRate;
    private float nextFire = 0.0f;

    private void Start()
    {
        aim = FindObjectOfType<AimController>();
        em = FindObjectOfType<EnemyManager>();
        myList = em.EnemyList;

    }

    void Update()
	{
        if (Input.GetMouseButton(0) && aim.canShoot && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate; //atış hızı

            GameObject nisangah = Instantiate(proj, nisan.transform.position, Quaternion.identity) as GameObject; // mermi oluşuturuluyor.

            Rigidbody nisangahrb = nisangah.GetComponent<Rigidbody>();
            nisangahrb.AddForce(transform.forward * force); //mermiye hız kazandırılıyor

            Destroy(nisangah, 3.0f); // 3 saniye sonra mermi yok ediliyor.
        }
	}

    public GameObject getNearest() //Seçili objeler arasından, karaktere en yakın olan objeyi buluyor. Objeler başka class'daki list içerisinden çekiliyor.
    {
        
        nearestObj = null;

        foreach (GameObject enemy in myList)
        {
            if(Vector3.Distance(transform.position, enemy.transform.position) <= 250)
            {
                if(nearestObj == null)
                {
                    nearestObj = enemy;
                }
                else if(Vector3.Distance(transform.position, enemy.transform.position)< Vector3.Distance(transform.position, nearestObj.transform.position))
                {
                    nearestObj = enemy;
                }
                
            }
        }
        return nearestObj;
    }


}
