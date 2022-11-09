using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class You : MonoBehaviour
{
    public GameObject machinegun;
    public GameObject AirBombOutline;

    public Button AirBomb;
    public Button FrontGondola;
    public Button RearGondola;
    public Button DamagedAirshipMaintenance;
    public Button FireExtinguisher;

    public Image BombPreparationVisualisation;

    public bool MachineguninOperation = false;

    public int TapCountI;
    public int TapCountII;
    public int TapCountIII;
    public int TapCountIIII;
    public int TapCountV;
    public int TapCountVI;

    public float MachinegunRotationSpeed = 0.0f;
    public float MachinegunRotationAxisY;
    public float MachinegunRotationAxisZ;

    public string MachineGunName;

    Airship airship;

    float MachinegunAngle;

    Color BombPreparationColourVisualisation;

    readonly float BombStandby = 60.0f;
    readonly Color BombPreparationColour = new Vector4(1.0f, 1.0f, 0.0f, 1.0f);

    void Start()
    {
        airship = GameObject.Find("Airship").GetComponent<Airship>();

        machinegun = null;

        TapCountI = 0;
        TapCountII = 0;
        TapCountIII = 0;
        TapCountIIII = 0;
        TapCountV = 0;
        TapCountVI = 0;

        TotalManagement.Instance.Bomb = 0.0f;
    }

    void Update()
    {
        switch (TotalManagement.Instance.PresentChronoState)
        {
            case O.One:
                StartCoroutine(Bombardment());
                StartCoroutine(Visualisation());
                StartCoroutine(AirshipMaintenance());
                StartCoroutine(AirshipFireExtinguisher());
                break;
            case O.Nought:
                StopAllCoroutines();
                if (TotalManagement.Instance.Bomb / BombStandby >= 1.0f)
                {
                    AirBomb.enabled = false;
                }
                if (TotalManagement.Instance.Gondola != false)
                {
                    FrontGondola.enabled = false;
                    RearGondola.enabled = false;
                }
                if (airship.AirshipDurability < 3.0f)
                {
                    DamagedAirshipMaintenance.enabled = false;
                }
                if (TotalManagement.Instance.Fire != false)
                {
                    FireExtinguisher.enabled = false;
                }
                break;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            O PresentOState = TotalManagement.Instance.PresentChronoState;
            O FutureOState = PresentOState == O.One 
                ? O.Nought 
                : O.One;

            TotalManagement.Instance.SetChronoState(FutureOState);
        }

        if (TapCountI == 3 || TapCountII == 3 || TapCountIII == 3 || TapCountIIII == 3 || TapCountV == 3 || TapCountVI == 3)
        {
            switch (MachinegunRotationAxisY)
            {
                case 0.0f:
                    MachinegunRotationAxisY = 180;
                    MachinegunRotationAxisZ = machinegun.transform.eulerAngles.z;
                    machinegun.transform.eulerAngles = new Vector3(0, MachinegunRotationAxisY, MachinegunRotationAxisZ);    
                    break;
                case 180.0f:
                    MachinegunRotationAxisY = 0;
                    MachinegunRotationAxisZ = machinegun.transform.eulerAngles.z;
                    machinegun.transform.eulerAngles = new Vector3(0, MachinegunRotationAxisY, MachinegunRotationAxisZ);
                    break;
            }

            switch (MachineGunName)
            {
                case "Front Gondola No. 1 Machine Gun":
                    TapCountI = 1;
                    break;
                case "Front Gondola No. 2 Machine Gun":
                    TapCountII = 1;
                    break;
                case "Rear Gondola No. 1 Machine Gun":
                    TapCountIII = 1;
                    break;
                case "Rear Gondola No. 2 Machine Gun":
                    TapCountIIII = 1;
                    break;
                case "Top Flatform No. 1 Machine Gun":
                    TapCountV = 1;
                    break;
                case "Top Flatform No. 2 Machine Gun":
                    TapCountVI = 1;
                    break;
            }
        }

        if (MachineguninOperation != false)
        {
            if (Input.GetMouseButton(1))
            {
                switch (MachineGunName)
                {
                    case "Front Gondola No. 1 Machine Gun":
                        if (TapCountI >= 0 || TapCountI <= 2)
                        {
                            MachinegunAngle = -Input.GetAxis("Mouse Y") * MachinegunRotationSpeed * Time.deltaTime;

                            MachinegunRotationAxisZ += MachinegunAngle;
                            MachinegunRotationAxisZ = Mathf.Clamp(MachinegunRotationAxisZ, 25, 90);

                            machinegun.transform.eulerAngles = new Vector3(0, MachinegunRotationAxisY, MachinegunRotationAxisZ);
                        }
                        break;
                    case "Front Gondola No. 2 Machine Gun":
                        if (TapCountII >= 0 || TapCountII <= 2)
                        {
                            MachinegunAngle = -Input.GetAxis("Mouse Y") * MachinegunRotationSpeed * Time.deltaTime;

                            MachinegunRotationAxisZ += MachinegunAngle;
                            MachinegunRotationAxisZ = Mathf.Clamp(MachinegunRotationAxisZ, 25, 90);

                            machinegun.transform.eulerAngles = new Vector3(0, MachinegunRotationAxisY, MachinegunRotationAxisZ);
                        }
                        break;
                    case "Rear Gondola No. 1 Machine Gun":
                        if (TapCountIII >= 0 || TapCountIII <= 2)
                        {
                            MachinegunAngle = -Input.GetAxis("Mouse Y") * MachinegunRotationSpeed * Time.deltaTime;

                            MachinegunRotationAxisZ += MachinegunAngle;
                            MachinegunRotationAxisZ = Mathf.Clamp(MachinegunRotationAxisZ, 25, 90);

                            machinegun.transform.eulerAngles = new Vector3(0, MachinegunRotationAxisY, MachinegunRotationAxisZ);
                        }
                        break;
                    case "Rear Gondola No. 2 Machine Gun":
                        if (TapCountIIII >= 0 || TapCountIIII <= 2)
                        {
                            MachinegunAngle = -Input.GetAxis("Mouse Y") * MachinegunRotationSpeed * Time.deltaTime;

                            MachinegunRotationAxisZ += MachinegunAngle;
                            MachinegunRotationAxisZ = Mathf.Clamp(MachinegunRotationAxisZ, 25, 90);

                            machinegun.transform.eulerAngles = new Vector3(0, MachinegunRotationAxisY, MachinegunRotationAxisZ);
                        }
                        break;
                    case "Top Flatform No. 1 Machine Gun":
                        if (TapCountV >= 0 || TapCountV <= 2)
                        {
                            MachinegunAngle = -Input.GetAxis("Mouse Y") * MachinegunRotationSpeed * Time.deltaTime;

                            MachinegunRotationAxisZ += MachinegunAngle;
                            MachinegunRotationAxisZ = Mathf.Clamp(MachinegunRotationAxisZ, 0, -90);

                            machinegun.transform.eulerAngles = new Vector3(0, MachinegunRotationAxisY, MachinegunRotationAxisZ);
                        }
                        break;
                    case "Top Flatform No. 2 Machine Gun":
                        if (TapCountVI >= 0 || TapCountVI <= 2)
                        {
                            MachinegunAngle = -Input.GetAxis("Mouse Y") * MachinegunRotationSpeed * Time.deltaTime;

                            MachinegunRotationAxisZ += MachinegunAngle;
                            MachinegunRotationAxisZ = Mathf.Clamp(MachinegunRotationAxisZ, 0, -90);

                            machinegun.transform.eulerAngles = new Vector3(0, MachinegunRotationAxisY, MachinegunRotationAxisZ);
                        }
                        break;
                }
            }
        }
    }

    IEnumerator Bombardment()
    {
        switch (TotalManagement.Instance.Gondola)
        {
            case true:
                AirBombOutline.gameObject.SetActive(true);
                FrontGondola.enabled = true;
                FrontGondola.interactable = true;
                RearGondola.enabled = true;
                RearGondola.interactable = true;
                break;
            case false:
                AirBombOutline.gameObject.SetActive(false);
                FrontGondola.enabled = false;
                FrontGondola.interactable = false;
                RearGondola.enabled = false;
                RearGondola.interactable = false;
                break;
        }

        if (TotalManagement.Instance.Bomb >= 60.0f)
        {
            TotalManagement.Instance.Bomb = 60.0f;
        }

        switch (TotalManagement.Instance.Bomb / BombStandby)
        {
            case >= 1.0f:
                AirBomb.enabled = true;
                AirBomb.interactable = true;
                break;
            case < 1.0f:
                AirBomb.enabled = false;
                AirBomb.interactable = false;
                break;
        }

        yield return new WaitForSeconds(0.02f);
    }

    IEnumerator Visualisation()
    {
        TotalManagement.Instance.Bomb += Time.deltaTime;

        BombPreparationVisualisation.color = BombPreparationColour;
        BombPreparationColourVisualisation = BombPreparationColour;

        float BombPreparationValue = TotalManagement.Instance.Bomb / BombStandby;

        switch (BombPreparationValue)
        {
            case >= 0.5f:
                BombPreparationColourVisualisation.r = (1 - (TotalManagement.Instance.Bomb / BombStandby)) * 2.0f;
                break;
            case < 0.5f:
                BombPreparationColourVisualisation.g = BombPreparationValue * 2.0f;
                break;
        }    

        BombPreparationVisualisation.color = BombPreparationColourVisualisation;
        BombPreparationVisualisation.fillAmount = BombPreparationValue;

        yield return new WaitForSeconds(0.02f);
    }

    IEnumerator AirshipMaintenance()
    {
        switch (airship.AirshipDurability)
        {
            case >= 0.3f:
                DamagedAirshipMaintenance.enabled = false;
                DamagedAirshipMaintenance.interactable = false;
                break;
            case < 0.3f:
                DamagedAirshipMaintenance.enabled = true;
                DamagedAirshipMaintenance.interactable = true;
                break;
        }

        yield return new WaitForSeconds(0.02f);
    }

    IEnumerator AirshipFireExtinguisher()
    {
        switch (TotalManagement.Instance.Fire)
        {
            case true:
                FireExtinguisher.enabled = true;
                FireExtinguisher.interactable = true;
                break;
            case false:
                FireExtinguisher.enabled = false;
                FireExtinguisher.interactable = false;
                break;
        }

        yield return new WaitForSeconds(0.02f);
    }
}
