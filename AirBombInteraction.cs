using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBombInteraction : MonoBehaviour
{
    public GameObject AAShellExplosion;
    public GameObject ChainExplosionEffect;

    [Header("¿¬¼â Æø¹ß ¿ÞÂÊ")]
    public Transform[] ChainExplosionLeft;

    [Header("¿¬¼â Æø¹ß ¿À¸¥ÂÊ")]
    public Transform[] ChainExplosionRight;

    int ChainExplosionOrder;

    float Chronometre;

    bool ChainExplosion;

    void Start()
    {
        ChainExplosion = false;

        ChainExplosionOrder = 0;
    }

    void Update()
    {
        switch (this.gameObject.name)
        {
            case "Front Gondola Air Bomb Interaction":
                AirBombExplosionOperationI();
                break;
            case "Rear Gondola Air Bomb Interaction":
                AirBombExplosionOperationII();
                break;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("AIRBOMB"))
        {
            Destroy(collider.gameObject);

            Collider[] AirBombEffect = Physics.OverlapSphere(this.transform.position, 4, 1 << 7);

            foreach (var AA in AirBombEffect)
            {
                if (AA.gameObject.CompareTag("ANTIAIRCRAFT"))
                {
                    switch (AA.gameObject.name)
                    {
                        case "AA 1":
                            TotalManagement.Instance.AAI = false;
                            break;
                        case "AA 2":
                            TotalManagement.Instance.AAII = false;
                            break;
                        case "AA 3":
                            TotalManagement.Instance.AAIII = false;
                            break;
                        case "AA 4":
                            TotalManagement.Instance.AAIIII = false;
                            break;
                        case "AA 5":
                            TotalManagement.Instance.AAV = false;
                            break;
                        case "AA 6":
                            TotalManagement.Instance.AAVI = false;
                            break;
                        case "AA 7":
                            TotalManagement.Instance.AAVII = false;
                            break;
                        case "AA 8":
                            TotalManagement.Instance.AAVIII = false;
                            break;
                        case "AA 9":
                            TotalManagement.Instance.AAIX = false;
                            break;
                        case "AA 10":
                            TotalManagement.Instance.AAX = false;
                            break;
                        case "AA 11":
                            TotalManagement.Instance.AAXI = false;
                            break;
                        case "AA 12":
                            TotalManagement.Instance.AAXII = false;
                            break;
                        case "AA 13":
                            TotalManagement.Instance.AAXIII = false;
                            break;
                        case "AA 14":
                            TotalManagement.Instance.AAXIV = false;
                            break;
                        case "AA 15":
                            TotalManagement.Instance.AAXV = false;
                            break;
                        case "AA 16":
                            TotalManagement.Instance.AAXVI = false;
                            break;
                        case "AA 17":
                            TotalManagement.Instance.AAXVII = false;
                            break;
                        case "AA 18":
                            TotalManagement.Instance.AAXVIII = false;
                            break;
                    }
                }

                else if (AA.gameObject.CompareTag("AASHELL"))
                {
                    Instantiate(AAShellExplosion, AA.transform.position, Quaternion.identity);
                    Destroy(AA.gameObject);
                }
            }

            ChainExplosion = true;
        }
    }

    void AirBombExplosionOperationI()
    {
        if (ChainExplosion != false)
        {
            Chronometre += Time.deltaTime;

            switch (ChainExplosionOrder)
            {
                case 0:
                    if (Chronometre >= 0.0f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionLeft[0].position, Quaternion.identity);

                        ChainExplosionOrder = 1;

                        Chronometre = 0.0f;
                    }
                    break;
                case 1:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionRight[0].position, Quaternion.identity);
                        Instantiate(ChainExplosionEffect, ChainExplosionLeft[1].position, Quaternion.identity);

                        ChainExplosionOrder = 2;

                        Chronometre = 0.0f;
                    }
                    break;
                case 2:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionRight[1].position, Quaternion.identity);
                        Instantiate(ChainExplosionEffect, ChainExplosionLeft[2].position, Quaternion.identity);

                        ChainExplosionOrder = 3;

                        Chronometre = 0.0f;
                    }
                    break;
                case 3:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionRight[2].position, Quaternion.identity);
                        Instantiate(ChainExplosionEffect, ChainExplosionLeft[3].position, Quaternion.identity);

                        ChainExplosionOrder = 4;

                        Chronometre = 0.0f;
                    }
                    break;
                case 4:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionRight[3].position, Quaternion.identity);

                        ChainExplosionOrder = 5;

                        Chronometre = 0.0f;
                    }
                    break;
                case 5:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionRight[4].position, Quaternion.identity);

                        ChainExplosionOrder = 6;

                        Chronometre = 0.0f;
                    }
                    break;
                case 6:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionRight[5].position, Quaternion.identity);

                        ChainExplosionOrder = 7;

                        Chronometre = 0.0f;
                    }
                    break;
                case 7:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionRight[6].position, Quaternion.identity);

                        ChainExplosionOrder = 8;

                        Chronometre = 0.0f;
                    }
                    break;
                case 8:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionRight[7].position, Quaternion.identity);

                        ChainExplosionOrder = 9;

                        Chronometre = 0.0f;
                    }
                    break;
                case 9:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionRight[8].position, Quaternion.identity);

                        ChainExplosionOrder = 10;

                        Chronometre = 0.0f;
                    }
                    break;
                case 10:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionRight[9].position, Quaternion.identity);

                        ChainExplosionOrder = 11;

                        Chronometre = 0.0f;
                    }
                    break;
                case 11:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionRight[10].position, Quaternion.identity);

                        ChainExplosionOrder = 12;

                        Chronometre = 0.0f;
                    }
                    break;
                case 12:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionRight[11].position, Quaternion.identity);

                        ChainExplosionOrder = 13;

                        Chronometre = 0.0f;
                    }
                    break;
                case 13:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionRight[12].position, Quaternion.identity);

                        ChainExplosionOrder = 14;

                        Chronometre = 0.0f;
                    }
                    break;
                case 14:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionRight[13].position, Quaternion.identity);

                        ChainExplosionOrder = 15;

                        Chronometre = 0.0f;
                    }
                    break;
                case 15:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionRight[14].position, Quaternion.identity);

                        ChainExplosionOrder = 0;

                        Chronometre = 0.0f;

                        ChainExplosion = false;
                    }
                    break;
            }
        }
    }

    void AirBombExplosionOperationII()
    {
        if (ChainExplosion != false)
        {
            Chronometre += Time.deltaTime;

            switch (ChainExplosionOrder)
            {
                case 0:
                    if (Chronometre >= 0.0f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionLeft[0].position, Quaternion.identity);

                        ChainExplosionOrder = 1;

                        Chronometre = 0.0f;
                    }
                    break;
                case 1:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionLeft[1].position, Quaternion.identity);
                        Instantiate(ChainExplosionEffect, ChainExplosionRight[0].position, Quaternion.identity);

                        ChainExplosionOrder = 2;

                        Chronometre = 0.0f;
                    }
                    break;
                case 2:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionLeft[2].position, Quaternion.identity);
                        Instantiate(ChainExplosionEffect, ChainExplosionRight[1].position, Quaternion.identity);

                        ChainExplosionOrder = 3;

                        Chronometre = 0.0f;
                    }
                    break;
                case 3:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionLeft[3].position, Quaternion.identity);
                        Instantiate(ChainExplosionEffect, ChainExplosionRight[2].position, Quaternion.identity);

                        ChainExplosionOrder = 4;

                        Chronometre = 0.0f;
                    }
                    break;
                case 4:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionLeft[4].position, Quaternion.identity);
                        Instantiate(ChainExplosionEffect, ChainExplosionRight[3].position, Quaternion.identity);

                        ChainExplosionOrder = 5;

                        Chronometre = 0.0f;
                    }
                    break;
                case 5:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionLeft[5].position, Quaternion.identity);
                        Instantiate(ChainExplosionEffect, ChainExplosionRight[4].position, Quaternion.identity);

                        ChainExplosionOrder = 6;

                        Chronometre = 0.0f;
                    }
                    break;
                case 6:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionLeft[6].position, Quaternion.identity);
                        Instantiate(ChainExplosionEffect, ChainExplosionRight[5].position, Quaternion.identity);

                        ChainExplosionOrder = 7;

                        Chronometre = 0.0f;
                    }
                    break;
                case 7:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionLeft[7].position, Quaternion.identity);
                        Instantiate(ChainExplosionEffect, ChainExplosionRight[6].position, Quaternion.identity);

                        ChainExplosionOrder = 8;

                        Chronometre = 0.0f;

                    }
                    break;
                case 8:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionLeft[8].position, Quaternion.identity);

                        ChainExplosionOrder = 9;

                        Chronometre = 0.0f;
                    }
                    break;
                case 9:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionLeft[9].position, Quaternion.identity);

                        ChainExplosionOrder = 10;

                        Chronometre = 0.0f;
                    }
                    break;
                case 10:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionLeft[10].position, Quaternion.identity);

                        ChainExplosionOrder = 11;

                        Chronometre = 0.0f;
                    }
                    break;
                case 11:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionLeft[11].position, Quaternion.identity);

                        ChainExplosionOrder = 12;

                        Chronometre = 0.0f;
                    }
                    break;
                case 12:
                    if (Chronometre >= 0.1f)
                    {
                        Instantiate(ChainExplosionEffect, ChainExplosionLeft[11].position, Quaternion.identity);

                        ChainExplosionOrder = 0;

                        Chronometre = 0.0f;

                        ChainExplosion = false;
                    }
                    break;
            }
        }
    }
}
