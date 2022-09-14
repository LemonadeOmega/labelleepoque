using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirShipMaintenance : MonoBehaviour
{
    Airship airship;
    AirPocket airpocket;
    UIPanel uipanel;
    CursorVisualEffect cursorvisualeffect;

    void Start()
    {
        airship = GameObject.Find("Airship").GetComponent<Airship>();
        airpocket = GameObject.FindWithTag("HYDROGEN").GetComponent<AirPocket>();
        uipanel = GameObject.Find("UI Panel").GetComponent <UIPanel>();
        cursorvisualeffect = GameObject.Find("You").GetComponent<CursorVisualEffect>();
    }

    public void Maintenance()
    {
        switch (airship.AirshipDurability)
        {
            case >= 0.3f:
                uipanel.alarm = 1;
                cursorvisualeffect.Operation = false;
                break;
            case < 0.3f:
                switch (TotalManagement.Instance.Merit)
                {
                    case > 1:
                        TotalManagement.Instance.Merit -= 1;
                        for (int Altitude = 0; Altitude < 6; Altitude++)
                        {
                            airship.AirshipDurability += 0.001f;
                        }
                        if (airship.AirshipDurability >= 0.3f)
                        {
                            uipanel.alarm = 1;
                            cursorvisualeffect.Operation = false;
                        }
                        break;
                    case < 1:
                        uipanel.alarm = 2;
                        break;
                }
                break;
        }
    }

    public void FireExtinguisher()
    {
        foreach (ParticleSystem Smoke in airship.Smokes)
        {
            Smoke.Stop();

            if (Smoke.gameObject.activeSelf == true)
            {
                switch (airpocket.DamagedAirPocket)
                {
                    case 0:
                        TotalManagement.Instance.Merit -= 100;
                        break;
                    case 1:
                        TotalManagement.Instance.Merit -= 200;
                        break;
                    case 2:
                        TotalManagement.Instance.Merit -= 300;
                        break;
                    case 3:
                        TotalManagement.Instance.Merit -= 400;
                        break;
                }

                Smoke.gameObject.SetActive(false);
            }
        }

        TotalManagement.Instance.Fire = false;
        cursorvisualeffect.Operation = false;
    }

    public void GearinOperation()
    {
        switch (this.gameObject.name)
        {
            case "Airship Maintenance":
                switch (airship.AirshipDurability)
                {
                    case >= 0.3f:
                        cursorvisualeffect.Operation = false;
                        break;
                    case < 0.3f:
                        cursorvisualeffect.Operation = true;
                        break;
                }
                break;
            case "Fire Extinguisher":
                switch (TotalManagement.Instance.Fire)
                {
                    case true:
                        cursorvisualeffect.Operation = true;
                        break;
                    case false:
                        cursorvisualeffect.Operation = false;
                        break;
                }
                break;
        }
    }

    public void OutofService()
    {
        cursorvisualeffect.Operation = false;
    }
}
