using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPaneli;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip buttonClick;

    [SerializeField]
    private GameObject sesPaneli;

    bool sesPaneliAcikMi;
    void Start()
    {
        sesPaneliAcikMi = false;
        sesPaneli.GetComponent<RectTransform>().localPosition = new Vector3(0, -85, 0);

        menuPaneli.GetComponent<CanvasGroup>().DOFade(1, 1f);
        menuPaneli.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
    }

    public void ikinciLeveleGec()
    {
        if (PlayerPrefs.GetInt("sesinDurumu") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }

        SceneManager.LoadScene("ikinciMenuLevel");
    }

    public void AyarlariYap()
    {
        if (PlayerPrefs.GetInt("sesinDurumu") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }

        if (!sesPaneliAcikMi)
        {
            sesPaneli.GetComponent<RectTransform>().DOLocalMoveY(-135, 0.5f);
            sesPaneliAcikMi = true;
        }
        else
        {
            sesPaneli.GetComponent<RectTransform>().DOLocalMoveY(-85, 0.5f);
            sesPaneliAcikMi = false;
        }
    }

    public void CikisYap()
    {
        if (PlayerPrefs.GetInt("sesinDurumu") == 1)
        {
            audioSource.PlayOneShot(buttonClick);
        }

        Application.Quit();
    }

}
