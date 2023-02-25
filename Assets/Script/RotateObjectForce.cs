using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class RotateObjectForce : MonoBehaviour
{
    public GameObject rotateObject;
    public float RotateSpeed;

    private bool _IsSpaceBarHeld;
    
    void Start()
    {
        RotateSpeed *= 100000;
    }

    // Update is called once per frame
    void Update()
    {
        _IsSpaceBarHeld = Input.GetKey(KeyCode.Space);

        /*
        if(Input.anyKeyDown == false)
            rb.AddRelativeTorque(0, 0, 0, ForceMode.Force);
            */

        Horizontal_control();
        vertical_control();
    }


    void Horizontal_control()
    {
        Rigidbody rb = rotateObject.GetComponent<Rigidbody>();

        if (_IsSpaceBarHeld)
        {
            if(Input.GetKey(KeyCode.LeftArrow))
                rb.AddRelativeTorque(0,-RotateSpeed * Time.deltaTime,0,ForceMode.Force);
            if(Input.GetKey(KeyCode.RightArrow))
                rb.AddRelativeTorque(0,RotateSpeed * Time.deltaTime,0,ForceMode.Force);
        }
        else
        {
            if(Input.GetKey(KeyCode.LeftArrow))
                rb.AddRelativeTorque(-RotateSpeed * Time.deltaTime,0,0,ForceMode.Force);
            if(Input.GetKey(KeyCode.RightArrow))
                rb.AddRelativeTorque(RotateSpeed * Time.deltaTime,0,0,ForceMode.Force);
        }
        
    }

    void vertical_control()
    {
        Rigidbody rb = rotateObject.GetComponent<Rigidbody>();
        
        if (Input.GetKey(KeyCode.UpArrow))
            rb.AddRelativeTorque(0,0,RotateSpeed * Time.deltaTime,ForceMode.Force);
        if (Input.GetKey(KeyCode.DownArrow))
            rb.AddRelativeTorque(0,0,-RotateSpeed * Time.deltaTime,ForceMode.Force);
    }
}
