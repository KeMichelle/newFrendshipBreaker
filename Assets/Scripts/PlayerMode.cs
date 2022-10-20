using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMode : MonoBehaviour
{
    public enum ControlType { HumanInput, AI }
    public ControlType tipoControllo;


    private Transform parentofCheckpoints;
    private float lapTimer;
    private int lastCheckpointpassed = 0;
    private int checkpointCount = 0;
    private int checkpointLayer;
    private Car carController;
    private GameObject[] checkpoints;
    

    public float BestLapTime { get; private set; } = Mathf.Infinity;
    public float LastLapTime { get; private set; } = 0;
    public float CurrentLapTime { get; private set; } = 0;
    public int CurrentLap { get; private set; } = 0;
    public int totalLaps { get; private set; } = 3;
   

    void Awake()
    {
        checkpoints = GameObject.Find("Checkpoints").GetComponentsInChildren<GameObject>();
		parentofCheckpoints = GameObject.Find("Checkpoints").transform;
        checkpointCount = parentofCheckpoints.childCount;
        checkpointLayer = LayerMask.NameToLayer("Checkpoint");
        carController = GetComponent<Car>();
        foreach (var item in checkpoints)
        {
            Debug.Log($"{item.transform.position}");

		}
    }

    void StartLap()
    {
        CurrentLap++;
        lastCheckpointpassed = 1;
        lapTimer = Time.time;
    }

    void EndLap()
    {
        LastLapTime = Time.time - lapTimer;
        BestLapTime = Mathf.Min(LastLapTime, BestLapTime);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer != checkpointLayer)
        {
            return; //do nothing
        }

        //if this is the 1st checkpoint
        if(collider.gameObject.name == "Start/End")
        {
            //we completed the lap. so it will end the current lap
            if(lastCheckpointpassed == checkpointCount)
            {
                //we completed the lap
                EndLap();
                Debug.Log($"Ended new lap - laptime was {LastLapTime} seconds");
            }

            //if we passed the last checkpoint then we start a new checkpoint
            if(CurrentLap == 0 || lastCheckpointpassed == checkpointCount)
            {
                StartLap();
                Debug.Log("started new lap");
            }
        }

        //we update all the checkpoints passed, its a check so the player doesnt go back and forth from the start/end checkpoint
        if (collider.gameObject.name == (lastCheckpointpassed + 1).ToString())
        {
            lastCheckpointpassed++;
        }
    }

    void Update()
    {
        CurrentLapTime = lapTimer > 0 ? Time.time - lapTimer : 0;

        //if we are humans then it will use the controls made in the script of the car control
        if(tipoControllo == ControlType.HumanInput)
        {
            carController.Steer = GameManager.Instance.InputController.SteerInput;
            carController.Throttle = GameManager.Instance.InputController.ThrottleInput;
        }

        //still need to do this part, Micheal is working on it
        //RE from Mike: i worked on it :D
        else if(tipoControllo == ControlType.AI)
        {
            //Vector3 path = new Vector3(carController.transform.position.x - checkpoints[checkpointCount]);
            
        }
    }
    }
