using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirBomb : MonoBehaviour
{
    public GameObject airbomb;

    public Transform AirBombDropI;
    public Transform AirBombDropII;

    public float ImageAlphaValue = 0.1f;

    Rigidbody rigidbody;

    CursorVisualEffect cursorvisualeffect;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        cursorvisualeffect = GameObject.Find("You").GetComponent<CursorVisualEffect>();

        this.GetComponent<Image>().alphaHitTestMinimumThreshold = ImageAlphaValue;
    }

    public void BombAirDrop()
    {
        TotalManagement.Instance.Gondola = true;
    }

    public void NumberOneGondola()
    {
        Instantiate(airbomb, AirBombDropI.position, AirBombDropI.rotation);

        TotalManagement.Instance.Bomb = 0.0f;
        TotalManagement.Instance.Gondola = false;

        cursorvisualeffect.Operation = false;
    }

    public void NumberTwoGondola()
    {
        Instantiate(airbomb, AirBombDropII.position, AirBombDropII.rotation);

        TotalManagement.Instance.Bomb = 0.0f;
        TotalManagement.Instance.Gondola = false;

        cursorvisualeffect.Operation = false;
    }

    public void GearinOperation()
    {
        switch (this.gameObject.name)
        {
            case "Air Bomb":
                switch (TotalManagement.Instance.Bomb)
                {
                    case >= 60.0f:
                        cursorvisualeffect.Operation = true;
                        break;
                    case < 60.0f:
                        cursorvisualeffect.Operation = false;
                        break;
                }
                break;
            case "Gondola 1":
                switch (TotalManagement.Instance.Gondola)
                {
                    case true:
                        cursorvisualeffect.Operation = true;
                        break;
                    case false:
                        cursorvisualeffect.Operation = false;
                        break;
                }
                break;
            case "Gondola 2":
                switch (TotalManagement.Instance.Gondola)
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
