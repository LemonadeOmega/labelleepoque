using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Airship : MonoBehaviour
{
    public Text Triumph;

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

        Triumph.gameObject.SetActive(false);

        PropellerinOperation = true;
    }

    void Update()
    {
        StartCoroutine(AirPocketActivation());

        switch (AirshipDurability)
        {
            case > 0.3f:
                AirshipDurability = 0.3f;
                break;
            case < -0.3f:
                AirshipDurability = -0.3f;
                break;
        }

        switch (TotalManagement.Instance.AirRaid)
        {
            case true:
                if (TotalManagement.Instance.AAI != true && TotalManagement.Instance.AAII != true && TotalManagement.Instance.AAIII != true && TotalManagement.Instance.AAIIII != true && 
                    TotalManagement.Instance.AAV != true && TotalManagement.Instance.AAVI != true && TotalManagement.Instance.AAVII != true && TotalManagement.Instance.AAVIII != true && 
                    TotalManagement.Instance.AAIX != true && TotalManagement.Instance.AAX != true && TotalManagement.Instance.AAXI != true && TotalManagement.Instance.AAXII != true &&
                    TotalManagement.Instance.AAXIII != true)
                {
                    Triumph.gameObject.SetActive(true);
                }
                break;
            case false:
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
                break;
        }

        if (TotalManagement.Instance.Fire != false)
        {
            uipanel.alarm = 4;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("AIRSHIPFALL"))
        {
            Debug.Log("Defeat");
        }
    }

    IEnumerator AirPocketActivation()
    {
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

                    yield return new WaitForSeconds(0.02f);
                }
            }
        }
    }
}
