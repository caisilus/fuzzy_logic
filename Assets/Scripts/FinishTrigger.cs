using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] ButtonsScript gameController;
    public void OnTriggerEnter2D(Collider2D other)
    {
        CarController controller = other.GetComponent<CarController>();
        if (controller != null)
        {
            if (controller.IsTurnedBack())
            {
                gameController.PauseTime();
            } 
            else
            {
                gameController.RestartTime();
            }
        }
    }
}
