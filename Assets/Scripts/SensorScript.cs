using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorScript : MonoBehaviour
{
    [SerializeField] private float max_distance = 5f;
    public float Distance { get; private set; }

    private void Start()
    {
        Distance = max_distance;
    }
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward * max_distance);
        if (hit)
        {
            Debug.Log(hit.transform.gameObject.tag);
            if (hit.transform.gameObject.tag != "wall")
                return;
            Debug.Log("Hit the wall!");
            Distance = Mathf.Min(hit.distance, max_distance);
            if (Distance < max_distance)
                Debug.Log("Object close");
        }
    }
}
