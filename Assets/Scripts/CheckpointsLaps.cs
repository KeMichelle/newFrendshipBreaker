using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CheckpointsLaps : MonoBehaviour
{
    private float timerLap;
    private int lastCheckpointThru;
    private CarController carController;

    private Transform checkpointsParent;
    private int checkpointCount;
    private int checkpointLayer;

    public int CurrentLap { get; private set; } = 0;
    public float CurrentLapTime { get; private set; } = 0;
    public float BestLapTime { get; private set; } = Mathf.Infinity;
    public float LastLapTime{get; private set;} = 0;
    public int TotalLaps { get; private set; } = 3;


    private void Awake()
    {
        //we look into the hierarchy for the game object called "checkpoints" which is our empty game object with all the other ones
        checkpointsParent = GameObject.Find("Checkpoints").transform;
        checkpointCount = checkpointsParent.childCount;
        checkpointLayer = LayerMask.NameToLayer("Checkpoint");
        carController = GetComponent<CarController>();
    }

    private void Update()
    {
       /* if(controlType == ControlType.HumanInput)
        {

        }*/
    }
} 


