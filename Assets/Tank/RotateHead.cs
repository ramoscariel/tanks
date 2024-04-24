using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHead : MonoBehaviour
{
    [SerializeField] private Transform head;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    void Update()
    {
        Rotate();
    }
    
    private void Rotate() 
    {
        if (head == null)
            return;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit)) 
        {
            head.LookAt(new Vector3(hit.point.x,head.position.y,hit.point.z));
        }
        
    }
}
