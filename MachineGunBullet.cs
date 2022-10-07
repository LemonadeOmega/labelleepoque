using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunBullet : MonoBehaviour
{
    public float scala = 150.0f;

    Rigidbody BulletRigidbody;

    void Start()
    {
        BulletRigidbody = GetComponent<Rigidbody>();

        StartCoroutine(BulletBallistics());

        Destroy(this.gameObject, 3.0f);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("ANTIAIRCRAFT") || collider.gameObject.CompareTag("AASHELL") || collider.gameObject.CompareTag("DELETION"))
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator BulletBallistics()
    {
        while (true)
        {
            BulletRigidbody.AddForce(this.transform.forward * scala * Time.deltaTime);

            yield return null;
        }
    }
}
