using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMode : MonoBehaviour
{
    public enum ControlType { HumanInput, AI }
    public ControlType tipoControllo;


    private float lapTimer;
    private int checkpointCount = 0;
    private int checkpointLayer;
    [NonSerialized]public int currentPlayerCheck = 0;

	[NonSerialized] public GameObject[] checkpoints;
    
    public float BestLapTime { get; set; } = Mathf.Infinity;
    public float LastLapTime { get; set; } = 0;
    public float CurrentLapTime { get; set; } = 0;
    public int CurrentLap { get; set; } = 0;
    public int totalLaps { get; set; } = 3;

    void Awake()
    {
        checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        checkpointCount = checkpoints.Length;
        checkpointLayer = LayerMask.NameToLayer("Checkpoint");
	}

    void StartLap()
    {
        CurrentLap++;
        lapTimer = Time.time;
    }

    void EndLap()
    {
        LastLapTime = Time.time - lapTimer;
        BestLapTime = Mathf.Min(LastLapTime, BestLapTime);
        //no visual checks for beep boop ;)
        if (tipoControllo == ControlType.HumanInput) foreach (var i in checkpoints) i.GetComponent<Renderer>().enabled = true;
        currentPlayerCheck = 0;
	}

    private void OnTriggerEnter(Collider collider)
    {
		if (collider.gameObject.layer != checkpointLayer) return; //do nothing
        
        //for the player 
        if(tipoControllo == ControlType.HumanInput)
        {
			//if we are passing by the start
			if (collider.gameObject.GetInstanceID() == checkpoints[0].GetInstanceID())
			{
				Debug.Log($"{currentPlayerCheck}, {checkpoints[currentPlayerCheck]}");

                //if this is the first check
				if (currentPlayerCheck == 0)
				{
					StartLap();
					Debug.Log("started new lap");
				}
                //if we did all of previous checks and are ending the lap
                else
                {
                    EndLap();
					Debug.Log($"Ended new lap - laptime was {LastLapTime} seconds");
                } 
                checkpoints[0].GetComponent<Renderer>().enabled = false;
                currentPlayerCheck++;
			}
			else if (collider.gameObject.GetInstanceID() == checkpoints[currentPlayerCheck].GetInstanceID())
			{
				if (currentPlayerCheck == checkpointCount - 1)
				{
					checkpoints[currentPlayerCheck].GetComponent<Renderer>().enabled = false;
					checkpoints[0].GetComponent<Renderer>().enabled = true;
					Debug.Log(currentPlayerCheck);
					return;
				}
				Debug.Log($"{currentPlayerCheck}, {checkpoints[currentPlayerCheck].GetInstanceID()}");
				checkpoints[currentPlayerCheck].GetComponent<Renderer>().enabled = false;
				currentPlayerCheck++;
			}
		}

		//beep boop?
        else if (tipoControllo == ControlType.AI)
		{
			//if we are passing by the start
			if (collider.gameObject.GetInstanceID() == checkpoints[0].GetInstanceID())
			{

                //if this is the first check
				if (currentPlayerCheck == 0)
				{
					StartLap();
				}
                //if we did all of previous checks and are ending the lap
                else
                {
                    EndLap();
                } 
                currentPlayerCheck++;
			}
			else if (collider.gameObject.GetInstanceID() == checkpoints[currentPlayerCheck].GetInstanceID())
			{
				if (currentPlayerCheck == checkpointCount - 1)
				{
					return;
				}
				currentPlayerCheck++;
			}
		}
		

	}

    void Update()
    {
        CurrentLapTime = lapTimer > 0 ? Time.time - lapTimer : 0;

    }
}
