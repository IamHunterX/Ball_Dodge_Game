using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 3.0f;
    private float runAwaySpeed = 10.0f;
    private GameObject player;
    private Rigidbody enemyRb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        //Debug.Log(lookDirection);
        enemyRb.AddForce(lookDirection * speed);
        if(transform.position.y < -2)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullets"))
        {
            Vector3 runAway = (transform.position - player.transform.position).normalized;
            enemyRb.AddForce(runAway * runAwaySpeed);
        }
    }
}
