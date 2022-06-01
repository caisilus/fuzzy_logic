using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SlidersScript : MonoBehaviour
{
    TextMeshProUGUI text;
    [SerializeField] string prefix;
    [SerializeField] Slider sliderController;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        TextUpdate(sliderController.value);
    }
    public void TextUpdate(float value)
    {
        text.SetText(prefix, value);
    }
}
