using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform PropellerCanvasI;
    public Transform PropellerCanvasII;
    public Transform PropellerCanvasIII;
    public Transform PropellerCanvasIIII;

    void Update()
    {
        PropellerCanvasI.forward = Camera.main.transform.forward;
        PropellerCanvasII.forward = Camera.main.transform.forward;
        PropellerCanvasIII.forward = Camera.main.transform.forward;
        PropellerCanvasIIII.forward = Camera.main.transform.forward;
    }
}
