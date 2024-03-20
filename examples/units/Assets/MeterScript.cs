using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MeterScript : MonoBehaviour
{
    public Image fgImage;

    public float meterMax = 100;
    public float meterValue;

    public Color fgColor;
    public TMP_Text meterTextLabel;

    public string meterLabel = "";

    // Start is called before the first frame update
    void Start()
    {
        meterValue = meterMax;

        fgImage.fillAmount = 0.5f;

        fgImage.color = fgColor;

        meterTextLabel.text = meterLabel;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void SetMeter(float valueToSetTo)
    {
        meterValue = valueToSetTo;
        fgImage.fillAmount = meterValue / meterMax;
    }

    public void UpdateMeter(float valueChange)
    {
        meterValue -= valueChange;
        fgImage.fillAmount = meterValue / meterMax;
    }
}
