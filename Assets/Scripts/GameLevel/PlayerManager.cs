using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Transform gun;

    float angle;
    float donusHizi = 5f;

    [SerializeField]
    private GameObject[] mermiPrefab;

    [SerializeField]
    private Transform mermiYeri;
    
    float ikiMermiArasiSure = 300f;

    float sonrakiAtis;

    public bool rotaDegissinMi;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip topClick;

    private void Start()
    {
        rotaDegissinMi = true;
    }

    void Update()
    {
        if (rotaDegissinMi)
        {
            RotateDegistir();
        }

    }

    void RotateDegistir()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        if(angle<36 && angle > -41)
        {
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, rotation, donusHizi * Time.deltaTime);
        }


        if (Input.GetMouseButtonDown(0))
        {
            

            if (Time.time > sonrakiAtis)
            {
                sonrakiAtis = Time.time + ikiMermiArasiSure / 1000;
                mermiAt();
            }
        }
        
        
    }

    void mermiAt()
    {
        if (PlayerPrefs.GetInt("sesinDurumu") == 1)
        {
            audioSource.PlayOneShot(topClick);
        }
        GameObject mermi = Instantiate(mermiPrefab[Random.Range(0,mermiPrefab.Length)], mermiYeri.position, mermiYeri.rotation) as GameObject;
    }
}
