using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbySettings : MonoBehaviour
{

    public Button HD;
    public Button FHD;
    public Button QHD;
    public Button FullScreen;
    public Button WindowScreen;
    public Button Korean;
    public Button English;
    public Button Japanese;
    public Button German;
    public Button Italian;
    public Button Spanish;
    public Button Turkish;

    public Image LobbyFadeOutImage;
    public Image SettingsPanel;

    float ElapsedRate;

    void Start()
    {
        SettingsPanel.gameObject.SetActive(false);
    }

    public void MainSceneLoad()
    {
        LobbyFadeOut();

        SceneManager.LoadScene(2);
    }

    public void Settings()
    {
        SettingsPanel.gameObject.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Close()
    {

    }

    void LobbyFadeOut()
    {
        ElapsedRate += Time.deltaTime / 2.0f;

        Color Colour = LobbyFadeOutImage.color;

        Colour.a = Mathf.Lerp(0.0f, 1.0f, ElapsedRate);

        LobbyFadeOutImage.color = Colour;
    }
}
