using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHandler : MonoBehaviour
{
    [SerializeField] Transform bloodTransform,arrowPointerTransform;
    private void Start(){}
    public void ChangeParent(Collision collision)
    {
        transform.SetParent(collision.transform);
    }
    public void GenerateBlood()
    {
        Instantiate(bloodTransform, arrowPointerTransform);
    }
}
