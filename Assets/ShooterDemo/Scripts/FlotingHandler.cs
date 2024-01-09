using UnityEngine;

public class FlotingHandler : MonoBehaviour
{
    private Vector3 originalPosition;
    float randomVal;
    [Range(0,10)]
    [SerializeField] float speed = 1f, amplitude = 0.1f;
    [Range(0, 90)]
    [Tooltip("Check true to doRotation for rotation")]
    [SerializeField] float  angle = 1f;
    [SerializeField] bool randomInAmplitude,doRotation;
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
        if (doRotation)
        { 
            float currentAngle = (Mathf.Sin(Time.time * speed))* angle;
            currentAngle = Mathf.Clamp(currentAngle, -angle, angle);
            Quaternion rot = Quaternion.AngleAxis(currentAngle, axis);
            transform.rotation = rot;
        }
    }
}