using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiAircraft : MonoBehaviour
{
    public GameObject battery;
    public GameObject recuperator;
    public GameObject barrel;
    public GameObject shell;

    public Transform AAFire;
    public Transform AARecoil;

    public ParticleSystem AAFlame;
    public ParticleSystem AANeutralisedFlame;

    public AudioClip[] AASoundEffects;

    public int AADurability;

    public float AASetFireAngle;
    public float BatteryRotationAxisY;

    AudioSource AASound;

    float Chronometre;

    bool Operation;

    public enum AntiAircraftState
    {
        READY,
        AIM,
        FIRE,
        NEUTRALISED
    }
    public AntiAircraftState AAState = AntiAircraftState.READY;

    void Start()
    {
        AAFlame.gameObject.SetActive(false);
        AANeutralisedFlame.gameObject.SetActive(false);

        AADurability = 25;

        switch (TotalManagement.Instance.Level)
        {
            case 0:
                if (GameObject.Find("AA 1") == null) { this.gameObject.name = "AA 1"; TotalManagement.Instance.AAI = true; }
                else if (GameObject.Find("AA 2") == null) { this.gameObject.name = "AA 2"; TotalManagement.Instance.AAII = true; }
                else if (GameObject.Find("AA 3") == null) { this.gameObject.name = "AA 3"; TotalManagement.Instance.AAIII = true; }
                else if (GameObject.Find("AA 4") == null) { this.gameObject.name = "AA 4"; TotalManagement.Instance.AAIIII = true; }
                else if (GameObject.Find("AA 5") == null) { this.gameObject.name = "AA 5"; TotalManagement.Instance.AAV = true; }
                else if (GameObject.Find("AA 6") == null) { this.gameObject.name = "AA 6"; TotalManagement.Instance.AAVI = true; }
                break;
            case 1:
                if (GameObject.Find("AA 1") == null) { this.gameObject.name = "AA 1"; TotalManagement.Instance.AAI = true; }
                else if (GameObject.Find("AA 2") == null) { this.gameObject.name = "AA 2"; TotalManagement.Instance.AAII = true; }
                else if (GameObject.Find("AA 3") == null) { this.gameObject.name = "AA 3"; TotalManagement.Instance.AAIII = true; }
                else if (GameObject.Find("AA 4") == null) { this.gameObject.name = "AA 4"; TotalManagement.Instance.AAIIII = true; }
                else if (GameObject.Find("AA 5") == null) { this.gameObject.name = "AA 5"; TotalManagement.Instance.AAV = true; }
                else if (GameObject.Find("AA 6") == null) { this.gameObject.name = "AA 6"; TotalManagement.Instance.AAVI = true; }
                else if (GameObject.Find("AA 7") == null) { this.gameObject.name = "AA 7"; TotalManagement.Instance.AAVII = true; }
                else if (GameObject.Find("AA 8") == null) { this.gameObject.name = "AA 8"; TotalManagement.Instance.AAVIII = true; }
                else if (GameObject.Find("AA 9") == null) { this.gameObject.name = "AA 9"; TotalManagement.Instance.AAIX = true; }
                else if (GameObject.Find("AA 10") == null) { this.gameObject.name = "AA 10"; TotalManagement.Instance.AAX = true; }
                else if (GameObject.Find("AA 11") == null) { this.gameObject.name = "AA 11"; TotalManagement.Instance.AAXI = true; }
                else if (GameObject.Find("AA 12") == null) { this.gameObject.name = "AA 12"; TotalManagement.Instance.AAXII = true; }
                break;
            case 2:
                if (GameObject.Find("AA 1") == null) { this.gameObject.name = "AA 1"; TotalManagement.Instance.AAI = true; }
                else if (GameObject.Find("AA 2") == null) { this.gameObject.name = "AA 2"; TotalManagement.Instance.AAII = true; }
                else if (GameObject.Find("AA 3") == null) { this.gameObject.name = "AA 3"; TotalManagement.Instance.AAIII = true; }
                else if (GameObject.Find("AA 4") == null) { this.gameObject.name = "AA 4"; TotalManagement.Instance.AAIIII = true; }
                else if (GameObject.Find("AA 5") == null) { this.gameObject.name = "AA 5"; TotalManagement.Instance.AAV = true; }
                else if (GameObject.Find("AA 6") == null) { this.gameObject.name = "AA 6"; TotalManagement.Instance.AAVI = true; }
                else if (GameObject.Find("AA 7") == null) { this.gameObject.name = "AA 7"; TotalManagement.Instance.AAVII = true; }
                else if (GameObject.Find("AA 8") == null) { this.gameObject.name = "AA 8"; TotalManagement.Instance.AAVIII = true; }
                else if (GameObject.Find("AA 9") == null) { this.gameObject.name = "AA 9"; TotalManagement.Instance.AAIX = true; }
                else if (GameObject.Find("AA 10") == null) { this.gameObject.name = "AA 10"; TotalManagement.Instance.AAX = true; }
                else if (GameObject.Find("AA 11") == null) { this.gameObject.name = "AA 11"; TotalManagement.Instance.AAXI = true; }
                else if (GameObject.Find("AA 12") == null) { this.gameObject.name = "AA 12"; TotalManagement.Instance.AAXII = true; }
                else if (GameObject.Find("AA 13") == null) { this.gameObject.name = "AA 13"; TotalManagement.Instance.AAXIII = true; }
                else if (GameObject.Find("AA 14") == null) { this.gameObject.name = "AA 14"; TotalManagement.Instance.AAXIV = true; }
                else if (GameObject.Find("AA 15") == null) { this.gameObject.name = "AA 15"; TotalManagement.Instance.AAXV = true; }
                else if (GameObject.Find("AA 16") == null) { this.gameObject.name = "AA 16"; TotalManagement.Instance.AAXVI = true; }
                else if (GameObject.Find("AA 17") == null) { this.gameObject.name = "AA 17"; TotalManagement.Instance.AAXVII = true; }
                else if (GameObject.Find("AA 18") == null) { this.gameObject.name = "AA 18"; TotalManagement.Instance.AAXVIII = true; }
                break;
        }

        TotalManagement.Instance.Battery += 1;

        switch (this.gameObject.name)
        {
            case "AA 1(Clone)":
                TotalManagement.Instance.Battery += 1;
                Destroy(this.gameObject);
                break;
            case "AA 2(Clone)":
                TotalManagement.Instance.Battery += 1;
                Destroy(this.gameObject);
                break;
            case "AA 3(Clone)":
                TotalManagement.Instance.Battery += 1;
                Destroy(this.gameObject);
                break;
            case "AA 4(Clone)":
                TotalManagement.Instance.Battery += 1;
                Destroy(this.gameObject);
                break;
            case "AA 5(Clone)":
                TotalManagement.Instance.Battery += 1;
                Destroy(this.gameObject);
                break;
            case "AA 6(Clone)":
                TotalManagement.Instance.Battery += 1;
                Destroy(this.gameObject);
                break;
            case "AA 7(Clone)":
                TotalManagement.Instance.Battery += 1;
                Destroy(this.gameObject);
                break;
            case "AA 8(Clone)":
                TotalManagement.Instance.Battery += 1;
                Destroy(this.gameObject);
                break;
            case "AA 9(Clone)":
                TotalManagement.Instance.Battery += 1;
                Destroy(this.gameObject);
                break;
            case "AA 10(Clone)":
                TotalManagement.Instance.Battery += 1;
                Destroy(this.gameObject);
                break;
            case "AA 11(Clone)":
                TotalManagement.Instance.Battery += 1;
                Destroy(this.gameObject);
                break;
            case "AA 12(Clone)":
                TotalManagement.Instance.Battery += 1;
                Destroy(this.gameObject);
                break;
            case "AA 13(Clone)":
                TotalManagement.Instance.Battery += 1;
                Destroy(this.gameObject);
                break;
            case "AA 14(Clone)":
                TotalManagement.Instance.Battery += 1;
                Destroy(this.gameObject);
                break;
            case "AA 15(Clone)":
                TotalManagement.Instance.Battery += 1;
                Destroy(this.gameObject);
                break;
            case "AA 16(Clone)":
                TotalManagement.Instance.Battery += 1;
                Destroy(this.gameObject);
                break;
            case "AA 17(Clone)":
                TotalManagement.Instance.Battery += 1;
                Destroy(this.gameObject);
                break;
            case "AA 18(Clone)":
                TotalManagement.Instance.Battery += 1;
                Destroy(this.gameObject);
                break;
        }

        AASound = GetComponent<AudioSource>();

        Operation = true;

        StartCoroutine(AAStateCheck());
        StartCoroutine(AAinOperation());
    }

    void Update()
    {
        Debug.DrawRay(AAFire.transform.position, AAFire.right * 1.5f, Color.red);

        switch (this.gameObject.name)
        {
            case "AA 1":
                if (TotalManagement.Instance.AAI != true) { AADurability = 0; }
                break;
            case "AA 2":
                if (TotalManagement.Instance.AAII != true) { AADurability = 0; }
                break;
            case "AA 3":
                if (TotalManagement.Instance.AAIII != true) { AADurability = 0; }
                break;
            case "AA 4":
                if (TotalManagement.Instance.AAIIII != true) { AADurability = 0; }
                break;
            case "AA 5":
                if (TotalManagement.Instance.AAV != true) { AADurability = 0; }
                break;
            case "AA 6":
                if (TotalManagement.Instance.AAVI != true) { AADurability = 0; }
                break;
            case "AA 7":
                if (TotalManagement.Instance.AAVII != true) { AADurability = 0; }
                break;
            case "AA 8":
                if (TotalManagement.Instance.AAVIII != true) { AADurability = 0; }
                break;
            case "AA 9":
                if (TotalManagement.Instance.AAIX != true) { AADurability = 0; }
                break;
            case "AA 10":
                if (TotalManagement.Instance.AAX != true) { AADurability = 0; }
                break;
            case "AA 11":
                if (TotalManagement.Instance.AAXI != true) { AADurability = 0; }
                break;
            case "AA 12":
                if (TotalManagement.Instance.AAXII != true) { AADurability = 0; }
                break;
            case "AA 13":
                if (TotalManagement.Instance.AAXIII != true) { AADurability = 0; }
                break;
            case "AA 14":
                if (TotalManagement.Instance.AAXIV != true) { AADurability = 0; }
                break;
            case "AA 15":
                if (TotalManagement.Instance.AAXV != true) { AADurability = 0; }
                break;
            case "AA 16":
                if (TotalManagement.Instance.AAXVI != true) { AADurability = 0; }
                break;
            case "AA 17":
                if (TotalManagement.Instance.AAXVII != true) { AADurability = 0; }
                break;
            case "AA 18":
                if (TotalManagement.Instance.AAXVIII != true) { AADurability = 0; }
                break;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("BULLET"))
        {
            AADurability -= 1;
        }
    }

    IEnumerator AAStateCheck()
    {
        while (Operation != false)
        {
            if (AADurability <= 0)
            {
                AADurability = 0;

                AAState = AntiAircraftState.NEUTRALISED;
            }

            if (AAState == AntiAircraftState.NEUTRALISED)
            {
                yield break;
            }

            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator AAinOperation()
    {
        while (Operation != false)
        {
            switch (AAState)
            {
                case AntiAircraftState.READY:
                    AALaying();
                    break;
                case AntiAircraftState.AIM:
                    LockontheTarget();
                    break;
                case AntiAircraftState.FIRE:
                    AAShellFire();
                    break;
                case AntiAircraftState.NEUTRALISED:
                    NeutralisedAA();
                    break;
            }

            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator RecoilAnimation()
    {
        AAFlame.gameObject.SetActive(true);
        AAFlame.Play();

        Chronometre += Time.deltaTime;

        Vector3 aaoriginalform = barrel.transform.position;
        Vector3 aarecoiledform = AARecoil.position;

        float present = 0.0f;
        float future = 0.3f;
        float elapsedrate = present / future;

        while (elapsedrate < 1.0f)
        {
            present += Time.deltaTime;
            elapsedrate = present / future;

            barrel.transform.position = Vector3.Lerp(aarecoiledform, aaoriginalform, elapsedrate);

            yield return null;
        }

        if (Chronometre >= 1.0f)
        {
            AAFlame.gameObject.SetActive(false);

            Chronometre = 0;
        }

        barrel.transform.position = aaoriginalform;

        AAState = AntiAircraftState.READY;
    }

    void LockontheTarget()
    {
        AAGunAngle();

        RaycastHit Detection;

        if (Physics.Raycast(AAFire.position, AAFire.right * 1.5f, out Detection))
        {
            if (Detection.collider.CompareTag("AIRPOCKET") || Detection.collider.CompareTag("PROPELLER"))
            {
                AAState = AntiAircraftState.FIRE;
            }

            else if (!Detection.collider.CompareTag("AIRPOCKET") || !Detection.collider.CompareTag("PROPELLER"))
            {
                NothingintheAir();
            }
        }
    }
    
    void AALaying()
    {
        AASetFireAngle = Random.Range(35.0f, 55.0f);

        AAState = AntiAircraftState.AIM;
    }

    void AAGunAngle()
    {
        recuperator.transform.rotation = Quaternion.Slerp(recuperator.transform.rotation, Quaternion.Euler(new Vector3(0.0f, battery.transform.eulerAngles.y, AASetFireAngle)), 1);
    }

    void NothingintheAir()
    {
        Debug.Log("Nothing in the Air");

        BatteryRotationAxisY = battery.transform.eulerAngles.y;

        if (BatteryRotationAxisY == 0)
        {
            battery.transform.rotation = Quaternion.Slerp(battery.transform.rotation, Quaternion.Euler(new Vector3(0.0f, 180.0f, 0.0f)), 1);
        }

        else if (BatteryRotationAxisY == 180.0f)
        {
            battery.transform.rotation = Quaternion.Slerp(battery.transform.rotation, Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)), 1);
        }

        AAState = AntiAircraftState.READY;
    }

    void AAShellFire()
    {
        Instantiate(shell, AAFire.transform.position, AAFire.transform.rotation);

        AASound.PlayOneShot(AASoundEffects[0]);

        StartCoroutine(RecoilAnimation());
    }

    void NeutralisedAA()
    {
        AANeutralisedFlame.gameObject.SetActive(true);

        switch (AASound.isPlaying)
        {
            case true:
                break;
            case false:
                AASound.PlayOneShot(AASoundEffects[1]);
                break;
        }

        switch (this.gameObject.name)
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

        TotalManagement.Instance.Merit += 10;
        TotalManagement.Instance.Battery -= 1;

        Destroy(this.gameObject, 3.0f);
    }
}
