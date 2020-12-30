using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject baslaImage;

    string hangiOyun;

    int birinciCarpan;

    [SerializeField]
    private Text soruText, birinciSonucText, ikinciSonucText, ucuncuSonucText;

    int ikinciCarpan;

    int dogruSonuc;
    int birinciYanlisSonuc, ikinciYanlisSonuc;

    [SerializeField]
    private Text dogruAdetText, yanlisAdetText, toplamPuanText;

    int dogruAdet, yanlisAdet, toplamPuan;

    [SerializeField]
    private GameObject dogruImage, yanlisImage;

    PlayerManager playerManager;

    private void Awake()
    {
        playerManager = Object.FindObjectOfType<PlayerManager>();
    }

    void Start()
    {
        dogruAdet = 0;
        yanlisAdet = 0;
        toplamPuan = 0;

        dogruImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        yanlisImage.GetComponent<RectTransform>().localScale = Vector3.zero;

        if (PlayerPrefs.HasKey("hangiOyun"))
        {
            hangiOyun = PlayerPrefs.GetString("hangiOyun");
        }

        StartCoroutine(baslaYaziRoutine());
    }

    IEnumerator baslaYaziRoutine()
    {
        baslaImage.GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        yield return new WaitForSeconds(0.6f);
        baslaImage.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        baslaImage.GetComponent<CanvasGroup>().DOFade(0, 1f);
        OyunaBasla();
    }

    void OyunaBasla()
    {
        playerManager.rotaDegissinMi = true; 
        soruyuYazdir();
    }

    void BirinciCarpaniAyarla() 
    {
        switch (hangiOyun)
        {
            case "iki":
                birinciCarpan = 2;
                break;

            case "uc ":
                birinciCarpan = 3;
                break;

            case "dort":
                birinciCarpan = 4;
                break;

            case "bes":
                birinciCarpan = 5;
                break;

            case "alti":
                birinciCarpan = 6;
                break;

            case "yedi":
                birinciCarpan = 7;
                break;

            case "sekiz":
                birinciCarpan = 8;
                break;

            case "dokuz":
                birinciCarpan = 9;
                break;

            case "on":
                birinciCarpan = 10;
                break;

            case "karisik":
                birinciCarpan = Random.Range(2,11);
                break;
        }

    }

    void soruyuYazdir()
    {
        BirinciCarpaniAyarla();

        ikinciCarpan = Random.Range(2, 11);

        int rastgeleDeger = Random.Range(1, 100);

        if (rastgeleDeger <= 50)
        {
            soruText.text = birinciCarpan.ToString() + "x" + ikinciCarpan.ToString();
        }
        else
        {
            soruText.text = ikinciCarpan.ToString() + "x" + birinciCarpan.ToString();
        }

        dogruSonuc = birinciCarpan * ikinciCarpan;

        sonuclariYazdir();
    }

    void sonuclariYazdir()
    {
        birinciYanlisSonuc = dogruSonuc + Random.Range(2, 10);

        if(dogruSonuc > 10)
        {
            ikinciYanlisSonuc = dogruSonuc - Random.Range(2, 8);
        }else
        {
            ikinciYanlisSonuc = Mathf.Abs(dogruSonuc - Random.Range(1, 5));
        }

        int rastgeleDeger = Random.Range(1, 100);

        if (rastgeleDeger <= 33)
        {
            birinciSonucText.text = dogruSonuc.ToString();
            ikinciSonucText.text = birinciYanlisSonuc.ToString();
            ucuncuSonucText.text = ikinciYanlisSonuc.ToString();
        } else if(rastgeleDeger<=66)
        {
            ikinciSonucText.text = dogruSonuc.ToString();
            birinciSonucText.text = birinciYanlisSonuc.ToString();
            ucuncuSonucText.text = ikinciYanlisSonuc.ToString();
        }
        else
        {
            ucuncuSonucText.text = dogruSonuc.ToString();
            ikinciSonucText.text = birinciYanlisSonuc.ToString();
            birinciSonucText.text = ikinciYanlisSonuc.ToString();
        }
    }


    public void SonucuKontrolEt(int textSonucu)
    {
        dogruImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        yanlisImage.GetComponent<RectTransform>().localScale = Vector3.zero;

        if (textSonucu == dogruSonuc)
        {
            dogruAdet++;
            toplamPuan += 10;
            dogruImage.GetComponent<RectTransform>().DOScale(1f, .5f).SetEase(Ease.OutBack);
        }
        else
        {
            yanlisAdet++;
            yanlisImage.GetComponent<RectTransform>().DOScale(1f, .5f).SetEase(Ease.OutBack);
        }

        dogruAdetText.text = dogruAdet.ToString() + " DOĞRU";
        yanlisAdetText.text = yanlisAdet.ToString() + " YANLIŞ";
        toplamPuanText.text = toplamPuan.ToString() + " P";

        soruyuYazdir();
    }
}

