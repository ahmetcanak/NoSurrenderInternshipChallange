using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody player;
    private Rigidbody rb;
    public float moveSpeed = 1.0f;
    EnemyManager em;
    PlayerController playerContrl;
    public UnityEngine.UI.Text text;

    public void Start()
    {
        em = FindObjectOfType<EnemyManager>();
        playerContrl = FindObjectOfType<PlayerController>();
        rb = this.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        text = GameObject.Find("Canvas/Text").GetComponent<UnityEngine.UI.Text>();
        text.text = em.EnemyList.Count.ToString();
    }

    void FixedUpdate()
    {
        Vector3 dir = player.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation,5f*Time.deltaTime);
        dir.Normalize();
        moveCharacter(dir);
    }
    private void Update()
    {
    }
    void moveCharacter(Vector3 dir)
    {
        rb.MovePosition((Vector3)transform.position + (dir * moveSpeed * Time.deltaTime));
        
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerContrl.kill();
        }
        else if (collision.gameObject.tag.Equals("bullet"))
        {
            em.EnemyList.Remove(gameObject);
            Destroy(gameObject);
            text.text = em.EnemyList.Count.ToString();
        }
        
    }

}
