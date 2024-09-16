using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private bool isOnGround = true;
    public float jumpForce = 10.0f;
    public bool gameOver = false;
    public float gravityModifier;
    private Animator playerAnim;

    // particle variables
    public ParticleSystem explosionParticleSystem;
    public ParticleSystem dirtParticleSystem;

    // audio variables
    public AudioClip crashAudio;
    public AudioClip jumpSound;
    private AudioSource audioSource; 

    private void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>(); 
        Physics.gravity *= gravityModifier;
        audioSource = GetComponent<AudioSource>();
        //ps = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        JumpAction();
    }

    private void JumpAction()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            isOnGround = false;
            dirtParticleSystem.Stop();
            audioSource.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticleSystem.Play();
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            Debug.Log("Game Over");
            //ParticleSystem myParticleSystem = GetComponent<ParticleSystem>();
            //var em = myParticleSystem.emission;
            //em.enabled = true;
            explosionParticleSystem.Play();
            dirtParticleSystem.Stop();
            audioSource.PlayOneShot(crashAudio, 1.0f);
        }
    }
}