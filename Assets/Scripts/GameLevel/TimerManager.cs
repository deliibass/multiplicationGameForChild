using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private Text SureText;

    int kalanSure;
    bool sureSaysinmi;

    void Start()
    {
        kalanSure = 30;
        sureSaysinmi = true;

        StartCoroutine(SureTimerRoutine());
    }

    IEnumerator SureTimerRoutine()
    {
        while (sureSaysinmi)
        {
            yield return new WaitForSeconds(1f);

            if (kalanSure < 10)
            {
                SureText.text = "0" + kalanSure.ToString();
            }else
            {
                SureText.text = kalanSure.ToString();
            }

            if (kalanSure <= 0)
            {
                sureSaysinmi = false;
                SureText.text = "";
            }
            kalanSure--;
        }
    }
}
