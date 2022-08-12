using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;
    public float followSpeed = 5;
    private Vector3 offset;

    void Start()
    {
        offset = followTarget.position - transform.position;

    }
   
    private void LateUpdate()
    {
        if(followTarget)
        {
            transform.position = followTarget.position - offset;
        }
    }
}