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
    public float motorTorque;
    public float maxTurn;

    public float Steer { get; set; }
    public float Throttle { get; set; }

   

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centerMassa.localPosition;
    }

    void FixedUpdate()
    {
        PlayerMode pm = GetComponent<PlayerMode>();
        if(pm.tipoControllo == PlayerMode.ControlType.HumanInput)
        {
            Debug.Log($"Va:{Input.GetAxis("Vertical")}, Ha:{Input.GetAxis("Horizontal")}");
            wheelColliderLXback.motorTorque = Input.GetAxis("Vertical") * motorTorque;
            wheelColliderRXback.motorTorque = Input.GetAxis("Vertical") * motorTorque;
            wheelColliderLXfront.steerAngle = Input.GetAxis("Horizontal") * maxTurn;
            wheelColliderRXfront.steerAngle = Input.GetAxis("Horizontal") * maxTurn;
        }
    }

    
}
