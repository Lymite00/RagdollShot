using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    
    [SerializeField] private bool canMove;
    [SerializeField] private bool canRotate;
 

    public float maxValue;
    public Transform objectTransform;
    
    //1, -14
    void Update()
    {
        Debug.Log(transform.position.z);
        MoveCannon();
        RotateCannon();
        Debug.Log(objectTransform.localRotation.z);
    }
    private void RotateCannon()
    {
        if (canRotate && Input.GetKey(KeyCode.W))
        {
            if (objectTransform.localRotation.z >-0.15f)
            {
                Quaternion newRotation = Quaternion.Euler(0f, 0f, -rotationSpeed * Time.deltaTime);
                objectTransform.rotation *= newRotation;
            }
        } 
        if (canRotate && Input.GetKey(KeyCode.S))
        {
            if (objectTransform.localRotation.z <0.1f)
            {
                Quaternion newRotation = Quaternion.Euler(0f, 0f, rotationSpeed * Time.deltaTime);
                objectTransform.rotation *= newRotation;
            }
        }
    }
    private void MoveCannon()
    {
        if (canMove && Input.GetKey(KeyCode.A))
        {
            if (objectTransform.position.z<=maxValue)
            {
                objectTransform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
        }
        else if (canMove && Input.GetKey(KeyCode.D))
        {
            if (objectTransform.position.z >=-maxValue)
            {
                objectTransform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

            }
        }
    }
}