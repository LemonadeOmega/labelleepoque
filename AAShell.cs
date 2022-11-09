using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAShell : MonoBehaviour
{
    public GameObject ExplosionEffect;

    public float AAShellScala = 25.0f;

    Airship airship;

    public float Chronometre;

    void Start()
    {
        airship = GameObject.Find("Airship").GetComponent<Airship>();

        TotalManagement.Instance.ChronoState += Chrono;
    }

    void Update()
    {
        this.transform.Translate(Vector3.right * AAShellScala * Time.deltaTime);

        Chronometre += Time.deltaTime;

        if (Chronometre >= 5.0f)
        {
            Instantiate(ExplosionEffect, this.transform.position, Quaternion.identity);

            Collider[] shock = Physics.OverlapSphere(this.transform.position, 0.1f, 1 << 9);

            foreach (var shockdamage in shock)
            {
                if (shockdamage.gameObject.CompareTag("AIRPOCKET") || shockdamage.gameObject.CompareTag("HYDROGEN"))
                {
                    airship.AirshipDurability -= 0.001f;
                }
            }

            Destroy(this.gameObject);
        }
    }

    void OnDestroy()
    {
        TotalManagement.Instance.ChronoState -= Chrono;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("BULLET"))
        {
            Instantiate(ExplosionEffect, this.transform.position, Quaternion.identity);

            TotalManagement.Instance.Merit += 1;

            Destroy(this.gameObject);
        }

        if (collider.gameObject.CompareTag("AIRPOCKET") || collider.gameObject.CompareTag("HYDROGEN") || collider.gameObject.CompareTag("PROPELLER"))
        {
            Destroy(this.gameObject);
        }
    }

    void Chrono(O o)
    {
        enabled = o == O.One;
    }
}
