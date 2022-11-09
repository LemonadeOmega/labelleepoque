using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalManagement : MonoBehaviour
{
    public static TotalManagement Instance;

    public GameObject RealTimeHour;
    public GameObject RealTimeMinute;
    public GameObject RealTimeSecond;
    public GameObject ChronometreMinute;
    public GameObject ChronometreSecond;
    public GameObject[] AntiAircraft;

    public ParticleSystem LondonOnFireI;
    public ParticleSystem LondonOnFireII;
    public ParticleSystem LondonOnFireIII;
    public ParticleSystem LondonOnFireIIII;
    public ParticleSystem LondonOnFireV;
    public ParticleSystem LondonOnFireVI;
    public ParticleSystem LondonOnFireVII;
    public ParticleSystem LondonOnFireVIII;
    public ParticleSystem LondonOnFireIX;
    public ParticleSystem LondonOnFireX;
    public ParticleSystem LondonOnFireXI;
    public ParticleSystem LondonOnFireXII;

    public AudioClip SirenSoundEffect;

    public float ElapsedSecond;

    public O PresentChronoState { get; private set; }

    public delegate void GameStateChangeHandler(O o);

    public event GameStateChangeHandler ChronoState;

    public void SetChronoState(O o)
    {
        if (o == PresentChronoState)
        {
            return;
        }

        PresentChronoState = o;
        ChronoState?.Invoke(o);
    }

    BoxCollider Deployment;

    AudioSource SirenSoundControl;

    Vector3 AADeployment()
    {
        Vector3 AABattery = this.transform.position;
        Vector3 AAGun = Deployment.size;

        float AADeploymentAxisX = AABattery.x + UnityEngine.Random.Range(-AAGun.x / 2.0f, AAGun.x / 2.0f);
        float AADeploymentAxisY = AABattery.y + UnityEngine.Random.Range(-AAGun.y / 2.0f, AAGun.y / 2.0f);
        float AADeploymentAxisZ = AABattery.z + UnityEngine.Random.Range(-AAGun.z / 2.0f, AAGun.z / 2.0f);

        Vector3 AABatteryDeployment = new Vector3(AADeploymentAxisX, AADeploymentAxisY, AADeploymentAxisZ);

        return AABatteryDeployment;
    }

    int AntiAircraftBattery;

    float HourHandDegree = 30.0f;
    float MinuteHandDegree = 6.0f;
    float MinuteHandChronometreDegree = 12.0f;
    float SecondHandDegree = 6.0f;
    float Chronometre;
    float SirenChronometre;
    float AADeploymentChronometre;

    bool Silence;

    void Awake()
    {
        Application.targetFrameRate = 30;

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
        TotalManagement.Instance.Merit = 0;
        TotalManagement.Instance.Battery = 0;
        TotalManagement.Instance.Level = 0;

        TotalManagement.Instance.AirRaid = false;
        TotalManagement.Instance.Camera = false;
        TotalManagement.Instance.TriggerI = false;
        TotalManagement.Instance.TriggerII = false;
        TotalManagement.Instance.TriggerIII = false;
        TotalManagement.Instance.TriggerIIII = false;
        TotalManagement.Instance.TriggerV = false;
        TotalManagement.Instance.TriggerVI = false;
        TotalManagement.Instance.PropellerI = true;
        TotalManagement.Instance.PropellerII = true;
        TotalManagement.Instance.PropellerIII = true;
        TotalManagement.Instance.PropellerIIII = true;
        TotalManagement.Instance.Gondola = false;
        TotalManagement.Instance.Fire = false;

        LondonOnFireI.gameObject.SetActive(false);
        LondonOnFireII.gameObject.SetActive(false);
        LondonOnFireIII.gameObject.SetActive(false);
        LondonOnFireIIII.gameObject.SetActive(false);
        LondonOnFireV.gameObject.SetActive(false);
        LondonOnFireVI.gameObject.SetActive(false);
        LondonOnFireVII.gameObject.SetActive(false);
        LondonOnFireVIII.gameObject.SetActive(false);
        LondonOnFireIX.gameObject.SetActive(false);
        LondonOnFireX.gameObject.SetActive(false);
        LondonOnFireXI.gameObject.SetActive(false);
        LondonOnFireXII.gameObject.SetActive(false);

        Deployment = GetComponent<BoxCollider>();
        Deployment.enabled = false;

        SirenSoundControl = GetComponent<AudioSource>();

        AntiAircraftBattery = 6;

        AADeploymentChronometre = 3.0f;

        Silence = true;

        TotalManagement.Instance.ChronoState += Chrono;

        //StartCoroutine(Siren());
        StartCoroutine(Clock());
        StartCoroutine(LaBelleEpoqueSystem());
    }

    void OnDestroy()
    {
        TotalManagement.Instance.ChronoState -= Chrono;
    }

    IEnumerator LaBelleEpoqueSystem()
    {
        while (true)
        {
            switch (TotalManagement.Instance.PresentChronoState)
            {
                case O.One:
                    StartCoroutine(Chronograph());
                    StartCoroutine(AirDefenseSystem());
                    break;
                case O.Nought:
                    StopCoroutine(Chronograph());
                    StopCoroutine(AirDefenseSystem());
                    break;
            }

            yield return null;
        }
    }

    IEnumerator Siren()
    {
        while (true)
        {
            switch(TotalManagement.Instance.PresentChronoState)
            {
                case O.One:
                    SirenChronometre += Time.deltaTime;
                    if (Silence != true)
                    {
                        SirenSoundControl.UnPause();

                        Silence = true;
                    }
                    if (SirenSoundControl.isPlaying != true)
                    {
                        SirenSoundControl.PlayOneShot(SirenSoundEffect);
                    }
                    break;
                case O.Nought:
                    SirenSoundControl.Pause();
                    Silence = false;
                    break;
            }

            if (SirenChronometre >= 4.0f)
            {
                break;
            }

            yield return null;
        }
    }

    IEnumerator Clock()
    {
        while (true)
        {
            TimeSpan now = DateTime.Now.TimeOfDay;

            RealTimeHour.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, (float)now.TotalHours * HourHandDegree);
            RealTimeMinute.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, (float)now.TotalMinutes * MinuteHandDegree);
            RealTimeSecond.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, (float)now.TotalSeconds * SecondHandDegree);

            yield return null;
        }
    }

    IEnumerator Chronograph()
    {
        ElapsedSecond += Time.deltaTime;

        TimeSpan Elapsedtime = TimeSpan.FromSeconds(ElapsedSecond);

        ChronometreMinute.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, (float)Elapsedtime.TotalMinutes * MinuteHandChronometreDegree);
        ChronometreSecond.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, (float)Elapsedtime.TotalSeconds * SecondHandDegree);

        if (ElapsedSecond >= 300.0f)
        {
            LondonOnFireI.gameObject.SetActive(true);
            LondonOnFireII.gameObject.SetActive(true);

            AntiAircraftBattery = 12;

            TotalManagement.Instance.Level = 1;
        }

        if (ElapsedSecond >= 600.0f)
        {
            LondonOnFireIII.gameObject.SetActive(true);
            LondonOnFireIIII.gameObject.SetActive(true);

            AntiAircraftBattery = 18;

            TotalManagement.Instance.Level = 2;
        }

        if (ElapsedSecond >= 900.0f)
        {
            LondonOnFireV.gameObject.SetActive(true);
            LondonOnFireVI.gameObject.SetActive(true);
            LondonOnFireVII.gameObject.SetActive(true);
            LondonOnFireVIII.gameObject.SetActive(true);

            AADeploymentChronometre = 0.6f;
        }

        if (ElapsedSecond >= 1200.0f)
        {
            LondonOnFireIX.gameObject.SetActive(true);
            LondonOnFireX.gameObject.SetActive(true);
            LondonOnFireXI.gameObject.SetActive(true);
            LondonOnFireXII.gameObject.SetActive(true);

            AADeploymentChronometre = 0.3f;
        }

        if (ElapsedSecond >= 1500.0f)
        {
            TotalManagement.Instance.AirRaid = true;
        }

        yield return null;
    }

    IEnumerator AirDefenseSystem()
    {
        if (TotalManagement.Instance.AirRaid != true)
        {
            if (TotalManagement.Instance.Battery < 0)
            {
                TotalManagement.Instance.Battery = 0;
            }

            if (TotalManagement.Instance.Battery != AntiAircraftBattery)
            {
                StartCoroutine(AntiAircraftDeployment());
            }

            else if (TotalManagement.Instance.Battery == AntiAircraftBattery)
            {
                StopCoroutine(AntiAircraftDeployment());
            }

            Debug.Log(TotalManagement.Instance.Battery);

            yield return null;
        }
    }

    IEnumerator AntiAircraftDeployment()
    {
        Chronometre += Time.deltaTime;

        if (Chronometre >= AADeploymentChronometre)
        {
            int AA = UnityEngine.Random.Range(0, AntiAircraft.Length);

            Vector3 AABatteryDeployment = AADeployment();

            Instantiate(AntiAircraft[AA], AABatteryDeployment, Quaternion.identity);

            Chronometre = 0.0f;

            yield return null;
        }
        
    }

    void Chrono(O o)
    {
        enabled = o == O.One;
    }

    public int Merit
    {
        get
        {
            if (!PlayerPrefs.HasKey("Merit"))
            {
                return 0;
            }

            string temporarymerit = PlayerPrefs.GetString("Merit");

            return int.Parse(temporarymerit);
        }

        set
        {
            PlayerPrefs.SetString("Merit", value.ToString());
        }
    }

    public int Battery
    {
        get
        {
            if (!PlayerPrefs.HasKey("AA"))
            {
                return 0;
            }

            string temporaryaa = PlayerPrefs.GetString("AA");

            return int.Parse(temporaryaa);
        }

        set
        {
            PlayerPrefs.SetString("AA", value.ToString());
        }
    }

    public int Level
    {
        get
        {
            if (!PlayerPrefs.HasKey("Level"))
            {
                return 0;
            }

            string temporarylevel = PlayerPrefs.GetString("Level");

            return int.Parse(temporarylevel);
        }

        set
        {
            PlayerPrefs.SetString("Level", value.ToString());
        }
    }

    public float Bomb
    {
        get
        {
            if (!PlayerPrefs.HasKey("Bomb"))
            {
                return 0.0f;
            }

            string temporarybomb = PlayerPrefs.GetString("Bomb");

            return float.Parse(temporarybomb);
        }

        set
        {
            PlayerPrefs.SetString("Bomb", value.ToString());
        }
    }

    public bool AirRaid
    {
        get
        {
            if (!PlayerPrefs.HasKey("AirRaid"))
            {
                return false;
            }

            string temporaryairlaid = PlayerPrefs.GetString("AirRaid");

            return bool.Parse(temporaryairlaid);
        }

        set
        {
            PlayerPrefs.SetString("AirRaid", value.ToString());
        }
    }

    public bool Camera
    {
        get
        {
            if (!PlayerPrefs.HasKey("Camera"))
            {
                return false;
            }

            string temporarycamera = PlayerPrefs.GetString("Camera");

            return bool.Parse(temporarycamera);
        }

        set
        {
            PlayerPrefs.SetString("Camera", value.ToString());
        }
    }

    public bool Shake
    {
        get
        {
            if (!PlayerPrefs.HasKey("Shake"))
            {
                return false;
            }

            string temporaryshake = PlayerPrefs.GetString("Shake");

            return bool.Parse(temporaryshake);
        }

        set
        {
            PlayerPrefs.SetString("Shake", value.ToString());
        }
    }

    public bool TriggerI
    {
        get
        {
            if (!PlayerPrefs.HasKey("TriggerI"))
            {
                return false;
            }

            string temporarytriggeri = PlayerPrefs.GetString("TriggerI");

            return bool.Parse(temporarytriggeri);
        }

        set
        {
            PlayerPrefs.SetString("TriggerI", value.ToString());
        }
    }

    public bool TriggerII
    {
        get
        {
            if (!PlayerPrefs.HasKey("TriggerII"))
            {
                return false;
            }

            string temporarytriggerii = PlayerPrefs.GetString("TriggerII");

            return bool.Parse(temporarytriggerii);
        }

        set
        {
            PlayerPrefs.SetString("TriggerII", value.ToString());
        }
    }

    public bool TriggerIII
    {
        get
        {
            if (!PlayerPrefs.HasKey("TriggerIII"))
            {
                return false;
            }

            string temporarytriggeriii = PlayerPrefs.GetString("TriggerIII");

            return bool.Parse(temporarytriggeriii);
        }

        set
        {
            PlayerPrefs.SetString("TriggerIII", value.ToString());
        }
    }

    public bool TriggerIIII
    {
        get
        {
            if (!PlayerPrefs.HasKey("TriggerIIII"))
            {
                return false;
            }

            string temporarytriggeriiii = PlayerPrefs.GetString("TriggerIIII");

            return bool.Parse(temporarytriggeriiii);
        }

        set
        {
            PlayerPrefs.SetString("TriggerIIII", value.ToString());
        }
    }

    public bool TriggerV
    {
        get
        {
            if (!PlayerPrefs.HasKey("TriggerV"))
            {
                return false;
            }

            string temporarytriggerv = PlayerPrefs.GetString("TriggerV");

            return bool.Parse(temporarytriggerv);
        }

        set
        {
            PlayerPrefs.SetString("TriggerV", value.ToString());
        }
    }

    public bool TriggerVI
    {
        get
        {
            if (!PlayerPrefs.HasKey("TriggerVI"))
            {
                return false;
            }

            string temporarytriggervi = PlayerPrefs.GetString("TriggerVI");

            return bool.Parse(temporarytriggervi);
        }

        set
        {
            PlayerPrefs.SetString("TriggerVI", value.ToString());
        }
    }

    public bool PropellerI
    {
        get
        {
            if (!PlayerPrefs.HasKey("PropellerI"))
            {
                return false;
            }

            string temporarypropelleri = PlayerPrefs.GetString("PropellerI");

            return bool.Parse(temporarypropelleri);
        }

        set
        {
            PlayerPrefs.SetString("PropellerI", value.ToString());
        }
    }

    public bool PropellerII
    {
        get
        {
            if (!PlayerPrefs.HasKey("PropellerII"))
            {
                return false;
            }

            string temporarypropellerii = PlayerPrefs.GetString("PropellerII");

            return bool.Parse(temporarypropellerii);
        }

        set
        {
            PlayerPrefs.SetString("PropellerII", value.ToString());
        }
    }

    public bool PropellerIII
    {
        get
        {
            if (!PlayerPrefs.HasKey("PropellerIII"))
            {
                return false;
            }

            string temporarypropelleriii = PlayerPrefs.GetString("PropellerIII");

            return bool.Parse(temporarypropelleriii);
        }

        set
        {
            PlayerPrefs.SetString("PropellerIII", value.ToString());
        }
    }

    public bool PropellerIIII
    {
        get
        {
            if (!PlayerPrefs.HasKey("PropellerIIII"))
            {
                return false;
            }

            string temporarypropelleriiii = PlayerPrefs.GetString("PropellerIIII");

            return bool.Parse(temporarypropelleriiii);
        }

        set
        {
            PlayerPrefs.SetString("PropellerIIII", value.ToString());
        }
    }

    public bool Fire
    {
        get
        {
            if (!PlayerPrefs.HasKey("Fire"))
            {
                return false;
            }

            string temporaryfire = PlayerPrefs.GetString("Fire");

            return bool.Parse(temporaryfire);
        }

        set
        {
            PlayerPrefs.SetString("Fire", value.ToString());
        }
    }

    public bool Gondola
    {
        get
        {
            if (!PlayerPrefs.HasKey("FrontGondola"))
            {
                return false;
            }

            string temporaryfrontgondola = PlayerPrefs.GetString("FrontGondola");

            return bool.Parse(temporaryfrontgondola);
        }

        set
        {
            PlayerPrefs.SetString("FrontGondola", value.ToString());
        }
    }

    public bool AAI
    {
        get
        {
            if (!PlayerPrefs.HasKey("AAI"))
            {
                return false;
            }

            string temporaryaai = PlayerPrefs.GetString("AAI");

            return bool.Parse(temporaryaai);
        }

        set
        {
            PlayerPrefs.SetString("AAI", value.ToString());
        }
    }

    public bool AAII
    {
        get
        {
            if (!PlayerPrefs.HasKey("AAII"))
            {
                return false;
            }

            string temporaryaaii = PlayerPrefs.GetString("AAII");

            return bool.Parse(temporaryaaii);
        }

        set
        {
            PlayerPrefs.SetString("AAII", value.ToString());
        }
    }

    public bool AAIII
    {
        get
        {
            if (!PlayerPrefs.HasKey("AAIII"))
            {
                return false;
            }

            string temporaryaaii = PlayerPrefs.GetString("AAIII");

            return bool.Parse(temporaryaaii);
        }

        set
        {
            PlayerPrefs.SetString("AAIII", value.ToString());
        }
    }

    public bool AAIIII
    {
        get
        {
            if (!PlayerPrefs.HasKey("AAIIII"))
            {
                return false;
            }

            string temporaryaaiiii = PlayerPrefs.GetString("AAIIII");

            return bool.Parse(temporaryaaiiii);
        }

        set
        {
            PlayerPrefs.SetString("AAIIII", value.ToString());
        }
    }

    public bool AAV
    {
        get
        {
            if (!PlayerPrefs.HasKey("AAV"))
            {
                return false;
            }

            string temporaryaav = PlayerPrefs.GetString("AAV");

            return bool.Parse(temporaryaav);
        }

        set
        {
            PlayerPrefs.SetString("AAV", value.ToString());
        }
    }

    public bool AAVI
    {
        get
        {
            if (!PlayerPrefs.HasKey("AAVI"))
            {
                return false;
            }

            string temporaryaavi = PlayerPrefs.GetString("AAVI");

            return bool.Parse(temporaryaavi);
        }

        set
        {
            PlayerPrefs.SetString("AAVI", value.ToString());
        }
    }

    public bool AAVII
    {
        get
        {
            if (!PlayerPrefs.HasKey("AAVII"))
            {
                return false;
            }

            string temporaryaavii = PlayerPrefs.GetString("AAVII");

            return bool.Parse(temporaryaavii);
        }

        set
        {
            PlayerPrefs.SetString("AAVII", value.ToString());
        }
    }

    public bool AAVIII
    {
        get
        {
            if (!PlayerPrefs.HasKey("AAVIII"))
            {
                return false;
            }

            string temporaryaaviii = PlayerPrefs.GetString("AAVIII");

            return bool.Parse(temporaryaaviii);
        }

        set
        {
            PlayerPrefs.SetString("AAVIII", value.ToString());
        }
    }

    public bool AAIX
    {
        get
        {
            if (!PlayerPrefs.HasKey("AAIX"))
            {
                return false;
            }

            string temporaryaaix = PlayerPrefs.GetString("AAIX");

            return bool.Parse(temporaryaaix);
        }

        set
        {
            PlayerPrefs.SetString("AAIX", value.ToString());
        }
    }

    public bool AAX
    {
        get
        {
            if (!PlayerPrefs.HasKey("AAX"))
            {
                return false;
            }

            string temporaryaax = PlayerPrefs.GetString("AAX");

            return bool.Parse(temporaryaax);
        }

        set
        {
            PlayerPrefs.SetString("AAX", value.ToString());
        }
    }

    public bool AAXI
    {
        get
        {
            if (!PlayerPrefs.HasKey("AAXI"))
            {
                return false;
            }

            string temporaryaaxi = PlayerPrefs.GetString("AAXI");

            return bool.Parse(temporaryaaxi);
        }

        set
        {
            PlayerPrefs.SetString("AAXI", value.ToString());
        }
    }

    public bool AAXII
    {
        get
        {
            if (!PlayerPrefs.HasKey("AAXII"))
            {
                return false;
            }

            string temporaryaaxii = PlayerPrefs.GetString("AAXII");

            return bool.Parse(temporaryaaxii);
        }

        set
        {
            PlayerPrefs.SetString("AAXII", value.ToString());
        }
    }

    public bool AAXIII
    {
        get
        {
            if (!PlayerPrefs.HasKey("AAXIII"))
            {
                return false;
            }

            string temporaryaaxiii = PlayerPrefs.GetString("AAXIII");

            return bool.Parse(temporaryaaxiii);
        }

        set
        {
            PlayerPrefs.SetString("AAXIII", value.ToString());
        }
    }

    public bool AAXIV
    {
        get
        {
            if (!PlayerPrefs.HasKey("AAXIV"))
            {
                return false;
            }

            string temporaryaaxiv = PlayerPrefs.GetString("AAXIV");

            return bool.Parse(temporaryaaxiv);
        }

        set
        {
            PlayerPrefs.SetString("AAXIV", value.ToString());
        }
    }

    public bool AAXV
    {
        get
        {
            if (!PlayerPrefs.HasKey("AAXV"))
            {
                return false;
            }

            string temporaryaaxv = PlayerPrefs.GetString("AAXV");

            return bool.Parse(temporaryaaxv);
        }

        set
        {
            PlayerPrefs.SetString("AAXV", value.ToString());
        }
    }
    public bool AAXVI
    {
        get
        {
            if (!PlayerPrefs.HasKey("AAXVI"))
            {
                return false;
            }

            string temporaryaaxvi = PlayerPrefs.GetString("AAXVI");

            return bool.Parse(temporaryaaxvi);
        }

        set
        {
            PlayerPrefs.SetString("AAXVI", value.ToString());
        }
    }
    public bool AAXVII
    {
        get
        {
            if (!PlayerPrefs.HasKey("AAXVII"))
            {
                return false;
            }

            string temporaryaaxvii = PlayerPrefs.GetString("AAXVII");

            return bool.Parse(temporaryaaxvii);
        }

        set
        {
            PlayerPrefs.SetString("AAXVII", value.ToString());
        }
    }
    public bool AAXVIII
    {
        get
        {
            if (!PlayerPrefs.HasKey("AAXVIII"))
            {
                return false;
            }

            string temporaryaaxviii = PlayerPrefs.GetString("AAXVIII");

            return bool.Parse(temporaryaaxviii);
        }

        set
        {
            PlayerPrefs.SetString("AAXVIII", value.ToString());
        }
    }
}
