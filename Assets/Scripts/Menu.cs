using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public static MenuUI Instance;
    [SerializeField] private Canvas _settingsMenu;
    [SerializeField] private Canvas _startMenu;
    [SerializeField] private Canvas _gameUI;

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

    void Update()
    {
        if (SceneManager.GetActiveScene().name.Contains("Sample"))
        {
            _startMenu.enabled = false;
            _gameUI.enabled = true;
        }
        else if (SceneManager.GetActiveScene().name.Contains("Final"))
            _gameUI.enabled = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenSettings()
    {
        _settingsMenu.enabled = true;
        if (_startMenu.enabled)
            _startMenu.enabled = false;
        if (_gameUI)
            _gameUI.enabled = false;
        Time.timeScale = 0;
    }

    public void CloseSettings()
    {
        _settingsMenu.enabled = false;
        if (SceneManager.GetActiveScene().buildIndex == 0)
            _startMenu.enabled = true;
        if (SceneManager.GetActiveScene().name.Contains("Level"))
            _gameUI.enabled = true;
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
