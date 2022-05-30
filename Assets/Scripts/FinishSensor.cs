using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishSensor : MonoBehaviour
{
    [SerializeField] Transform finish;

    public float Distance { get; private set; }
    public float Angle { get; private set; }

    private void FixedUpdate()
    {
        Vector2 selfPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 selfDirection = Forward(transform.up);
        Vector2 finishPostion = new Vector2(finish.position.x, finish.position.y);
        Vector2 finishDirection = finishPostion - selfPosition; //Direction from car to finish
        Distance = Vector2.Distance(selfPosition, finishPostion);
        Angle = Vector2.SignedAngle(selfDirection, finishDirection);
    }

    // Green arrow to Vector2
    private Vector2 Forward(Vector3 up) => new Vector2(up.x, up.y);
}
