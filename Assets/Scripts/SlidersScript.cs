using UnityEngine;
using TMPro;

public class SlidersScript : MonoBehaviour
{
    TextMeshProUGUI text;
    [SerializeField] string prefix;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    public void TextUpdate(float value)
    {
        text.SetText(prefix, Mathf.RoundToInt(value));
    }
}
