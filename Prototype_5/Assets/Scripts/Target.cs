using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // rigidbody var 
    private Rigidbody targetRb;

    // boundary speed vars 
    private float minSpeed = 12;
    private float maxSpeed = 16;

    // torque limit vars
    private float torqueLimit = 1;

    // x,y coordinates
    private float xRange = 4; 
    private float yPos = 6;

    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explosionParticle; 

    // Start is called before the first frame update
    void Start()
    {

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); 

        // retrieve rigidbody component 
        targetRb = GetComponent<Rigidbody>();

        // add upward force, randomize
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        // add randomize rotation 
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        // we can remove z-axis
        transform.position = RandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        Destroy(gameObject);


        // we want good objects to fall below to cause game over
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private float RandomTorque()
    {
        return Random.Range(-torqueLimit, torqueLimit);
    }

    private Vector3 RandomPosition()
    { 
        return new Vector3(Random.Range(-xRange, xRange), -yPos);
    }
}