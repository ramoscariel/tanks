using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 targetOffset;
    [SerializeField] private float moveSpeed;

    void Update()
    {
        MoveCamera();
    }

    void MoveCamera() 
    {
        transform.position = 
            Vector3.Lerp(transform.position,target.position+targetOffset,moveSpeed*Time.deltaTime);
    }
}
