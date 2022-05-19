using UnityEngine;

public class StartButtonScript : MonoBehaviour
{
    public void Start()
    {
        if (Time.timeScale == 0f)
            Time.timeScale = 1f;
    }
}
