using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerTxt;

    private readonly int maxTime = 180;
    private float time;
    private int min;
    private int sec;

    private bool isPause;

    private void Start()
    {
        StartSet();
    }

    public void StartSet()
    {
        time = maxTime;
    }

    public void TimerPause()
    {
        isPause = true;
    }

    public void TimerPlay()
    {
        isPause = false;
    }

    private void TimeCalculation()
    {
        time -= Time.deltaTime;

        min = (int)time / 60 % 60;
        sec = (int)time % 60;

        if (sec < 10)
        {
            timerTxt.text = $"{min}:0{sec}";
        }
        else
        {
            timerTxt.text = $"{min}:{sec}";
        }

        if (time <= 0) print("stop");
    }


    void Update()
    {

        if (isPause == true) return;

        TimeCalculation();
    }
}
