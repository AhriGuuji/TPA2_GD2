using UnityEngine;
using UnityEngine.UI;

public class AbilitySelectionScreen : MonoBehaviour
{
    private void Start()
    {
        // Hide by default
        gameObject.SetActive(false);

        // Listen for day 2 event
        Timer.Instance.OnDay2Reached.AddListener(ShowSelectionScreen);
    }

    private void Update()
    {
        if (PlayerAbilityManager.Instance.CanPickUp | PlayerAbilityManager.Instance.CanThrow)
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
    }

    private void ShowSelectionScreen()
    {
        // Pause game
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }
}