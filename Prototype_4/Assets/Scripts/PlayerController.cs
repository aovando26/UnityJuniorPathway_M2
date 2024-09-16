using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody _rigidbody;
    private GameObject focalPoint;

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
    }
}