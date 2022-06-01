using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsScript : MonoBehaviour
{
    [SerializeField] Slider[] sliders;
    private void Start()
    {
        this.PauseTime();
    }
    public void PauseTime()
    {
        if (Time.timeScale == 1f)
            Time.timeScale = 0f;
    }
    public void StartTime()
    {
        if (Time.timeScale == 0f)
            Time.timeScale = 1f;
        foreach (Slider slider in sliders)
            slider.enabled = false;
    }
    public void RestartTime()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (Time.timeScale == 1f)
            Time.timeScale = 0f;
        foreach (Slider slider in sliders)
            slider.enabled = true;
    }
}
