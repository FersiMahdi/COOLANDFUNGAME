
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public GameObject settingWindow;
    public static MainMenu instance;

    private void Awake()
    {
        //GUIUtility.systemCopyBuffer = "";
        if (instance != null)
        {
            Debug.LogWarning("there is more than an instance of Main Menu in the scene");
        }
    else instance = this;
    }

    private void Start()
    {
        PlayerPrefs.SetInt("coinsCount",0);
        PlayerPrefs.SetInt("playerHealth",100);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void SettingButton()
    {
        settingWindow.SetActive(true);
    }

    public void LoadCreditScene()
    {
        SceneManager.LoadScene("Credits");
    }
    public void CloseSettingsWindow()
    {
        settingWindow.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadSelectNiveauScene()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
