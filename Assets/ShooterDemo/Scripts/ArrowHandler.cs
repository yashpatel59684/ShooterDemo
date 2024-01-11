using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHandler : MonoBehaviour
{
    [SerializeField] Transform bloodTransform,arrowPointerTransform;
    Transform enemyTransform;
    private void Start()
    {
        enemyTransform = GameObject.FindGameObjectWithTag("Enemy").transform;
    }
    public void ChangeParent()
    {
        transform.SetParent(enemyTransform);
    }
    public void GenerateBlood()
    {
        Instantiate(bloodTransform, arrowPointerTransform);
    }
}
