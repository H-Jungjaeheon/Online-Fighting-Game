using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerTxt;

    private readonly int maxTime = 180;
    private float time;

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

    private void Update()
    {
        if (isPause) return;

        time -= Time.deltaTime;
        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        timerTxt.text = minutes.ToString("0") + ":" + seconds.ToString("00");

        if (time <= 0) print("stop");
    }
}