using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public bool steer;
    public bool power;

    public float SteerAngle { get; set; }
    public float Torque { get; set; }

    private Transform wheeltransform;
    private WheelCollider wheelCollider;

    
    void Start()
    {
        wheelCollider = GetComponentInChildren<WheelCollider>();
        wheeltransform = GetComponentInChildren<MeshRenderer>().GetComponent<Transform>();
    }

   
    void Update()
    {
        //pos is the position of the wheel in world space
        //quat is the rotation of the wheel in the world space
        wheelCollider.GetWorldPose(out Vector3 pos, out Quaternion rot);
        wheeltransform.position = pos;
        wheeltransform.rotation = rot;
    }

    void FixedUpdate()
    {
        if (power)
        {
            wheelCollider.motorTorque = Torque;
        }
        if (steer)
        {
            wheelCollider.steerAngle = SteerAngle;
        }
    }
}
