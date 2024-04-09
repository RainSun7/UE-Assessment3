using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public Transform target; 
    public float smoothSpeed = 0.125f;
    public Vector3 offset; 
    public float minHeight = 2f; 

    void LateUpdate()
    {
        if (target != null)
        {
        
            Vector3 desiredPosition = target.position - target.forward * offset.magnitude;
        
            desiredPosition.y += offset.y;

            desiredPosition.y = Mathf.Max(desiredPosition.y, minHeight);

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(target.position);
        }
    }
}