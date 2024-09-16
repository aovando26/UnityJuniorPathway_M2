using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    
    private Vector3 startPos;

    // Variable to store half of the BoxCollider size
    private float repeatWidth;

    void Start()
    {
        // assigning start position 
        startPos = transform.position;

        // retrieving the box collider size and dividing by 2 
        repeatWidth = GetComponent<BoxCollider>().size.x / 2.0f;
    }

    void Update()
    {
        // once the offset (at x - axis) is at the point of repeatWidth 
        // assign the start position to the current position 
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}