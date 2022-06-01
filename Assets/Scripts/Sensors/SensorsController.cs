using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorsController : MonoBehaviour
{
    [SerializeField] SensorScript left;
    [SerializeField] SensorScript right;
    [SerializeField] SensorScript back;
    [SerializeField] FinishSensor finish;

    private float maxDistance = 1f;

    public float MaxDistance
    {
        get { return maxDistance; }

        set 
        {
            Debug.Log(value);
            if (maxDistance <= 0)
                return;
            maxDistance = value;
            left.MaxDistance = maxDistance;
            right.MaxDistance = maxDistance;
            back.MaxDistance = maxDistance;
        }
    }
}
