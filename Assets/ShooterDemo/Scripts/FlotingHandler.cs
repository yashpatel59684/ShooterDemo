using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlotingHandler : MonoBehaviour
{
    private Vector3 originalPosition;
    float randomVal;
    [SerializeField] float speed = 1f,amplitude = 0.1f, angle = 45f;
    [SerializeField] bool randomInAmplitude;
    [SerializeField] Vector3 axis = Vector3.right;
    void Start()
    {
        originalPosition = transform.position;
        randomVal = randomInAmplitude ? Random.Range(.1f, 1) : 1;
    }
    void Update()
    {
        Vector3 newPosition = originalPosition;
        newPosition.y += Mathf.Sin(Time.time * speed) * (amplitude * randomVal);
        transform.position = newPosition;

        float currentAngle = Mathf.Sin(Time.time * speed) * angle;
        transform.RotateAround(originalPosition, axis, currentAngle);
    }

    // The angle of the rotation in degrees
    /* void FixedUpdate()
     {
         if (rotateX)
         {
             x += Time.deltaTime * speed;

             if (x > rangeOfRotation)
             {
                 x = 0.0f;
                 rotateX = false;
             }
         }
         else
         {
             z += Time.deltaTime * speed;

             if (z > rangeOfRotation)
             {
                 z = 0.0f;
                 rotateX = true;
             }
         }

         transform.localRotation = Quaternion.Euler(x, 0, z);
     }*/
}