using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody _rigidbody;
    private GameObject focalPoint;

    public GameObject powerUpIndicator;

    private bool hasPowerUp = false;
    private float powerUpStrength = 10.0f;

    // countdown timer
    //private float countdownTimer = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        _rigidbody.AddForce(focalPoint.transform.forward * verticalInput * speed);
        //transform.Translate(Vector3.right * verticalInput * speed * Time.deltaTime);
        powerUpIndicator.transform.position = transform.position + new Vector3 (0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickups"))
        {
            powerUpIndicator.gameObject.SetActive(true);
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerDown());
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            // get rigidbody 
            Rigidbody enemyRb = col.gameObject.GetComponent<Rigidbody>(); 
            
            // find difference 
            Vector3 awayFromPlayer = col.gameObject.transform.position - transform.position;

            // add force 
            enemyRb.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse); 
            Debug.Log("Collider with " + col.gameObject.name + "power up is " + hasPowerUp);

            //countdownTimer -= Time.deltaTime;

            //if (countdownTimer <= 0)
            //{
                
            //}
        }
    }

    IEnumerator PowerDown()
    {
        yield return new WaitForSeconds(5.0f);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }
}