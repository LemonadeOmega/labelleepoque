using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunIndicator : MonoBehaviour
{
    public float MachineGunIndicatorAnimationSpeed;

    float SinValue;

    void Awake()
    {
        MachineGunIndicatorAnimationSpeed = 0.001f;
    }

    void OnEnable()
    {
        StartCoroutine(MachineGunIndicatorAnimation());
    }

    IEnumerator MachineGunIndicatorAnimation()
    {
        while (true)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -1.0f);

            float MachineGunIndicator = Mathf.Sin(SinValue);

            SinValue += 0.1f;

            Vector3 MGIndicator = this.transform.position;

            MGIndicator.y += MachineGunIndicator * MachineGunIndicatorAnimationSpeed;

            this.transform.position = MGIndicator;

            yield return null;
        }
    }
}
