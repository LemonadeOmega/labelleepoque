using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorVisualEffect : MonoBehaviour
{
    public GameObject CursorVisualisation;
    public GameObject GearI;
    public GameObject GearII;

    [SerializeField] Texture2D CursorImage;

    public float GearRotationSpeed;

    public bool Operation;

    void Start()
    {
        Cursor.SetCursor(CursorImage, Vector2.zero, CursorMode.ForceSoftware);
        Cursor.visible = false;

        CursorVisualisation.transform.position = Input.mousePosition;

        GearI.gameObject.SetActive(false);
        GearII.gameObject.SetActive(false);

        GearRotationSpeed = 60.0f;

        Operation = false;
    }

    void Update()
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

        StartCoroutine(CursorVisualiation());
        StartCoroutine(GearRotation());
    }

    public void InteractionI()
    {
        Operation = true;
    }

    public void InteractionII()
    {
        Operation = false;
    }

    IEnumerator CursorVisualiation()
    {
        Cursor.visible = false;

        CursorVisualisation.transform.position = Input.mousePosition;

        yield return null;
    }

    IEnumerator GearRotation()
    {
        GearI.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f) * GearRotationSpeed * Time.deltaTime);     
        GearII.transform.Rotate(new Vector3(0.0f, 0.0f, -1.0f) * GearRotationSpeed * Time.deltaTime);
     
        yield return null;
    }
}
