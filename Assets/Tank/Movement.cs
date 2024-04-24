using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody rb;
    
    private LookingAt isLookingAt;
    private bool isMoving;
    private enum LookingAt { FRONT, BACK, LEFT, RIGHT }

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void FixedUpdate()
    {
        MoveAndRotateBody();
    }

    void LateUpdate()
    {
        Debug.Log(isMoving);
        GetInput();
    }
    private void GetInput()
    {
        isMoving =
            Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        if (Input.GetKey(KeyCode.W))
        {
            isLookingAt = LookingAt.FRONT;
        }
        if (Input.GetKey(KeyCode.S))
        {
            isLookingAt = LookingAt.BACK;
        }
        if (Input.GetKey(KeyCode.D))
        {
            isLookingAt = LookingAt.RIGHT;
        }
        if (Input.GetKey(KeyCode.A))
        {
            isLookingAt = LookingAt.LEFT;
        }
    }
    void MoveAndRotateBody() 
    {
        if (!isMoving)
        {
            rb.velocity = Vector3.zero;
            return;
        }
        switch (isLookingAt) 
        {
            case LookingAt.FRONT:
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                rb.velocity = Vector3.forward * moveSpeed;
                break;
            case LookingAt.RIGHT:
                transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                rb.velocity = Vector3.right * moveSpeed;
                break;
            case LookingAt.BACK:
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                rb.velocity = Vector3.back * moveSpeed;
                break;
            case LookingAt.LEFT:
                transform.rotation = Quaternion.Euler(0f, 270f, 0f);
                rb.velocity = Vector3.left * moveSpeed;
                break;
        }
    }
}
