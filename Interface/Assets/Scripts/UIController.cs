using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject configPanel; //panel de configGeral somente. Chamar os outros por bot�o
    [SerializeField] GameObject pausePanel; //inGame
    [SerializeField] Slider soundVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;

    bool isPanelActive;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 0) ConfigPanel();

        if (Input.GetKeyDown(KeyCode.P) && SceneManager.GetActiveScene().buildIndex != 0) PausePanel();
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ConfigPanel()
    {
        isPanelActive = !isPanelActive;

        if (isPanelActive) Time.timeScale = 0;
        else Time.timeScale = 1;

        configPanel.SetActive(isPanelActive);
    }

    public void PausePanel()
    {
        isPanelActive = !isPanelActive;

        if (isPanelActive) Time.timeScale = 0;
        else Time.timeScale = 1;

        pausePanel.SetActive(isPanelActive);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RefreshSliders(float soundVolume, float musicVolume)
    {
        soundVolumeSlider.value = soundVolume;
        musicVolumeSlider.value = musicVolume;
    }
}
