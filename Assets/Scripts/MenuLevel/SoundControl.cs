using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    private void Start()
    {
        SesAc();
    }

    public void SesAc()
    {
        PlayerPrefs.SetInt("sesinDurumu", 1);
    }

    public void SesKapa()
    {
        PlayerPrefs.SetInt("sesinDurumu", 0);
    }
}
