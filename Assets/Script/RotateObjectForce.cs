using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class RotateObjectForce : MonoBehaviour
{
    public GameObject rotateObject;
    public float torqueAmoungt;

    private bool _IsSpaceBarHeld;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _IsSpaceBarHeld = Input.GetKey(KeyCode.Space);
        Rigidbody rb = rotateObject.GetComponent<Rigidbody>();

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
                rb.AddRelativeTorque(0,-torqueAmoungt,0,ForceMode.Force);
            if(Input.GetKey(KeyCode.RightArrow))
                rb.AddRelativeTorque(0,torqueAmoungt,0,ForceMode.Force);
        }
        else
        {
            if(Input.GetKey(KeyCode.LeftArrow))
                rb.AddRelativeTorque(-torqueAmoungt,0,0,ForceMode.Force);
            if(Input.GetKey(KeyCode.RightArrow))
                rb.AddRelativeTorque(torqueAmoungt,0,0,ForceMode.Force);
        }
        
    }

    void vertical_control()
    {
        Rigidbody rb = rotateObject.GetComponent<Rigidbody>();
        
        if (Input.GetKey(KeyCode.UpArrow))
            rb.AddRelativeTorque(0,0,torqueAmoungt,ForceMode.Force);
        if (Input.GetKey(KeyCode.DownArrow))
            rb.AddRelativeTorque(0,0,-torqueAmoungt,ForceMode.Force);
    }
}
