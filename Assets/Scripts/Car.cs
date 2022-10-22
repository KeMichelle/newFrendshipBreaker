using System;
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
    [NonSerialized] public bool isSpedUp; 

    public float Steer { get; set; }
    public float Throttle { get; set; }


    private PlayerMode pm;
	private Rigidbody _rigidbody;

    void Start()
    {
		pm = GetComponent<PlayerMode>();
		_rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centerMassa.localPosition;
    }

    void FixedUpdate()
    {
        //for the player
        if(pm.tipoControllo == PlayerMode.ControlType.HumanInput)
        {
            SetInput(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        }
        
        //algorithm for the CPU✨
        else if(pm.tipoControllo == PlayerMode.ControlType.AI)
        {
            float forwardAmount, steerAmount;
            Vector3 targetPos = getTargetPos();
			Vector3 movingDirectionPos = (targetPos - transform.position).normalized;
			float dot = Vector3.Dot(transform.forward, movingDirectionPos);
            float distanceToTarget = Vector3.Distance(transform.forward, movingDirectionPos);
            float angleToDir = Vector3.SignedAngle(transform.forward, movingDirectionPos, Vector3.up);

			//Debug.Log($"Distanza AI-Check: {distanceToTarget}");

			//target in front
			if (dot > 0f) forwardAmount = 1f;
            else 
            {
                //target behind and far
                if (distanceToTarget > 1.5f) forwardAmount = 1f;

                //target behind close
                else forwardAmount = -1f;
            }

			if (angleToDir > 0f) steerAmount = 1f;
			else steerAmount = -1f;

            SetInput(forwardAmount, steerAmount);
        }
    }

    public void SetInput(float forwardAmount, float steerAmount) 
    {
        //forwardAmount > 0: forward, < 0: reverse, = 0: stop
        //steerAmount > 0: right, < 0: left, = 0: no turn
		wheelColliderLXback.motorTorque = forwardAmount * motorTorque;
		wheelColliderRXback.motorTorque = forwardAmount * motorTorque;
		wheelColliderLXfront.steerAngle = steerAmount * maxTurn;
		wheelColliderRXfront.steerAngle = steerAmount * maxTurn;
	}

    Vector3 getTargetPos()
    {
        return pm.checkpoints[pm.currentPlayerCheck].transform.position;
    }
}
