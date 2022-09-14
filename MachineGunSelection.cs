using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineGunSelection : MonoBehaviour
{
    public GameObject SelectedMachineGunI;
    public GameObject SelectedMachineGunII;
    public GameObject SelectedMachineGunIII;
    public GameObject SelectedMachineGunIIII;
    public GameObject SelectedMachineGunV;
    public GameObject SelectedMachineGunVI;
    public GameObject MachineGunOutlineI;
    public GameObject MachineGunOutlineII;
    public GameObject MachineGunOutlineIII;
    public GameObject MachineGunOutlineIIII;
    public GameObject MachineGunOutlineV;
    public GameObject MachineGunOutlineVI;
    public GameObject MachineGunSelectionIndicatorI;
    public GameObject MachineGunSelectionIndicatorII;
    public GameObject MachineGunSelectionIndicatorIII;
    public GameObject MachineGunSelectionIndicatorIIII;
    public GameObject MachineGunSelectionIndicatorV;
    public GameObject MachineGunSelectionIndicatorIV;

    public float ImageAlphaValue = 0.1f;

    You you;
    CursorVisualEffect cursorvisualeffect;

    void Start()
    {
        you = GameObject.Find("You").GetComponent<You>();
        cursorvisualeffect = GameObject.Find("You").GetComponent<CursorVisualEffect>();

        this.GetComponent<Image>().alphaHitTestMinimumThreshold = ImageAlphaValue;

        MachineGunOutlineI.gameObject.SetActive(false);
        MachineGunOutlineII.gameObject.SetActive(false);
        MachineGunOutlineIII.gameObject.SetActive(false);
        MachineGunOutlineIIII.gameObject.SetActive(false);
        MachineGunSelectionIndicatorI.gameObject.SetActive(false);
        MachineGunSelectionIndicatorII.gameObject.SetActive(false);
        MachineGunSelectionIndicatorIII.gameObject.SetActive(false);
        MachineGunSelectionIndicatorIIII.gameObject.SetActive(false);
        MachineGunSelectionIndicatorV.gameObject.SetActive(false);
        MachineGunSelectionIndicatorIV.gameObject.SetActive(false);
    }

    public void MachineGunSelectionI()
    {
        you.machinegun = SelectedMachineGunI;
        you.MachineguninOperation = true;
        you.TapCountI += 1;
        you.TapCountII = 0;
        you.TapCountIII = 0;
        you.TapCountIIII = 0;
        you.TapCountV = 0;
        you.TapCountVI = 0;
        you.MachinegunRotationAxisY = SelectedMachineGunI.transform.eulerAngles.y;
        you.MachineGunName = "Front Gondola No. 1 Machine Gun";

        MachineGunOutlineI.gameObject.SetActive(true);
        MachineGunOutlineII.gameObject.SetActive(false);
        MachineGunOutlineIII.gameObject.SetActive(false);
        MachineGunOutlineIIII.gameObject.SetActive(false);
        MachineGunSelectionIndicatorI.gameObject.SetActive(true);
        MachineGunSelectionIndicatorII.gameObject.SetActive(false);
        MachineGunSelectionIndicatorIII.gameObject.SetActive(false);
        MachineGunSelectionIndicatorIIII.gameObject.SetActive(false);
        MachineGunSelectionIndicatorV.gameObject.SetActive(false);
        MachineGunSelectionIndicatorIV.gameObject.SetActive(false);
    }

    public void MachineGunSelectionII()
    {
        you.machinegun = SelectedMachineGunII;
        you.MachineguninOperation = true;
        you.TapCountI = 0;
        you.TapCountII += 1;
        you.TapCountIII = 0;
        you.TapCountIIII = 0;
        you.TapCountV = 0;
        you.TapCountVI = 0;
        you.MachinegunRotationAxisY = SelectedMachineGunII.transform.eulerAngles.y;
        you.MachineGunName = "Front Gondola No. 2 Machine Gun";

        MachineGunOutlineI.gameObject.SetActive(false);
        MachineGunOutlineII.gameObject.SetActive(true);
        MachineGunOutlineIII.gameObject.SetActive(false);
        MachineGunOutlineIIII.gameObject.SetActive(false);
        MachineGunSelectionIndicatorI.gameObject.SetActive(false);
        MachineGunSelectionIndicatorII.gameObject.SetActive(true);
        MachineGunSelectionIndicatorIII.gameObject.SetActive(false);
        MachineGunSelectionIndicatorIIII.gameObject.SetActive(false);
        MachineGunSelectionIndicatorV.gameObject.SetActive(false);
        MachineGunSelectionIndicatorIV.gameObject.SetActive(false);
    }

    public void MachineGunSelectionIII()
    {
        you.machinegun = SelectedMachineGunIII;
        you.MachineguninOperation = true;
        you.TapCountI = 0;
        you.TapCountII = 0;
        you.TapCountIII += 1;
        you.TapCountIIII = 0;
        you.TapCountV = 0;
        you.TapCountVI = 0;
        you.MachinegunRotationAxisY = SelectedMachineGunIII.transform.eulerAngles.y;
        you.MachineGunName = "Rear Gondola No. 1 Machine Gun";

        MachineGunOutlineI.gameObject.SetActive(false);
        MachineGunOutlineII.gameObject.SetActive(false);
        MachineGunOutlineIII.gameObject.SetActive(true);
        MachineGunOutlineIIII.gameObject.SetActive(false);
        MachineGunSelectionIndicatorI.gameObject.SetActive(false);
        MachineGunSelectionIndicatorII.gameObject.SetActive(false);
        MachineGunSelectionIndicatorIII.gameObject.SetActive(true);
        MachineGunSelectionIndicatorIIII.gameObject.SetActive(false);
        MachineGunSelectionIndicatorV.gameObject.SetActive(false);
        MachineGunSelectionIndicatorIV.gameObject.SetActive(false);
    }

    public void MachineGunSelectionIIII()
    {
        you.machinegun = SelectedMachineGunIIII;
        you.MachineguninOperation = true;
        you.TapCountI = 0;
        you.TapCountII = 0;
        you.TapCountIII = 0;
        you.TapCountIIII += 1;
        you.TapCountV = 0;
        you.TapCountVI = 0;
        you.MachinegunRotationAxisY = SelectedMachineGunIIII.transform.eulerAngles.y;
        you.MachineGunName = "Rear Gondola No. 2 Machine Gun";

        MachineGunOutlineI.gameObject.SetActive(false);
        MachineGunOutlineII.gameObject.SetActive(false);
        MachineGunOutlineIII.gameObject.SetActive(false);
        MachineGunOutlineIIII.gameObject.SetActive(true);
        MachineGunSelectionIndicatorI.gameObject.SetActive(false);
        MachineGunSelectionIndicatorII.gameObject.SetActive(false);
        MachineGunSelectionIndicatorIII.gameObject.SetActive(false);
        MachineGunSelectionIndicatorIIII.gameObject.SetActive(true);
        MachineGunSelectionIndicatorV.gameObject.SetActive(false);
        MachineGunSelectionIndicatorIV.gameObject.SetActive(false);
    }

    public void MachineGunSelectionV()
    {
        you.machinegun = SelectedMachineGunV;
        you.MachineguninOperation = true;
        you.TapCountI = 0;
        you.TapCountII = 0;
        you.TapCountIII = 0;
        you.TapCountIIII = 0;
        you.TapCountV += 1;
        you.TapCountVI = 0;
        you.MachinegunRotationAxisY = SelectedMachineGunV.transform.eulerAngles.y;
        you.MachineGunName = "Top Flatform No. 1 Machine Gun";

        MachineGunOutlineI.gameObject.SetActive(false);
        MachineGunOutlineII.gameObject.SetActive(false);
        MachineGunOutlineIII.gameObject.SetActive(false);
        MachineGunOutlineIIII.gameObject.SetActive(false);
        MachineGunSelectionIndicatorI.gameObject.SetActive(false);
        MachineGunSelectionIndicatorII.gameObject.SetActive(false);
        MachineGunSelectionIndicatorIII.gameObject.SetActive(false);
        MachineGunSelectionIndicatorIIII.gameObject.SetActive(false);
        MachineGunSelectionIndicatorV.gameObject.SetActive(true);
        MachineGunSelectionIndicatorIV.gameObject.SetActive(false);
    }

    public void MachineGunSelectionVI()
    {
        you.machinegun = SelectedMachineGunVI;
        you.MachineguninOperation = true;
        you.TapCountI = 0;
        you.TapCountII = 0;
        you.TapCountIII = 0;
        you.TapCountIIII = 0;
        you.TapCountV = 0;
        you.TapCountVI += 1;
        you.MachinegunRotationAxisY = SelectedMachineGunVI.transform.eulerAngles.y;
        you.MachineGunName = "Top Flatform No. 2 Machine Gun";

        MachineGunOutlineI.gameObject.SetActive(false);
        MachineGunOutlineII.gameObject.SetActive(false);
        MachineGunOutlineIII.gameObject.SetActive(false);
        MachineGunOutlineIIII.gameObject.SetActive(false);
        MachineGunSelectionIndicatorI.gameObject.SetActive(false);
        MachineGunSelectionIndicatorII.gameObject.SetActive(false);
        MachineGunSelectionIndicatorIII.gameObject.SetActive(false);
        MachineGunSelectionIndicatorIIII.gameObject.SetActive(false);
        MachineGunSelectionIndicatorV.gameObject.SetActive(false);
        MachineGunSelectionIndicatorIV.gameObject.SetActive(true);
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
