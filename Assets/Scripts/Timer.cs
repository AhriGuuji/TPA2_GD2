using UnityEngine;

public class Timer
{
    public int seconds = 60;
    public int days = 5;

    public ScoreManager scoreManager;

    private int currentDay = 1;
    private float timer;

    void Start()
    {
        timer = seconds;
    }

    void Update()
    {
       timer -= Time.deltaTime;
       
       if (timer <= 0)
        {

        }
    }
}

