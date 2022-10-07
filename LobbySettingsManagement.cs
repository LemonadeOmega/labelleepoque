using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbySettingsManagement : MonoBehaviour
{
    public static LobbySettingsManagement Instance;

    public Text[] Letters;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        switch (LobbySettingsManagement.Instance.Settings)
        {
            case true:
                switch (LobbySettingsManagement.Instance.Resolution)
                {
                    case 0:
                        switch (LobbySettingsManagement.Instance.Presentation)
                        {
                            case true:
                                Screen.SetResolution(1280, 720, true);
                                break;
                            case false:
                                Screen.SetResolution(1280, 720, false);
                                break;
                        }
                        break;
                    case 1:
                        switch (LobbySettingsManagement.Instance.Presentation)
                        {
                            case true:
                                Screen.SetResolution(1920, 1080, true);
                                break;
                            case false:
                                Screen.SetResolution(1920, 1080, false);
                                break;
                        }
                        break;
                    case 2:
                        switch (LobbySettingsManagement.Instance.Presentation)
                        {
                            case true:
                                Screen.SetResolution(2560, 1440, true);
                                break;
                            case false:
                                Screen.SetResolution(2560, 1440, false);
                                break;
                        }
                        break;
                }
                break;
            case false:
                Screen.SetResolution(1920, 1080, true);
                LobbySettingsManagement.Instance.Resolution = 1;
                LobbySettingsManagement.Instance.Presentation = true;
                English();
                LobbySettingsManagement.Instance.Language = 1;
                LobbySettingsManagement.Instance.Settings = true;
                break;
        }
    }

    void Update()
    {
        switch (LobbySettingsManagement.Instance.Resolution)
        {
            case 0:
                switch (LobbySettingsManagement.Instance.Presentation)
                {
                    case true:
                        Screen.SetResolution(1280, 720, true);
                        break;
                    case false:
                        Screen.SetResolution(1280, 720, false);
                        break;
                }
                break;
            case 1:
                switch (LobbySettingsManagement.Instance.Presentation)
                {
                    case true:
                        Screen.SetResolution(1920, 1080, true);
                        break;
                    case false:
                        Screen.SetResolution(1920, 1080, false);
                        break;
                }
                break;
            case 2:
                switch (LobbySettingsManagement.Instance.Presentation)
                {
                    case true:
                        Screen.SetResolution(2560, 1440, true);
                        break;
                    case false:
                        Screen.SetResolution(2560, 1440, false);
                        break;
                }
                break;
        }

        switch (LobbySettingsManagement.Instance.Language)
        {
            case 0:
                Korean();
                break;
            case 1:
                English();
                break;
            case 2:
                Japanese();
                break;
            case 3:
                German();
                break;
            case 4:
                Italian();
                break;
            case 5:
                Spanish();
                break;
            case 6:
                Turkish();
                break;
        }
    }

    void Korean()
    {
        Letters[0].text = "Ω√¿€";
        Letters[1].text = "º≥¡§";
        Letters[2].text = "¡æ∑·";
    }

    void English()
    {
        Letters[0].text = "START";
        Letters[1].text = "SETTINGS";
        Letters[2].text = "EXIT";
    }

    void Japanese()
    {
        Letters[0].text = "„∑Ì¬";
        Letters[1].text = "‡‚Ô“";
        Letters[2].text = "˚÷ı";
    }

    void German()
    {
        Letters[0].text = "START";
        Letters[1].text = "EINSTELLUNGEN";
        Letters[2].text = "ENDE";
    }

    void Italian()
    {
        Letters[0].text = "INIZIO";
        Letters[1].text = "IMPOSTAZIONI";
        Letters[2].text = "USCITA";
    }

    void Spanish()
    {
        Letters[0].text = "INICIO";
        Letters[1].text = "AJUTES";
        Letters[2].text = "SALIDA";
    }

    void Turkish()
    {
        Letters[0].text = "BA?LAMA";
        Letters[1].text = "TERC?HLER";
        Letters[2].text = "B?TME";
    }

    public int Resolution
    {
        get
        {
            if (!PlayerPrefs.HasKey("Resolustion"))
            {
                return 0;
            }

            string temporaryresolution = PlayerPrefs.GetString("Resolution");

            return int.Parse(temporaryresolution);
        }

        set
        {
            PlayerPrefs.SetString("Resolution", value.ToString());
        }
    }

    public int Language
    {
        get
        {
            if (!PlayerPrefs.HasKey("Language"))
            {
                return 0;
            }

            string temporarylanguage = PlayerPrefs.GetString("Language");

            return int.Parse(temporarylanguage);
        }

        set
        {
            PlayerPrefs.SetString("Resolution", value.ToString());
        }
    }

    public bool Presentation
    {
        get
        {
            if (!PlayerPrefs.HasKey("Presentation"))
            {
                return false;
            }

            string temporarypresentation = PlayerPrefs.GetString("Presentation");

            return bool.Parse(temporarypresentation);
        }

        set
        {
            PlayerPrefs.SetString("Presentation", value.ToString());
        }
    }

    public bool Settings
    {
        get
        {
            if (!PlayerPrefs.HasKey("Settings"))
            {
                return false;
            }

            string temporarysettings = PlayerPrefs.GetString("Settings");

            return bool.Parse(temporarysettings);
        }

        set
        {
            PlayerPrefs.SetString("Settings", value.ToString());
        }
    }
}
