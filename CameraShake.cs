using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Camera camera;

    Vector3 OriginalCameraPosition;

    void Start()
    {
        camera = Camera.main;

        OriginalCameraPosition = camera.transform.localPosition;
    }

    public IEnumerator Shake(float elapsedtime, float magnitude)
    {
        float present = 0.0f;

        while (present <= elapsedtime)
        {
            present += Time.deltaTime;

            camera.transform.localPosition = Random.insideUnitSphere * magnitude + OriginalCameraPosition;

            yield return null;
        }

        camera.transform.localPosition = OriginalCameraPosition;
            
        TotalManagement.Instance.Camera = false;
    }
}
