using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{
    public Image LogoImage;

    float Chronometre;
    float ElapsedRate;

    void Update()
    {
        Chronometre += Time.deltaTime;

        if (Chronometre >= 2.0f)
        {
            LogoFadeOut();
        }

        if (Chronometre >= 4.0f)
        {
            SceneManager.LoadScene(1);
        }
    }

    void LogoFadeOut()
    {
        ElapsedRate += Time.deltaTime / 2.0f;
        
        Color Colour = LogoImage.color;

        Colour.a = Mathf.Lerp(1.0f, 0.0f, ElapsedRate);

        LogoImage.color = Colour;
    }
}
