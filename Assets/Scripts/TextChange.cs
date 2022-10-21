using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChange : MonoBehaviour
{
    //we made this script to update all the text for the game 

    public GameObject PanelofText;

    public Text CurrentLapText;
    public Text CurrentTimeText;
    public Text LastLapTimeText;
    public Text BestLapTimeText;

    public PlayerMode UpdateTextForPlayer;

    private int currentLap;
    private float currentTime;
    private float bestLapTime;
    private float lastLapTime;

    void Update()
    {
        if(UpdateTextForPlayer == null)
        {
            return;
        }

        if(UpdateTextForPlayer.CurrentLap != currentLap)
        {
            currentLap = UpdateTextForPlayer.CurrentLap;
            CurrentLapText.text = $"LAP : {currentLap}";
        }

        if(UpdateTextForPlayer.CurrentLapTime != currentTime)
        {
            currentTime = UpdateTextForPlayer.CurrentLapTime;
            CurrentTimeText.text = $"TIME: {(int)currentTime / 60}:{(currentTime) % 60:00.000} "; 
        }

        if (UpdateTextForPlayer.LastLapTime != lastLapTime)
        {
            lastLapTime = UpdateTextForPlayer.LastLapTime;
            LastLapTimeText.text = $"Last lap: {(int)currentTime / 60}:{(lastLapTime) % 60:00.000} "; 
        }

        if (UpdateTextForPlayer.BestLapTime != bestLapTime)
        {
            bestLapTime = UpdateTextForPlayer.BestLapTime;
            BestLapTimeText.text = $"best lap: {(int)currentTime / 60}:{(bestLapTime) % 60:00.000} "; 
        }
    }
}
