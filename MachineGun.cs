using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineGun : MonoBehaviour
{
    public float overheating;
    public float cooling;

    public GameObject Bullet;

    public Transform MachineGunBulletFire;

    public Button AmmunitionReloading;

    public ParticleSystem MachineGunMuzzleFlash;
    public ParticleSystem MachineGunBulletEjection;

    public AudioClip MachineGunFireSoundEffect;

    AudioSource MachineGunSound;

    bool MachineGunChrono;

    void Start()
    {
        MachineGunSound = GetComponent<AudioSource>();
        MachineGunSound.Stop();

        MachineGunMuzzleFlash.Stop();

        TotalManagement.Instance.ChronoState += Chrono;

        MachineGunChrono = false;

        StartCoroutine(MachineGunChronoSystem());
    }

    void OnDestroy()
    {
        TotalManagement.Instance.ChronoState -= Chrono;
    }

    IEnumerator MachineGunChronoSystem()
    {
        while (true)
        {
            switch (TotalManagement.Instance.PresentChronoState)
            {
                case O.One:
                    switch (MachineGunChrono)
                    {
                        case true:
                            StartCoroutine(MachineGunMechanism());
                            break;
                        case false:
                            StartCoroutine(MachineGunMechanism());
                            MachineGunMuzzleFlash.Play();
                            MachineGunSound.UnPause();
                            MachineGunBulletEjection.Play();
                            MachineGunChrono = true;
                            break;
                    }
                    break;
                case O.Nought:
                    StopCoroutine(MachineGunMechanism());
                    MachineGunMuzzleFlash.Pause();
                    MachineGunSound.Pause();
                    MachineGunBulletEjection.Pause();
                    MachineGunChrono = false;
                    break;
            }

            yield return null;
        }
    }

    IEnumerator MachineGunMechanism()
    {
        switch (this.gameObject.name)
        {
            case "MG08 1":
                MachineGunBulletFire.position = new Vector3(MachineGunBulletFire.position.x, MachineGunBulletFire.position.y, -0.3f);
                switch (TotalManagement.Instance.TriggerI)
                {
                    case true:
                        AmmunitionReloading.enabled = false;
                        AmmunitionReloading.interactable = false;
                        cooling = 0.0f;
                        overheating += Time.deltaTime;
                        Instantiate(Bullet, MachineGunBulletFire.transform.position, MachineGunBulletFire.transform.rotation);
                        if (MachineGunMuzzleFlash.isPlaying != true && MachineGunChrono != false)
                        {
                            MachineGunMuzzleFlash.Play();
                        }
                        if (MachineGunSound.isPlaying != true && MachineGunChrono != false)
                        {
                            MachineGunSound.Play();
                        }
                        MachineGunBulletEjection.Play();
                        if (overheating >= 60.0f)
                        {
                            TotalManagement.Instance.TriggerI = false;
                        }
                        break;
                    case false:
                        MachineGunMuzzleFlash.Stop();
                        overheating = 0.0f;
                        cooling += Time.deltaTime;
                        if (cooling >= 1.0f)
                        {
                            AmmunitionReloading.enabled = true;
                            AmmunitionReloading.interactable = true;
                        }
                        break;
                }
                break;
            case "MG08 2":
                MachineGunBulletFire.position = new Vector3(MachineGunBulletFire.position.x, MachineGunBulletFire.position.y, -0.3f);
                switch (TotalManagement.Instance.TriggerII)
                {
                    case true:
                        AmmunitionReloading.enabled = false;
                        AmmunitionReloading.interactable = false;
                        cooling = 0.0f;
                        overheating += Time.deltaTime;
                        Instantiate(Bullet, MachineGunBulletFire.transform.position, MachineGunBulletFire.transform.rotation);
                        if (MachineGunMuzzleFlash.isPlaying != true && MachineGunChrono != false)
                        {
                            MachineGunMuzzleFlash.Play();
                        }
                        if (MachineGunSound.isPlaying != true && MachineGunChrono != false)
                        {
                            MachineGunSound.Play();
                        }
                        MachineGunBulletEjection.Play();
                        if (overheating >= 60.0f)
                        {
                            TotalManagement.Instance.TriggerII = false;
                        }
                        break;
                    case false:
                        MachineGunMuzzleFlash.Stop();
                        overheating = 0.0f;
                        cooling += Time.deltaTime;
                        if (cooling >= 1.0f)
                        {
                            AmmunitionReloading.enabled = true;
                            AmmunitionReloading.interactable = true;
                        }
                        break;
                }
                break;
            case "MG08 3":
                MachineGunBulletFire.position = new Vector3(MachineGunBulletFire.position.x, MachineGunBulletFire.position.y, -0.3f);
                switch (TotalManagement.Instance.TriggerIII)
                {
                    case true:
                        AmmunitionReloading.enabled = false;
                        AmmunitionReloading.interactable = false;
                        cooling = 0.0f;
                        overheating += Time.deltaTime;
                        Instantiate(Bullet, MachineGunBulletFire.transform.position, MachineGunBulletFire.transform.rotation);
                        if (MachineGunMuzzleFlash.isPlaying != true && MachineGunChrono != false)
                        {
                            MachineGunMuzzleFlash.Play();
                        }
                        if (MachineGunSound.isPlaying != true && MachineGunChrono != false)
                        {
                            MachineGunSound.Play();
                        }
                        MachineGunBulletEjection.Play();
                        if (overheating >= 60.0f)
                        {
                            TotalManagement.Instance.TriggerIII = false;
                        }
                        break;
                    case false:
                        MachineGunMuzzleFlash.Stop();
                        overheating = 0.0f;
                        cooling += Time.deltaTime;
                        if (cooling >= 1.0f)
                        {
                            AmmunitionReloading.enabled = true;
                            AmmunitionReloading.interactable = true;
                        }
                        break;
                }
                break;
            case "MG08 4":
                MachineGunBulletFire.position = new Vector3(MachineGunBulletFire.position.x, MachineGunBulletFire.position.y, -0.3f);
                switch (TotalManagement.Instance.TriggerIIII)
                {
                    case true:
                        AmmunitionReloading.enabled = false;
                        AmmunitionReloading.interactable = false;
                        cooling = 0.0f;
                        overheating += Time.deltaTime;
                        Instantiate(Bullet, MachineGunBulletFire.transform.position, MachineGunBulletFire.transform.rotation);
                        if (MachineGunMuzzleFlash.isPlaying != true && MachineGunChrono != false)
                        {
                            MachineGunMuzzleFlash.Play();
                        }
                        if (MachineGunSound.isPlaying != true && MachineGunChrono != false)
                        {
                            MachineGunSound.Play();
                        }
                        MachineGunBulletEjection.Play();
                        if (overheating >= 60.0f)
                        {
                            TotalManagement.Instance.TriggerIIII = false;
                        }
                        break;
                    case false:
                        MachineGunMuzzleFlash.Stop();
                        overheating = 0.0f;
                        cooling += Time.deltaTime;
                        if (cooling >= 1.0f)
                        {
                            AmmunitionReloading.enabled = true;
                            AmmunitionReloading.interactable = true;
                        }
                        break;
                }
                break;
            case "MG08 5":
                MachineGunBulletFire.position = new Vector3(MachineGunBulletFire.position.x, MachineGunBulletFire.position.y, -0.3f);
                switch (TotalManagement.Instance.TriggerV)
                {
                    case true:
                //        AmmunitionReloading.enabled = false;
                //        AmmunitionReloading.interactable = false;
                //        cooling = 0.0f;
                //        overheating += Time.deltaTime;
                //        Instantiate(Bullet, MachineGunBulletFire.transform.position, MachineGunBulletFire.transform.rotation);
                //        if (MachineGunMuzzleFlash.isPlaying != true && MachineGunChrono != false)
                //        {
                //            MachineGunMuzzleFlash.Play();
                //        }
                //        if (MachineGunSound.isPlaying != true && MachineGunChrono != false)
                //        {
                //            MachineGunSound.Play();
                //        }
                //        MachineGunBulletEjection.Play();
                //        if (overheating >= 60.0f)
                //        {
                //            TotalManagement.Instance.TriggerV = false;
                //        }
                        break;
                    case false:
                        MachineGunMuzzleFlash.Stop();
                        overheating = 0.0f;
                        cooling += Time.deltaTime;
                        if (cooling >= 1.0f)
                        {
                //            AmmunitionReloading.enabled = true;
                //            AmmunitionReloading.interactable = true;
                        }
                        break;
                }
                break;
            case "MG08 6":
                MachineGunBulletFire.position = new Vector3(MachineGunBulletFire.position.x, MachineGunBulletFire.position.y, -0.3f);
                switch (TotalManagement.Instance.TriggerVI)
                {
                    case true:
                //        AmmunitionReloading.enabled = false;
                //        AmmunitionReloading.interactable = false;
                //        cooling = 0.0f;
                //        overheating += Time.deltaTime;
                //        Instantiate(Bullet, MachineGunBulletFire.transform.position, MachineGunBulletFire.transform.rotation);
                //        if (MachineGunMuzzleFlash.isPlaying != true && MachineGunChrono != false)
                //        {
                //            MachineGunMuzzleFlash.Play();
                //        }
                //        if (MachineGunSound.isPlaying != true && MachineGunChrono != false)
                //        {
                //            MachineGunSound.Play();
                //        }
                //        MachineGunBulletEjection.Play();
                //        if (overheating >= 60.0f)
                //        {
                //            TotalManagement.Instance.TriggerVI = false;
                //        }
                        break;
                    case false:
                        MachineGunMuzzleFlash.Stop();
                        overheating = 0.0f;
                        cooling += Time.deltaTime;
                        if (cooling >= 1.0f)
                        {
                //            AmmunitionReloading.enabled = true;
                //            AmmunitionReloading.interactable = true;
                        }
                        break;
                }
                break;
        }
    
        yield return null;
    }

    void Chrono(O o)
    {
        enabled = o == O.One;
    }
}
