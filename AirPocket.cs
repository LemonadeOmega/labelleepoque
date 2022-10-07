using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AirPocket : MonoBehaviour
{
    public GameObject ExplosionEffect;

    public int DamagedAirPocket;

    public int[] AirshipFire;

    Airship airship;
    CameraShake camerashake;

    void Start()
    {
        airship = GameObject.Find("Airship").GetComponent<Airship>();
        camerashake = GameObject.Find("Main Camera").GetComponent<CameraShake>();

        AirshipFire = Enumerable.Range(0, 100).ToArray();

        foreach (ParticleSystem Smoke in airship.Smokes)
        {
            Smoke.gameObject.SetActive(false);
        }

        StartCoroutine(CameraShakeOperation());
        StartCoroutine(AirshiponFire());
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("AASHELL"))
        {
            switch (this.gameObject.tag)
            {
                case "AIRPOCKET":
                    TotalManagement.Instance.Camera = true;
                    TotalManagement.Instance.Shake = false;
                    Instantiate(ExplosionEffect, this.transform.position, Quaternion.identity);
                    for (int Altitude = 0; Altitude < 6; Altitude++)
                    {
                        airship.AirshipDurability -= 0.001f;
                    }
                    this.gameObject.SetActive(false);
                    break;
                case "HYDROGEN":
                    TotalManagement.Instance.Camera = true;
                    TotalManagement.Instance.Shake = true;
                    Instantiate(ExplosionEffect, this.transform.position, Quaternion.identity);
                    for (int Altitude = 0; Altitude < 18; Altitude++)
                    {
                        airship.AirshipDurability -= 0.001f;
                    }
                    switch (TotalManagement.Instance.Fire)
                    {
                        case true:
                            StopCoroutine(AirPocketFire());
                            break;
                        case false:
                            StartCoroutine(AirPocketFire());
                            break;
                    }
                    break;
            }
        }
    }

    IEnumerator CameraShakeOperation()
    {
        while (true)
        {
            switch (TotalManagement.Instance.Camera)
            {
                case true:
                    switch (TotalManagement.Instance.Shake)
                    {
                        case true:
                            StartCoroutine(camerashake.Shake(0.03f, 0.039f));
                            break;
                        case false:
                            StartCoroutine(camerashake.Shake(0.03f, 0.03f));
                            break;
                    }
                    break;
                case false:
                    switch (TotalManagement.Instance.Shake)
                    {
                        case true:
                            StopCoroutine(camerashake.Shake(0.03f, 0.039f));
                            break;
                        case false:
                            StopCoroutine(camerashake.Shake(0.03f, 0.03f));
                            break;
                    }
                    break;
            }

            yield return null;
        }
    }

    IEnumerator AirshiponFire()
    {
        while (true)
        {
            if (TotalManagement.Instance.Fire != false)
            {
                airship.AirshipDurability -= 0.001f;

            }

            yield return new WaitForSeconds(1.0f);
        }
    }

    void Smoke()
    {
        DamagedAirPocket = Random.Range(0, 4);

        switch (DamagedAirPocket)
        {
            case 0:
                for (int AirPocketSmokeCount = 0; AirPocketSmokeCount < 1; AirPocketSmokeCount++)
                {
                    int AirPocketSmoke = Random.Range(0, 58);

                    airship.Smokes[AirPocketSmoke].gameObject.SetActive(true);
                    airship.Smokes[AirPocketSmoke].Play();
                }
                break;
            case 1:
                for (int AirPocketSmokeCount = 0; AirPocketSmokeCount < 2; AirPocketSmokeCount++)
                {
                    int AirPocketSmoke = Random.Range(0, 58);

                    airship.Smokes[AirPocketSmoke].gameObject.SetActive(true);
                    airship.Smokes[AirPocketSmoke].Play();
                }
                break;
            case 2:
                for (int AirPocketSmokeCount = 0; AirPocketSmokeCount < 3; AirPocketSmokeCount++)
                {
                    int AirPocketSmoke = Random.Range(0, 58);

                    airship.Smokes[AirPocketSmoke].gameObject.SetActive(true);
                    airship.Smokes[AirPocketSmoke].Play();
                }
                break;
            case 3:
                for (int AirPocketSmokeCount = 0; AirPocketSmokeCount < 4; AirPocketSmokeCount++)
                {
                    int AirPocketSmoke = Random.Range(0, 58);

                    airship.Smokes[AirPocketSmoke].gameObject.SetActive(true);
                    airship.Smokes[AirPocketSmoke].Play();
                }
                break;
        }
    }

    IEnumerator AirPocketFire()
    {
        for (int AirshipFireRate = 0; AirshipFireRate < 100; AirshipFireRate++)
        {
            int TemporaryAirshipFireRate = Random.Range(0, 100);

            int TemporaryFire = AirshipFire[TemporaryAirshipFireRate];
            AirshipFire[TemporaryAirshipFireRate] = AirshipFire[AirshipFireRate];
            AirshipFire[AirshipFireRate] = TemporaryFire;
        }

        if (AirshipFire[0] == 1 || AirshipFire[0] == 2 || AirshipFire[0] == 3 || AirshipFire[0] == 4 ||
            AirshipFire[0] == 14 || AirshipFire[0] == 24 || AirshipFire[0] == 34 || AirshipFire[0] == 44 ||
            AirshipFire[0] == 54 || AirshipFire[0] == 64 || AirshipFire[0] == 74 || AirshipFire[0] == 84 ||
            AirshipFire[0] == 16 || AirshipFire[0] == 26 || AirshipFire[0] == 36 || AirshipFire[0] == 46 ||
            AirshipFire[0] == 56 || AirshipFire[0] == 66 || AirshipFire[0] == 76 || AirshipFire[0] == 86 ||
            AirshipFire[0] == 96 || AirshipFire[0] == 97 || AirshipFire[0] == 98 || AirshipFire[0] == 99)
        {
            if (AirshipFire[1] == 1 || AirshipFire[1] == 2 || AirshipFire[1] == 3 || AirshipFire[1] == 4 ||
                AirshipFire[1] == 14 || AirshipFire[1] == 24 || AirshipFire[1] == 34 || AirshipFire[1] == 44 ||
                AirshipFire[1] == 54 || AirshipFire[1] == 64 || AirshipFire[1] == 74 || AirshipFire[1] == 84 ||
                AirshipFire[1] == 16 || AirshipFire[1] == 26 || AirshipFire[1] == 36 || AirshipFire[1] == 46 ||
                AirshipFire[1] == 56 || AirshipFire[1] == 66 || AirshipFire[1] == 76 || AirshipFire[1] == 86 ||
                AirshipFire[1] == 96 || AirshipFire[1] == 97 || AirshipFire[1] == 98 || AirshipFire[1] == 99)
            {
                if (AirshipFire[2] == 1 || AirshipFire[2] == 2 || AirshipFire[2] == 3 || AirshipFire[2] == 4 ||
                    AirshipFire[2] == 14 || AirshipFire[2] == 24 || AirshipFire[2] == 34 || AirshipFire[2] == 44 ||
                    AirshipFire[2] == 54 || AirshipFire[2] == 64 || AirshipFire[2] == 74 || AirshipFire[2] == 84 ||
                    AirshipFire[2] == 16 || AirshipFire[2] == 26 || AirshipFire[2] == 36 || AirshipFire[2] == 46 ||
                    AirshipFire[2] == 56 || AirshipFire[2] == 66 || AirshipFire[2] == 76 || AirshipFire[2] == 86 ||
                    AirshipFire[2] == 96 || AirshipFire[2] == 97 || AirshipFire[2] == 98 || AirshipFire[2] == 99)
                {
                    if (AirshipFire[3] == 1 || AirshipFire[3] == 2 || AirshipFire[3] == 3 || AirshipFire[3] == 4 ||
                        AirshipFire[3] == 14 || AirshipFire[3] == 24 || AirshipFire[3] == 34 || AirshipFire[3] == 44 ||
                        AirshipFire[3] == 54 || AirshipFire[3] == 64 || AirshipFire[3] == 74 || AirshipFire[3] == 84 ||
                        AirshipFire[3] == 16 || AirshipFire[3] == 26 || AirshipFire[3] == 36 || AirshipFire[3] == 46 ||
                        AirshipFire[3] == 56 || AirshipFire[3] == 66 || AirshipFire[3] == 76 || AirshipFire[3] == 86 ||
                        AirshipFire[3] == 96 || AirshipFire[3] == 97 || AirshipFire[3] == 98 || AirshipFire[3] == 99)
                    {
                        Smoke();
                        TotalManagement.Instance.Fire = true;
                    }
                }
            }
        }

        yield return null;
    }
}
