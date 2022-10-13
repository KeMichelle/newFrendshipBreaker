using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public WheelCollider wheelColliderLXfront;
    public WheelCollider wheelColliderRXfront;
    public WheelCollider wheelColliderLXback;
    public WheelCollider wheelColliderRXback;

    public Transform wheelLXfront;
    public Transform wheelRXfront;
    public Transform wheelLXback;
    public Transform wheelRXback;

    public Transform centerMassa;
    public float motorTorque = 2000f;
    public float maxTurn= 20f;

    public float Steer { get; set; }
    public float Throttle { get; set; }

   

    private Rigidbody _rigidbody;
    private Wheel[] wheels;

    void Start()
    {
        wheels = GetComponentsInChildren<Wheel>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centerMassa.localPosition;
    }

    void Update()
    {
        foreach(var wheel in wheels)
        {
            wheel.SteerAngle = Steer * maxTurn;
            wheel.Torque = Throttle * motorTorque;
        }
    }


    void FixedUpdate()
    {
        wheelColliderLXback.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        wheelColliderRXback.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        wheelColliderLXfront.steerAngle = Input.GetAxis("Horizontal") * maxTurn;
        wheelColliderRXfront.steerAngle = Input.GetAxis("Horizontal") * maxTurn;
    }
}
