using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class ShaderProperties : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

//    void Update()
//    {
//        if (gameObject.transform.hasChanged)
//        {
//            Renderer[] Shades = GameObject.FindObjectsOfType<Renderer>();
//            foreach (var Shade in Shades)
//            {
//                Material material;
//#if UNITY_EDITOR
//                material = Shade.sharedMaterial;
//#else
//                material = Shade.material;
//#endif
//                if (string.Compare(material.shader.name, "Shader Graphs/toonramp") == 0)
//                {
//                    material.SetVector("_lightdirection", transform.forward);
//                }
//            }
//        }
//    }
}
