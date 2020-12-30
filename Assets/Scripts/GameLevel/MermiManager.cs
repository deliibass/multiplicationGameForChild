using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermiManager : MonoBehaviour
{
    float mermiHizi = 15f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * mermiHizi);
    }
}
