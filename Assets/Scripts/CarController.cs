using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float steerAngle;
    private bool isBreaking;

    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;

    Transform wheels;

    Transform frontLeftWheelTransform;
    Transform frontRightWheelTransform;
    Transform rearLeftWheelTransform;
    Transform rearRightWheelTransform;

    public float maxSteeringAngle = 30f;
    public float motorForce = 50f;
    public float breakForce = 300f;

    private float currentBreakForce = 0f;

    void Start()
    {

        wheels = transform.Find("Parts");

        // Find child transform with part of the name
        foreach (Transform child in wheels.transform)
        {
            if (child.name.Contains("Wheel"))
            {
                wheels = child.transform;
                Debug.Log("Found wheel");
                Debug.Log(child.name);
            }
        }

        frontLeftWheelTransform = wheels.transform.GetChild(0).GetChild(0);
        frontRightWheelTransform = wheels.transform.GetChild(1).GetChild(0);
        rearLeftWheelTransform = wheels.transform.GetChild(2).GetChild(0);
        rearRightWheelTransform = wheels.transform.GetChild(3).GetChild(0);

    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        // For some reason se vrtijo kolesa v napačno smer, zato "-"
        verticalInput = -Input.GetAxis("Vertical");
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleSteering()
    {
        steerAngle = maxSteeringAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        rearLeftWheelCollider.motorTorque = verticalInput * motorForce;
        rearRightWheelCollider.motorTorque = verticalInput * motorForce;

        currentBreakForce = isBreaking ? breakForce : 0f;
        frontLeftWheelCollider.brakeTorque = currentBreakForce;
        frontRightWheelCollider.brakeTorque = currentBreakForce;
        rearLeftWheelCollider.brakeTorque = currentBreakForce;
        rearRightWheelCollider.brakeTorque = currentBreakForce;
    }

    private void UpdateWheels()
    {
        UpdateWheelPos(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheelPos(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheelPos(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateWheelPos(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateWheelPos(WheelCollider wheelCollider, Transform trans)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        //Debug.Log(rot);
        // rotate rot by 90 degrees
        rot *= Quaternion.Euler(0, 90, 0);
        trans.rotation = rot;
        trans.position = pos;
    }

}