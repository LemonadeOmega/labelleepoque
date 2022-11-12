using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunBullet : MonoBehaviour
{
    Rigidbody BulletRigidbody;

    float MachineGunBulletAcceleration;
    float Chronometre;

    void Start()
    {
        BulletRigidbody = GetComponent<Rigidbody>();

        TotalManagement.Instance.ChronoState += Chrono;
    }

    void Update()
    {
        MachineGunBulletAcceleration += 0.1f;
        Chronometre += Time.deltaTime;

        this.transform.Translate(Vector3.forward * MachineGunBulletAcceleration * Time.deltaTime);

        if (Chronometre >= 3.0f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnDestroy()
    {
        TotalManagement.Instance.ChronoState -= Chrono;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("ANTIAIRCRAFT") || collider.gameObject.CompareTag("AASHELL") || collider.gameObject.CompareTag("DELETION"))
        {
            Destroy(this.gameObject);
        }
    }

    void Chrono(O o)
    {
        enabled = o == O.One;
    }
}
