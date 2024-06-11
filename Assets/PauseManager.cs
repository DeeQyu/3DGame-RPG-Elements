using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public Text pauseText;

    private bool isPaused = false;

    void Update()
    {
        // Check for pause input (e.g., the "P" key)
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        // Pause or unpause the game
        Time.timeScale = isPaused ? 0f : 1f;

        // Show/hide the pause panel and set the pause text
        if (isPaused)
        {
            pausePanel.SetActive(true);
            pauseText.text = "PAUSE";
        }
        else
        {
            pausePanel.SetActive(false);
        }
    }
}
