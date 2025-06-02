using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    [SerializeField] private float secondsPerDay = 60f;
    [SerializeField] private int totalDays = 5;

    public UnityEvent OnDay2Reached; 

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
        
        if (currentDay == 2)
        {
            OnDay2Reached.Invoke();
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
        
        if (currentDay > totalDays)
        {
            SceneManager.LoadScene("Final");
        }
        else
        {
            ResetTimer();
            ScoreManager.Instance.EndOfTheDayScore();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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