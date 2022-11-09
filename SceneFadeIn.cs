using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFadeIn : MonoBehaviour
{
    public Image LobbyFadeInImage;

    float ElapsedRate;

    void Start()
    {
        LobbyFadeIn();
    }

    void LobbyFadeIn()
    {
        while (ElapsedRate < 1.0f)
        {
            ElapsedRate += Time.deltaTime / 2.0f;

            Color Colour = LobbyFadeInImage.color;

            Colour.a = Mathf.Lerp(1.0f, 0.0f, ElapsedRate);

            LobbyFadeInImage.color = Colour;
        }
    }
}
