using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorVisualEffect : MonoBehaviour
{
    public GameObject CursorVisualisationEffect;
    public GameObject GearI;
    public GameObject GearII;

    [SerializeField] Texture2D CursorImage;

    public float GearRotationSpeed;

    public bool Operation;

    void Start()
    {
        Cursor.SetCursor(CursorImage, Vector2.zero, CursorMode.ForceSoftware);
        Cursor.visible = false;

        CursorVisualisationEffect.transform.position = Input.mousePosition;

        GearI.gameObject.SetActive(false);
        GearII.gameObject.SetActive(false);

        GearRotationSpeed = 60.0f;

        Operation = false;
    }

    void Update()
    {
        StartCoroutine(CursorEffectVisualiation());
        StartCoroutine(GearRotationEffect());
        StartCoroutine(GearEffectVisualisation());
    }

    IEnumerator CursorEffectVisualiation()
    {
        Cursor.visible = false;

        CursorVisualisationEffect.transform.position = Input.mousePosition;

        yield return new WaitForSeconds(0.02f);
    }

    IEnumerator GearRotationEffect()
    {
        GearI.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f) * GearRotationSpeed * Time.deltaTime);
        GearII.transform.Rotate(new Vector3(0.0f, 0.0f, -1.0f) * GearRotationSpeed * Time.deltaTime);

        yield return new WaitForSeconds(0.02f);
    }

    IEnumerator GearEffectVisualisation()
    {

        switch (Operation)
        {
            case true:
                GearI.gameObject.SetActive(true);
                GearII.gameObject.SetActive(true);
                break;
            case false:
                GearI.gameObject.SetActive(false);
                GearII.gameObject.SetActive(false);
                break;
        }

        yield return new WaitForSeconds(0.02f);
    }

    public void InteractionI()
    {
        Operation = true;
    }

    public void InteractionII()
    {
        Operation = false;
    }
}
