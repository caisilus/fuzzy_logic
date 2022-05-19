using UnityEngine;

public class PauseButtonScript : MonoBehaviour
{
    public void Pause()
    {
        if (Time.timeScale == 1f)
            Time.timeScale = 0f;
    }
}
