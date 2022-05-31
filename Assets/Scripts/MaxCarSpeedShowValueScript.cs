using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MaxCarSpeedShowValueScript : MonoBehaviour
{
    TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        //Debug.Log(text);

    }

    public void TextUpdate(float value)
    {
        //Debug.Log(text);
        text.text = "MAX CAR SPPED: " + Mathf.RoundToInt(value);
    }
}
