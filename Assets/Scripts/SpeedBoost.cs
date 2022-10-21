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
			spedUp = !spedUp;
			trespasser = other.transform.GetComponentInParent<Car>();
			trespasser.isSpedUp = true;
		    originalSpeed = trespasser.motorTorque;
            trespasser.motorTorque = 13000;
			//Debug.Log($"(SpeedBoost.cs.onTriggerEnter)OriginalSpeed: {originalSpeed}");
			//Debug.Log($"(SpeedBoost.cs.onTriggerEnter)Trespasser speed: {trespasser.motorTorque}");
			//Debug.Log($"(SpeedBoost.cs.onTriggerEnter)SpedUp: {spedUp}");
        }
		
	}

    private void OnTriggerExit(Collider other)
    {
		if (spedUp)
		{
		spedUp = !spedUp;
		trespasser.motorTorque = originalSpeed;
		//Debug.Log($"(SpeedBoost.cs.onTriggerExit)OriginalSpeed: {originalSpeed}");
		//Debug.Log($"(SpeedBoost.cs.onTriggerExit)Trespasser speed: {trespasser.motorTorque}");
		//Debug.Log($"(SpeedBoost.cs.onTriggerExit)Trespasser speed: {spedUp}");
		}
        
	}
}
