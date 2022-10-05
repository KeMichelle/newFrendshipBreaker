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

    // Start is called before the first frame update
    void Start()
    {
        wheelCollider = GetComponentInChildren<WheelCollider>();
        wheeltransform = GetComponentInChildren<MeshRenderer>().GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
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
