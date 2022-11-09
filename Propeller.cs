using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    public GameObject PropellerColliderOperation;
    public GameObject PropellerRepair;

    UIPanel uipanel;
    CameraShake camerashake;

    float RotationSpeed = 25.1f;

    void Start()
    {
        uipanel = GameObject.Find("UI Panel").GetComponent<UIPanel>();
        camerashake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
    }

    void Update()
    {
        switch (this.gameObject.name)
        {
            case "Propeller 1":
                switch (TotalManagement.Instance.PropellerI)
                {
                    case true:
                        PropellerColliderOperation.gameObject.SetActive(true);
                        PropellerRepair.gameObject.SetActive(false);
                        StartCoroutine(PropellerinOperation());
                        break;
                    case false:
                        PropellerColliderOperation.gameObject.SetActive(false);
                        PropellerRepair.gameObject.SetActive(true);
                        StopCoroutine(PropellerinOperation());
                        uipanel.alarm = 3;
                        break;
                }
                break;
            case "Propeller 2":
                switch (TotalManagement.Instance.PropellerII)
                {
                    case true:
                        PropellerColliderOperation.gameObject.SetActive(true);
                        PropellerRepair.gameObject.SetActive(false);
                        StartCoroutine(PropellerinOperation());
                        break;
                    case false:
                        PropellerColliderOperation.gameObject.SetActive(false);
                        PropellerRepair.gameObject.SetActive(true);
                        StopCoroutine(PropellerinOperation());
                        uipanel.alarm = 3;
                        break;
                }
                break;
            case "Propeller 3":
                switch (TotalManagement.Instance.PropellerIII)
                {
                    case true:
                        PropellerColliderOperation.gameObject.SetActive(true);
                        PropellerRepair.gameObject.SetActive(false);
                        StartCoroutine(PropellerinOperation());
                        break;
                    case false:
                        PropellerColliderOperation.gameObject.SetActive(false);
                        PropellerRepair.gameObject.SetActive(true);
                        StopCoroutine(PropellerinOperation());
                        uipanel.alarm = 3;
                        break;
                }
                break;
            case "Propeller 4":
                switch (TotalManagement.Instance.PropellerIIII)
                {
                    case true:
                        PropellerColliderOperation.gameObject.SetActive(true);
                        PropellerRepair.gameObject.SetActive(false);
                        StartCoroutine(PropellerinOperation());
                        break;
                    case false:
                        PropellerColliderOperation.gameObject.SetActive(false);
                        PropellerRepair.gameObject.SetActive(true);
                        StopCoroutine(PropellerinOperation());
                        uipanel.alarm = 3;
                        break;
                }
                break;
        }

        switch (TotalManagement.Instance.Camera)
        {
            case true:
                StartCoroutine(camerashake.Shake(0.03f, 0.039f));
                break;
            case false:
                StopCoroutine(camerashake.Shake(0.03f, 0.039f));
                break;
        }
    }

    IEnumerator PropellerinOperation()
    {
        this.transform.Rotate(new Vector3(90.0f, 0.0f, 0.0f) * RotationSpeed * Time.deltaTime);

        yield return new WaitForSeconds(0.02f);
    }
}
