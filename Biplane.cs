using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biplane : MonoBehaviour
{
    public GameObject biplanepropeller;

    public float PropellerRotationSpeed;


    void Start()
    {
        PropellerRotationSpeed = 150.0f;    
    }

    void Update()
    {
        StartCoroutine(BiplanePropellerinOperation());
    }

    IEnumerator BiplanePropellerinOperation()
    {
        biplanepropeller.transform.Rotate(new Vector3(0.0f, 15.0f, 0.0f) * PropellerRotationSpeed * Time.deltaTime);

        yield return null;
    }
}
