using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    //private Rigidbody bulletsRb;
    private GameObject moveDir;
    public bool isPowerUp = false;
    public bool isRadPowerUp = false;
    private float strength = 5.0f;
    public GameObject powerIndicator;
    public bool gameOver = false;
    public GameObject bullets;
    private Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        moveDir = GameObject.Find("Focal Point");
        //bullets.GetComponent<Rigidbody>();
        //bulletsRb = bullets.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float movementInput = Input.GetAxis("Vertical");
        playerRb.AddForce(moveDir.transform.forward * 5.0f * movementInput);
        powerIndicator.transform.position = transform.position;
        if(transform.position.y < -5) {
            gameOver = true;
        }

        /*if (isRadPowerUp)
        {
            
            StartCoroutine(RadiationPowerUpTimeRoutine());
        }*/

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            isPowerUp = true;
            powerIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerUpTimeRoutine());
        }
        if (other.CompareTag("RadiationPowerUp"))
        {
            Destroy(other.gameObject);
            isRadPowerUp = true;
            //powerIndicator.gameObject.SetActive(true);
            var enemiesInScene = GameObject.FindGameObjectsWithTag("Enemy");
            //Vector3 enemyPos = GameObject.Find("Enemy").transform.position -GameObject.Find("Player").transform.position;
            for (int i = 0; i < enemiesInScene.Length; i++)
            {
                Instantiate(bullets, this.transform.position, bullets.transform.rotation);
            }
            var bulletsCount = GameObject.FindGameObjectsWithTag("Bullets");
            for(int i = 0; i < bulletsCount.Length; i++)
            {
                if (bulletsCount.Length == enemiesInScene.Length)
                {
                    Rigidbody bulletsRB = bulletsCount[i].GetComponent<Rigidbody>();
                    bulletsRB.AddForce((enemiesInScene[i].transform.position - transform.position).normalized * 25.0f, ForceMode.Impulse);
                }
            }
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && isPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            enemyRb.AddForce((enemyRb.transform.position - transform.position) * strength, ForceMode.Impulse);
            Debug.Log("You can't escape me bitch");
        }
        if (collision.gameObject.CompareTag("Enemy") && isRadPowerUp)
        {/*
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            enemyRb.AddForce((enemyRb.transform.position - transform.position) * strength, ForceMode.Impulse);
            */
            //Debug.Log("Hyped");
        }
    }
    IEnumerator PowerUpTimeRoutine()
    {
        yield return new WaitForSeconds(5);
        isPowerUp = false;
        powerIndicator.gameObject.SetActive(false);
        bullets.gameObject.SetActive(false);
    }
    IEnumerator RadiationPowerUpTimeRoutine()
    {
        
        
        
        Debug.Log("Hyped");
        yield return new WaitForSeconds(0.5f);
        isRadPowerUp = false;
        powerIndicator.gameObject.SetActive(false);
        
    }

}
