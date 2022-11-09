using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reloading : MonoBehaviour
{
    public Button AmmunitionController;

    public float ImageAlphaValue = 0.1f;

    CursorVisualEffect cursorvisualeffect;

    void Start()
    {
        cursorvisualeffect = GameObject.Find("You").GetComponent<CursorVisualEffect>();

        this.GetComponent<Image>().alphaHitTestMinimumThreshold = ImageAlphaValue;

        StartCoroutine(AmmunitionControllerChrono());
    }

    IEnumerator AmmunitionControllerChrono()
    {
        while (true)
        {
            switch (TotalManagement.Instance.PresentChronoState)
            {
                case O.One:
                    switch (this.gameObject.name)
                    {
                        case "Reloading 1":
                            if (TotalManagement.Instance.TriggerI != true)
                            {
                                AmmunitionController.enabled = true;
                            }
                            break;
                        case "Reloading 2":
                            if (TotalManagement.Instance.TriggerII != true)
                            {
                                AmmunitionController.enabled = true;
                            }
                            break;
                        case "Reloading 3":
                            if (TotalManagement.Instance.TriggerIII != true)
                            {
                                AmmunitionController.enabled = true;
                            }
                            break;
                        case "Reloading 4":
                            if (TotalManagement.Instance.TriggerIIII != true)
                            {
                                AmmunitionController.enabled = true;
                            }
                            break;
                    }
                    break;
                case O.Nought:
                    AmmunitionController.enabled = false;
                    break;
            }

            yield return null;
        }
    }

    public void MachineGunReloadingI()
    {
        TotalManagement.Instance.TriggerI = true;
    }

    public void MachineGunReloadingII()
    {
        TotalManagement.Instance.TriggerII = true;
        cursorvisualeffect.Operation = false;
    }

    public void MachineGunReloadingIII()
    {
        TotalManagement.Instance.TriggerIII = true;
        cursorvisualeffect.Operation = false;
    }

    public void MachineGunReloadingIIII()
    {
        TotalManagement.Instance.TriggerIIII = true;
        cursorvisualeffect.Operation = false;
    }

    public void MachineGunReloadingV()
    {
        TotalManagement.Instance.TriggerIIII = true;
        cursorvisualeffect.Operation = false;
    }

    public void MachineGunReloadingVI()
    {
        TotalManagement.Instance.TriggerIIII = true;
        cursorvisualeffect.Operation = false;
    }

    public void GearinOperation()
    {
        switch (this.gameObject.name)
        {
            case "Reloading 1":
                switch (TotalManagement.Instance.TriggerI)
                {
                    case true:
                        cursorvisualeffect.Operation = false;
                        break;
                    case false:
                        cursorvisualeffect.Operation = true;
                        break;
                }
                break;
            case "Reloading 2":
                switch (TotalManagement.Instance.TriggerII)
                {
                    case true:
                        cursorvisualeffect.Operation = false;
                        break;
                    case false:
                        cursorvisualeffect.Operation = true;
                        break;
                }
                break;
            case "Reloading 3":
                switch (TotalManagement.Instance.TriggerIII)
                {
                    case true:
                        cursorvisualeffect.Operation = false;
                        break;
                    case false:
                        cursorvisualeffect.Operation = true;
                        break;
                }
                break;
            case "Reloading 4":
                switch (TotalManagement.Instance.TriggerIIII)
                {
                    case true:
                        cursorvisualeffect.Operation = false;
                        break;
                    case false:
                        cursorvisualeffect.Operation = true;
                        break;
                }
                break;
            case "Reloading 5":
                switch (TotalManagement.Instance.TriggerIIII)
                {
                    case true:
                        cursorvisualeffect.Operation = false;
                        break;
                    case false:
                        cursorvisualeffect.Operation = true;
                        break;
                }
                break;
            case "Reloading 6":
                switch (TotalManagement.Instance.TriggerIIII)
                {
                    case true:
                        cursorvisualeffect.Operation = false;
                        break;
                    case false:
                        cursorvisualeffect.Operation = true;
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
