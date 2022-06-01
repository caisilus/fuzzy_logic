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
        RaycastHit2D hit = Physics2D.Raycast(Position(), Forward() * max_distance);
        if (hit)
        {
            if (hit.transform.gameObject.tag != "wall")
                return;
            Distance = Mathf.Min(hit.distance, max_distance);
            //if (Distance < max_distance)
                //Debug.Log("Object close");
        } else
        {
            Distance = max_distance;
        }
    }

    private Vector2 Position() => new Vector2(transform.position.x, transform.position.y);

    // Green arrow in editor
    private Vector2 Forward() => new Vector2(transform.up.x, transform.up.y);
}
