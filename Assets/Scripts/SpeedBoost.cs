using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    private Car trespasser;
    private bool spedUp = false;
    private float originalSpeed;

    //ludicrous speed!
    private void OnTriggerEnter(Collider other)
    {
        if (!spedUp)
        {
            trespasser = other.transform.GetComponentInParent<Car>();
		    originalSpeed = trespasser.motorTorque;
            trespasser.motorTorque = 9999;
            spedUp = !spedUp;
            return;
        }
		
	}

    private void OnTriggerExit(Collider other)
    {
		trespasser = other.transform.GetComponentInParent<Car>();
		trespasser.motorTorque = originalSpeed;
	}
}
