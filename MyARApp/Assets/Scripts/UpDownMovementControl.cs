using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UpDownMovementControl : MonoBehaviour
{
    public Rigidbody arObject;
    public float forwardForce = 10f;
    public float force = 15f;
    private GameObject camera;

    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
      //  arObject.transform.rotation = new Quaternion(0f,camera.transform.rotation.y,0f,camera.transform.rotation.w);
    }

    public void MoveUp()
    {
        arObject.AddForce(0,forwardForce*Time.deltaTime,0);
    }

    public void MoveDown()
    {
        arObject.AddForce(0,-forwardForce*Time.deltaTime,0);
    }

    public void MoveFront()
    {
        arObject.AddForce(forwardForce*Time.deltaTime,0,0);
    }
    public void MoveBack()
    {
        arObject.AddForce(-forwardForce*Time.deltaTime,0,0);
    }
    public void MoveRight()
    {
        arObject.AddForce(0,0,forwardForce*Time.deltaTime);
    }
    public void MoveLeft()
    {
        arObject.AddForce(0,0,-forwardForce*Time.deltaTime); 
    }
    
}
