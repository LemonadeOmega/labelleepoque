using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreySky : MonoBehaviour
{
    public Material BackgroundMaterial;

    public float FlowSpeed = 0;

    void Update()
    {
        Vector2 direction = Vector2.left;

        BackgroundMaterial.mainTextureOffset += direction * FlowSpeed * Time.deltaTime;
    }
}