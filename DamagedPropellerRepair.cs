using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagedPropellerRepair : MonoBehaviour
{
    Airship airship;
    UIPanel uipanel;
    CursorVisualEffect cursorvisualeffect;

    void Start()
    {
        airship = GameObject.Find("Airship").GetComponent<Airship>();
        uipanel = GameObject.Find("UI Panel").GetComponent <UIPanel>();
        cursorvisualeffect = GameObject.Find("You").GetComponent<CursorVisualEffect>();
    }

    void PropellerRepair()
    {
        for (int altitude = 0; altitude < 75; altitude++)
        {
            airship.AirshipDurability += 0.001f;
        }

        if (airship.AirshipDurability >= 0.3f)
        {
            uipanel.alarm = 1;
        }
    }

    public void PropellerReoperationI()
    {
        switch(TotalManagement.Instance.Merit)
        {
            case > 10:
                TotalManagement.Instance.Merit -= 10;
                TotalManagement.Instance.PropellerI = true;
                cursorvisualeffect.Operation = false;
                PropellerRepair();
                break;
            case < 10:
                uipanel.alarm = 2;
                break;
        }
    }

    public void PropellerReoperationII()
    {
        switch (TotalManagement.Instance.Merit)
        {
            case > 10:
                TotalManagement.Instance.Merit -= 10;
                TotalManagement.Instance.PropellerII = true;
                cursorvisualeffect.Operation = false;
                PropellerRepair();
                break;
            case < 10:
                uipanel.alarm = 2;
                break;
        }
    }

    public void PropellerReoperationIII()
    {
        switch (TotalManagement.Instance.Merit)
        {
            case > 10:
                TotalManagement.Instance.Merit -= 10;
                TotalManagement.Instance.PropellerIII = true;
                cursorvisualeffect.Operation = false;
                PropellerRepair();
                break;
            case < 10:
                uipanel.alarm = 2;
                break;
        }
    }

    public void PropellerReoperationIIII()
    {
        switch (TotalManagement.Instance.Merit)
        {
            case > 10:
                TotalManagement.Instance.Merit -= 10;
                TotalManagement.Instance.PropellerIIII = true;
                cursorvisualeffect.Operation = false;
                PropellerRepair();
                break;
            case < 10:
                uipanel.alarm = 2;
                break;
        }
    }

    public void GearinOperation()
    {
        cursorvisualeffect.Operation = true;
    }

    public void OutofService()
    {
        cursorvisualeffect.Operation = false;
    }
}
