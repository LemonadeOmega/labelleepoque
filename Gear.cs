using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    CursorVisualEffect cursorvisualeffect;

    void Start()
    {
        cursorvisualeffect = GameObject.Find("You").GetComponent<CursorVisualEffect>();
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
