using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backLeft;

    //variables
    public float acceleration = 600f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 18f;

    private float currentAcceleration;
    private float currentBreak;
    private float currentTurnAngle;

    private void FixedUpdate()
    {
        //foward/reverse from the w and s keys. from the vertical axes (which is usually up or down)
        currentAcceleration = acceleration * Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
            currentBreak = breakingForce;
        else
            currentBreak = 0;

        //apply acceleration only to the front wheels
        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;

        //brake torque is essentially the power of the braking system. 
        frontRight.brakeTorque = currentBreak;
        frontLeft.brakeTorque = currentBreak;
        backRight.brakeTorque = currentBreak;
        backLeft.brakeTorque = currentBreak;

        //steering left/right with "a" and "d" keys. uses the x axis
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;
    }
}

