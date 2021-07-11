using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject mainChar;
    public Object EnemyObject;
    public int xPos;
    public int zPos;
    public int enemyCount;
    public List<GameObject> EnemyList;

    void Update()
    {
        addEnemy();
    }

    void addEnemy()
    {
        while(enemyCount < 40)
        {
            xPos = Random.Range((int)Mathf.Round(mainChar.transform.position.x-15),(int)Mathf.Round(mainChar.transform.position.x+15));
            zPos = Random.Range((int)Mathf.Round(mainChar.transform.position.z+5), (int)Mathf.Round(mainChar.transform.position.z + 40));
            GameObject enem = (GameObject)Instantiate(enemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
            enemy.name = enemyCount.ToString();
            EnemyObject myEnemy = new EnemyObject(enem);
            EnemyList.Add(myEnemy.Enemy);
            enemyCount++;
        }
    }
    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
