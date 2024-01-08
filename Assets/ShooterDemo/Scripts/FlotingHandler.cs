using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlotingHandler : MonoBehaviour
{
    /*    Vector3 initialPos;
        public float floatHeight;

        void Start()
        {
            initialPos = transform.position;
        }
        void Update()
        {
            if (transform.position == initialPos)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y+ floatHeight, transform.position.z), Time.deltaTime);
            }
            else if (transform.position.y == floatHeight)
            {
                transform.position = Vector3.MoveTowards(transform.position, initialPos, Time.deltaTime);
            }
        }*/
    // this makes the object float up and down 

    // The original position of the object
    private Vector3 originalPosition;

    // The speed of the floating movement
    public float speed = 1f;

    // The amplitude of the floating movement
    public float amplitude = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        // Store the original position of the object
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the new position of the object
        Vector3 newPosition = originalPosition;
        newPosition.y += Mathf.Sin(Time.time * speed) * amplitude;

        // Move the object to the new position
        transform.position = newPosition;
    }
}