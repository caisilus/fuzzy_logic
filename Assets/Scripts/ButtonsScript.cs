using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    public void PauseTime()
    {
        if (Time.timeScale == 1f)
            Time.timeScale = 0f;
    }
    public void StartTime()
    {
        if (Time.timeScale == 0f)
            Time.timeScale = 1f;
    }
    public void RestartTime()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (Time.timeScale == 1f)
            Time.timeScale = 0f;
    }
}
