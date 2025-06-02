using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    [SerializeField] private int secondsPerDay = 60;
    [SerializeField] private int totalDays = 5;

    private int currentDay = 1;
    private float timeRemaining;
    private bool isTimerRunning = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if (isTimerRunning && SceneManager.GetActiveScene().name.Contains("Level"))
        {
            timeRemaining -= Time.deltaTime;
            
            if (timeRemaining <= 0)
            {
                EndDay();
            }
        }
    }

    private void ResetTimer()
    {
        timeRemaining = secondsPerDay;
    }

    private void EndDay()
    {
        isTimerRunning = false;
        currentDay++;
        
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.EndOfTheDayScore();
        }
        
        if (currentDay > totalDays)
        {
            // Game over or final day logic
            Debug.Log("All days completed!");
        }
        else
        {
            ResetTimer();
            // Load next day or scene
        }
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public float GetTimeRemaining()
    {
        return timeRemaining;
    }

    public int GetCurrentDay()
    {
        return currentDay;
    }
}