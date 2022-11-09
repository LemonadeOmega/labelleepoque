using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunBullet : MonoBehaviour
{
    public float scala = 150.0f;

    Rigidbody BulletRigidbody;

    float Chronometre;

    void Start()
    {
        BulletRigidbody = GetComponent<Rigidbody>();

        TotalManagement.Instance.ChronoState += Chrono;
    }

    void Update()
    {
        switch (TotalManagement.Instance.PresentChronoState)
        {
            case O.One:
                StartCoroutine(MachineGunBulletAttribute());
                break;
            case O.Nought:
                StopAllCoroutines();
                break;
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

    IEnumerator MachineGunBulletAttribute()
    {
        Chronometre += Time.deltaTime;

        BulletRigidbody.AddForce(this.transform.forward * scala * Time.deltaTime);

        if (Chronometre >= 3.0f)
        {
            Destroy(this.gameObject);
        }

        yield return null;
    }

    void Chrono(O o)
    {
        enabled = o == O.One;
    }
}
