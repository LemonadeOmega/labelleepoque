using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    public Text MeritCount;
    public Text Alarm;

    public int alarm;

    Airship airship;

    float Chronometre;

    string falling = "<color=#a62c2b>" + "Falling" + "</color>";
    string brokendown = "<color=#a62c2b>" + "Brokendown" + "</color>";
    string firealarm = "<color=#a62c2b>" + "Alarm" + "</color>";
    string fire = "<color=#a62c2b>" + "Fire" + "</color>";
    string altitudealarm = "<color=#da680f>" + "Alarm" + "</color>";
    string considerably = "<color=#da680f>" + "considerably" + "</color>";
    string exposed = "<color=#da680f>" + "exposed" + "</color>";
    string attacked = "<color=#da680f>" + "attacked" + "</color>";
    string altitude = "<color=#da680f>" + "Altitude" + "</color>";
    string higher = "<color=#da680f>" + "higher" + "</color>";
    string lower = "<color=#fdcc0d>" + "Lower" + "</color>";
    string condition = "<color=#fdcc0d>" + "Condition" + "</color>";
    string watched = "<color=#fdcc0d>" + "watched" + "</color>";
    string maintained = "<color=#fdcc0d>" + "maintained" + "</color>";
    string green = "<color=#296e01>" + "Green" + "</color>";
    string allgreen = "<color=#296e01>" + "All Green" + "</color>";
    string merit = "<color=#32527b>" + "Merit" + "</color>";

    void Start()
    {
        airship = GameObject.Find("Airship").GetComponent<Airship>();

        alarm = 0;

        StartCoroutine(MeritCountReport());
        StartCoroutine(AlarmReport());
    }

    IEnumerator MeritCountReport()
    {
        while (true)
        {
            MeritCount.text = "X  " + TotalManagement.Instance.Merit;

            yield return null;
        }
    }

    IEnumerator AlarmReport()
    {
        while (true)
        {
            switch (alarm)
            {
                case 0:
                    switch (airship.AirshipDurability)
                    {
                        case >= 0.25f:
                            AlarmI();
                            break;
                        case >= 0.20f:
                            AlarmII();
                            break;
                        case >= 0.15f:
                            AlarmIII();
                            break;
                        case <= 0.15f:
                            AlarmIIII();
                            break;
                    }
                    break;
                case 1:
                    Green();
                    break;
                case 2:
                    InsufficientMerit();
                    break;
                case 3:
                    PropellerAlarm();
                    break;
                case 4:
                    FireAlarm();
                    break;
            }

            yield return new WaitForSeconds(0.3f);
        }
    }

    void AlarmI()
    {
        Alarm.text = "Airship Condition " + green;
    }

    void AlarmII()
    {
        Chronometre += Time.deltaTime;

        if (Chronometre >= 0.0f)
        {
            Alarm.text = "Altitude has been " + lower;
        }

        if (Chronometre >= 0.3f)
        {
            Alarm.text = "Airship " + condition + " should be";
        }

        if (Chronometre >= 0.6f)
        {
            Alarm.text = watched + " and " + maintained;
        }

        if (Chronometre >= 0.9)
        {
            Chronometre = 0;
        }
    }

    void AlarmIII()
    {
        Chronometre += Time.deltaTime;

        if (Chronometre >= 0.0f)
        {
            Alarm.text = altitudealarm + ", Airship has been " + considerably;
        }

        if (Chronometre >= 0.3f)
        {
            Alarm.text = exposed + " to be " + attacked + " by AAs";

        }

        if (Chronometre > 0.6f)
        {
            Alarm.text = altitude + " must be gained " + higher;
        }

        if (Chronometre >= 0.9)
        {
            Chronometre = 0.0f;
        }
    }

    void AlarmIIII()
    {
        Alarm.text = "Airship is " + falling;
    }

    void PropellerAlarm()
    {
        Chronometre += Time.deltaTime;

        if (Chronometre >= 0.0f && TotalManagement.Instance.PropellerI != true)
        {
            Alarm.text = "Front Gondola Propeller " + brokendown;

            if (Chronometre >= 0.3f && TotalManagement.Instance.PropellerII != true)
            {
                Alarm.text = "Rear Gondola Propeller " + brokendown;

                if (Chronometre >= 0.6f && TotalManagement.Instance.PropellerIII != true)
                {
                    Alarm.text = "No. 1 Lateral Propeller " + brokendown;

                    if (Chronometre >= 0.9f && TotalManagement.Instance.PropellerIIII != true)
                    {
                        Alarm.text = "No. 2 Lateral Propeller " + brokendown;

                        if (Chronometre >= 1.2f)
                        {
                            Chronometre = 0.0f;
                        }
                    }

                    else if (Chronometre >= 0.9f && TotalManagement.Instance.PropellerIIII != false)
                    {
                        Chronometre = 0.0f;
                    }
                }

                else if (Chronometre >= 0.6f && TotalManagement.Instance.PropellerIIII != true)
                {
                    Alarm.text = "No. 2 Lateral Propeller " + brokendown;

                    if (Chronometre >= 0.9f)
                    {
                        Chronometre = 0.0f;
                    }
                }

                else if (Chronometre >= 0.6f && TotalManagement.Instance.PropellerIIII != false)
                {
                    Chronometre = 0.0f;
                }
            }

            else if (Chronometre >= 0.3f && TotalManagement.Instance.PropellerIII != true)
            {
                Alarm.text = "No. 1 Lateral Propeller " + brokendown;

                if (Chronometre >= 0.6f && TotalManagement.Instance.PropellerIIII != true)
                {
                    Alarm.text = "No. 2 Lateral Propeller " + brokendown;

                    if (Chronometre >= 0.9f)
                    {
                        Chronometre = 0.0f;
                    }
                }

                else if (Chronometre >= 0.6f && TotalManagement.Instance.PropellerIIII != false)
                {
                    Chronometre = 0.0f;
                }
            }

            else if (Chronometre >= 0.3f && TotalManagement.Instance.PropellerIIII != true)
            {
                Alarm.text = "No. 2 Lateral Propeller " + brokendown;

                if (Chronometre >= 0.6f)
                {
                    Chronometre = 0.0f;
                }
            }

            else if (Chronometre >= 0.3f && TotalManagement.Instance.PropellerIIII != false)
            {
                Chronometre = 0.0f;
            }
        }
        
        else if (Chronometre >= 0.0f && TotalManagement.Instance.PropellerII != true)
        {
            Alarm.text = "Rear Gondola Propeller " + brokendown;

            if (Chronometre >= 0.3f && TotalManagement.Instance.PropellerIII != true)
            {
                Alarm.text = "No. 1 Lateral Propeller " + brokendown;

                if (Chronometre >= 0.6f && TotalManagement.Instance.PropellerIIII != true)
                {
                    Alarm.text = "No. 2 Lateral Propeller " + brokendown;

                    if (Chronometre >= 0.9f)
                    {
                        Chronometre = 0.0f;
                    }
                }

                else if (Chronometre >= 0.6f && TotalManagement.Instance.PropellerIIII != false)
                {
                    Chronometre = 0.0f;
                }
            }

            else if (Chronometre >= 0.3f && TotalManagement.Instance.PropellerIIII != true)
            {
                Alarm.text = "No. 2 Lateral Propeller " + brokendown;

                if (Chronometre >= 0.6f)
                {
                    Chronometre = 0.0f;
                }
            }

            else if (Chronometre >= 0.3f && TotalManagement.Instance.PropellerIIII != false)
            {
                Chronometre = 0.0f;
            }
        }

        else if (Chronometre >= 0.0f && TotalManagement.Instance.PropellerIII != true)
        {
            Alarm.text = "No. 1 Lateral Propeller " + brokendown;

            if (Chronometre >= 0.3f && TotalManagement.Instance.PropellerIIII != true)
            {
                Alarm.text = "No. 2 Lateral Propeller " + brokendown;

                if (Chronometre >= 0.6f)
                {
                    Chronometre = 0.0f;
                }
            }

            else if (Chronometre >= 0.3f && TotalManagement.Instance.PropellerIIII != false)
            {
                Chronometre = 0.0f;
            }
        }

        else if (Chronometre >= 0.0f && TotalManagement.Instance.PropellerIIII != true)
        {
            Alarm.text = "No. 2 Lateral Propeller " + brokendown;

            if (Chronometre >= 0.3f)
            {
                Chronometre = 0.0f;
            }
        }

        else if (Chronometre >= 0.0f && TotalManagement.Instance.PropellerIIII != false)
        {
            if (Chronometre >= 0.3f)
            {
                Chronometre = 0.0f;
            }
        }

        if (TotalManagement.Instance.PropellerI != false && TotalManagement.Instance.PropellerII != false && TotalManagement.Instance.PropellerIII != false && TotalManagement.Instance.PropellerIIII != false)
        {
            alarm = 0;
        }
    }

    void FireAlarm()
    {
        Alarm.text = firealarm + ", Airship On " + fire;

        if (TotalManagement.Instance.Fire != true)
        {
            alarm = 0;
        }
    }

    void Green()
    {
        if (TotalManagement.Instance.PropellerI != true || TotalManagement.Instance.PropellerII != true || TotalManagement.Instance.PropellerIII != true || TotalManagement.Instance.PropellerIIII != true)
        {
            alarm = 3;
        }

        else if (TotalManagement.Instance.PropellerI != false && TotalManagement.Instance.PropellerII != false && TotalManagement.Instance.PropellerIII != false && TotalManagement.Instance.PropellerIIII != false)
        {
            Chronometre += Time.deltaTime;

            Alarm.text = "Condition " + allgreen;

            if (Chronometre >= 0.3f)
            {
                alarm = 0;

                Chronometre = 0.0f;
            }

            if (airship.AirshipDurability <= 0.3f)
            {
                alarm = 0;

                Chronometre = 0.0f;
            }
        }
    }

    void InsufficientMerit()
    {
        Alarm.text = "Insufficient " + merit;

        if (TotalManagement.Instance.PropellerI != true || TotalManagement.Instance.PropellerII != true || TotalManagement.Instance.PropellerIII != true || TotalManagement.Instance.PropellerIIII != true)
        {
            alarm = 3;
        }

        else if (TotalManagement.Instance.PropellerI != false && TotalManagement.Instance.PropellerII != false && TotalManagement.Instance.PropellerIII != false && TotalManagement.Instance.PropellerIIII != false)
        {
            alarm = 0;
        }
    }
}
