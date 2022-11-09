using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AA : MonoBehaviour
{
    AntiAircraft antiaircraft;

    void Start()
    {
        antiaircraft = GetComponentInParent<AntiAircraft>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("BULLET"))
        {
            antiaircraft.AADurability -= 1;
        }
    }
}
