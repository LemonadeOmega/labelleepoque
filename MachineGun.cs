using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineGun : MonoBehaviour
{
    public float overheating;
    public float cooling;

    public GameObject Bullet;

    public Transform BulletFire;

    public Button AmmunitionReloading;

    public ParticleSystem BulletEjection;
    public ParticleSystem MuzzleFlash;

    AudioSource MachineGunSound;

    void Start()
    {
        MachineGunSound = GetComponent<AudioSource>();

        MuzzleFlash.gameObject.SetActive(false);
    }

    void Update()
    {
        switch (this.gameObject.name)
        {
            case "MG08 1":
                BulletFire.position = new Vector3(BulletFire.position.x, BulletFire.position.y, -0.3f);
                switch (TotalManagement.Instance.TriggerI)
                {
                    case true:
                        AmmunitionReloading.enabled = false;
                        AmmunitionReloading.interactable = false;
                        cooling = 0.0f;
                        StartCoroutine(Fire());
                        MachineGunSound.enabled = true;
                        MuzzleFlash.gameObject.SetActive(true);
                        break;
                    case false:
                        StopAllCoroutines();
                        MachineGunSound.enabled = false;
                        MuzzleFlash.gameObject.SetActive(false);
                        overheating = 0.0f;
                        cooling += Time.deltaTime;
                        if (cooling >= 1.0f)
                        {
                            AmmunitionReloading.enabled = true;
                            AmmunitionReloading.interactable = true;
                        }
                        break;
                }
                if (overheating >= 60.0f)
                {
                    TotalManagement.Instance.TriggerI = false;
                }
                break;
            case "MG08 2":
                BulletFire.position = new Vector3(BulletFire.position.x, BulletFire.position.y, -0.3f);
                switch (TotalManagement.Instance.TriggerII)
                {
                    case true:
                        AmmunitionReloading.enabled = false;
                        AmmunitionReloading.interactable = false;
                        cooling = 0.0f;
                        StartCoroutine(Fire());
                        MachineGunSound.enabled = true;
                        MuzzleFlash.gameObject.SetActive(true);
                        break;
                    case false:
                        StopAllCoroutines();
                        MachineGunSound.enabled = false;
                        MuzzleFlash.gameObject.SetActive(false);
                        overheating = 0.0f;
                        cooling += Time.deltaTime;
                        if (cooling >= 1.0f)
                        {
                            AmmunitionReloading.enabled = true;
                            AmmunitionReloading.interactable = true;
                        }
                        break;
                }
                if (overheating >= 60.0f)
                {
                    TotalManagement.Instance.TriggerII = false;
                }
                break;
            case "MG08 3":
                BulletFire.position = new Vector3(BulletFire.position.x, BulletFire.position.y, -0.3f);
                switch (TotalManagement.Instance.TriggerIII)
                {
                    case true:
                        AmmunitionReloading.enabled = false;
                        AmmunitionReloading.interactable = false;
                        cooling = 0.0f;
                        StartCoroutine(Fire());
                        MachineGunSound.enabled = true;
                        MuzzleFlash.gameObject.SetActive(true);
                        break;
                    case false:
                        StopAllCoroutines();
                        MachineGunSound.enabled = false;
                        MuzzleFlash.gameObject.SetActive(false);
                        overheating = 0.0f;
                        cooling += Time.deltaTime;
                        if (cooling >= 1.0f)
                        {
                            AmmunitionReloading.enabled = true;
                            AmmunitionReloading.interactable = true;
                        }
                        break;
                }
                if (overheating >= 60.0f)
                {
                    TotalManagement.Instance.TriggerIII = false;
                }
                break;
            case "MG08 4":
                BulletFire.position = new Vector3(BulletFire.position.x, BulletFire.position.y, -0.3f);
                switch (TotalManagement.Instance.TriggerIIII)
                {
                    case true:
                        AmmunitionReloading.enabled = false;
                        AmmunitionReloading.interactable = false;
                        cooling = 0.0f;
                        StartCoroutine(Fire());
                        MachineGunSound.enabled = true;
                        MuzzleFlash.gameObject.SetActive(true);
                        break;
                    case false:
                        StopAllCoroutines();
                        MachineGunSound.enabled = false;
                        MuzzleFlash.gameObject.SetActive(false);
                        overheating = 0.0f;
                        cooling += Time.deltaTime;
                        if (cooling >= 1.0f)
                        {
                            AmmunitionReloading.enabled = true;
                            AmmunitionReloading.interactable = true;
                        }
                        break;
                }
                if (overheating >= 60.0f)
                {
                    TotalManagement.Instance.TriggerIIII = false;
                }
                break;
            case "MG08 5":
                BulletFire.position = new Vector3(BulletFire.position.x, BulletFire.position.y, -0.3f);
                switch (TotalManagement.Instance.TriggerV)
                {
                    case true:
                        //AmmunitionReloading.enabled = false;
                        //AmmunitionReloading.interactable = false;
                        cooling = 0.0f;
                        StartCoroutine(Fire());
                        MuzzleFlash.gameObject.SetActive(true);
                        break;
                    case false:
                        StopAllCoroutines();
                        //MachineGunSound.enabled = false;
                        MuzzleFlash.gameObject.SetActive(false);
                        overheating = 0;
                        cooling += Time.deltaTime;
                        if (cooling >= 1.0f)
                        {
                            //AmmunitionReloading.enabled = true;
                            //AmmunitionReloading.interactable = true;
                        }
                        break;
                }
                if (overheating >= 60.0f)
                {
                    TotalManagement.Instance.TriggerV = false;
                }
                break;
            case "MG08 6":
                BulletFire.position = new Vector3(BulletFire.position.x, BulletFire.position.y, -0.3f);
                switch (TotalManagement.Instance.TriggerVI)
                {
                    case true:
                        //AmmunitionReloading.enabled = false;
                        //AmmunitionReloading.interactable = false;
                        cooling = 0.0f;
                        StartCoroutine(Fire());
                        MuzzleFlash.gameObject.SetActive(true);
                        break;
                    case false:
                        StopAllCoroutines();
                        //MachineGunSound.enabled = false;
                        MuzzleFlash.gameObject.SetActive(false);
                        overheating = 0;
                        cooling += Time.deltaTime;
                        if (cooling >= 1.0f)
                        {
                            //AmmunitionReloading.enabled = true;
                            //AmmunitionReloading.interactable = true;
                        }
                        break;
                }
                if (overheating >= 60.0f)
                {
                    TotalManagement.Instance.TriggerVI = false;
                }
                break;
        }
    }

    IEnumerator Fire()
    {
        overheating += Time.deltaTime;

        Instantiate(Bullet, BulletFire.transform.position, BulletFire.transform.rotation);

        BulletEjection.Play();

        yield return null;
    }
}
