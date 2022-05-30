using UnityEngine;

public class StartButtonScript : MonoBehaviour
{
    public void StartTime()
    {
        if (Time.timeScale == 0f)
            Time.timeScale = 1f;
    }
}
