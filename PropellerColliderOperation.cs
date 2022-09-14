using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerColliderOperation : MonoBehaviour
{
    public GameObject ExplosionEffect;

    Airship airship;

    void Start()
    {
        airship = GameObject.Find("Airship").GetComponent<Airship>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("AASHELL"))
        {
            switch (this.gameObject.name)
            {
                case "Propeller Collider 1":
                    Instantiate(ExplosionEffect, this.transform.position, Quaternion.identity);
                    for (int Altitude = 0; Altitude < 75; Altitude++)
                    {
                        airship.AirshipDurability -= 0.001f;
                    }
                    TotalManagement.Instance.Camera = true;
                    TotalManagement.Instance.PropellerI = false;
                    break;
                case "Propeller Collider 2":
                    Instantiate(ExplosionEffect, this.transform.position, Quaternion.identity);
                    for (int Altitude = 0; Altitude < 75; Altitude++)
                    {
                        airship.AirshipDurability -= 0.001f;
                    }
                    TotalManagement.Instance.Camera = true;
                    TotalManagement.Instance.PropellerII = false;
                    break;
                case "Propeller Collider 3":
                    Instantiate(ExplosionEffect, this.transform.position, Quaternion.identity);
                    for (int Altitude = 0; Altitude < 75; Altitude++)
                    {
                        airship.AirshipDurability -= 0.001f;
                    }
                    TotalManagement.Instance.Camera = true;
                    TotalManagement.Instance.PropellerIII = false;
                    break;
                case "Propeller Collider 4":
                    Instantiate(ExplosionEffect, this.transform.position, Quaternion.identity);
                    for (int Altitude = 0; Altitude < 75; Altitude++)
                    {
                        airship.AirshipDurability -= 0.001f;
                    }
                    TotalManagement.Instance.Camera = true;
                    TotalManagement.Instance.PropellerIIII = false;
                    break;
            }
        }
    }
}
