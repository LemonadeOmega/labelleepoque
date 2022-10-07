using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airship : MonoBehaviour
{
    public float AirshipDurability = 0.3f;
    public float Chronometre;

    public bool PropellerinOperation;

    [Header("기낭")]
    public GameObject[] AirPockets;

    [Header("수소")]
    public GameObject[] Hydrogens;

    [Header("매연")]
    public ParticleSystem[] Smokes;

    UIPanel uipanel;
    CameraShake camerashake;

    void Start()
    {
        uipanel = GameObject.Find("UI Panel").GetComponent<UIPanel>();
        camerashake = GameObject.Find("Main Camera").GetComponent<CameraShake>();

        PropellerinOperation = true;
    }

    void Update()
    {
        if (AirshipDurability > 0.3f)
        {
            AirshipDurability = 0.3f;
        }

        if (AirshipDurability < -0.3f)
        {
            AirshipDurability = -0.3f;
        }

        foreach (GameObject AirPocket in AirPockets)
        {
            if (AirPocket.gameObject.activeSelf != true)
            {
                Chronometre += Time.deltaTime;

                if (TotalManagement.Instance.Camera != false)
                {
                    StartCoroutine(camerashake.Shake(0.03f, 0.03f));
                }

                if (Chronometre >= 3)
                {
                    AirPocket.gameObject.SetActive(true);

                    Chronometre = 0;
                }
            }
        }

        if (TotalManagement.Instance.Fire != false)
        {
            uipanel.alarm = 4;
        }

        StartCoroutine(AirshipAltitude());
    }

    IEnumerator AirshipAltitude()
    {
        while (TotalManagement.Instance.AirRaid != false)
        {
            Vector3 AirshipOriginalAltitude = this.transform.position;
            Vector3 AirshipSetAltitude = new Vector3(0.0f, AirshipDurability, 0.0f);

            float present = 0.0f;
            float future = 0.3f;
            float elapsedrate = present / future;

            while (elapsedrate < 1.0f)
            {
                present += Time.deltaTime;
                elapsedrate = present / future;

                this.transform.position = Vector3.Lerp(AirshipOriginalAltitude, AirshipSetAltitude, elapsedrate);

                AirshipOriginalAltitude = this.transform.position;
            }

            yield return null;
        }
    }
}
