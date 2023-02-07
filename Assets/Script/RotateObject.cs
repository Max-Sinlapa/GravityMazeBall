using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;


public class RotateObject : MonoBehaviour
{
    public Vector3 StartMousePosition;
    public Vector3 Current_Mouse_Position;
    public Vector3 Current_Mouse_Direction;
    private Vector3 MouseDistanceTravle;
    
    public Vector3 PrevisObjectRotation;
    public Vector3 Current_Object_Rotation;

    public float MouseVectorScale;
    void Start()
    {
        PrevisObjectRotation = transform.rotation.eulerAngles;
    }
    

    void Update()
    {
        LeftMouse();
        RightMouse();
    }

    
    void LeftMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartMousePosition = Input.mousePosition;
           
        }
        
        if (Input.GetMouseButton(0))
        {
            MouseDistanceTravle = (Input.mousePosition - StartMousePosition);
            Current_Mouse_Direction = MouseDistanceTravle.normalized;
            Current_Object_Rotation.z = PrevisObjectRotation.z + ((Current_Mouse_Direction.x + (MouseDistanceTravle.x * MouseVectorScale)) * -1);
            transform.localRotation = Quaternion.Euler(PrevisObjectRotation.x, PrevisObjectRotation.y, Current_Object_Rotation.z);
        }

        if (Input.GetMouseButtonUp(0))
        {
            PrevisObjectRotation = transform.rotation.eulerAngles;
            PrevisObjectRotation.z = Current_Object_Rotation.z;
            
            /*
            Vector3 nee = new Vector3(transform.localRotation.x, transform.localRotation.y, Current_Object_Rotation.z);
            PrevisObjectRotation = nee;
            */
            
        }
        
    }
    
    void RightMouse()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartMousePosition = Input.mousePosition;
            PrevisObjectRotation = transform.rotation.eulerAngles;
        }
           
        
        if (Input.GetMouseButton(1))
        {
            MouseDistanceTravle = (Input.mousePosition - StartMousePosition);
            Current_Mouse_Direction = MouseDistanceTravle.normalized;
            Current_Object_Rotation.x = PrevisObjectRotation.x + (Current_Mouse_Direction.y + (MouseDistanceTravle.y * MouseVectorScale));
            transform.localRotation = Quaternion.Euler(Current_Object_Rotation.x, PrevisObjectRotation.y, PrevisObjectRotation.z);
        }
        
        if (Input.GetMouseButtonUp(1))
        {
            Vector3 nee = new Vector3(Current_Object_Rotation.x, transform.localRotation.y, Current_Object_Rotation.z);
            PrevisObjectRotation = nee;
        }
    }
    
}
