using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorScript : MonoBehaviour
{
    [SerializeField] private float maxDistance;
    public float Distance { get; private set; }

    public float MaxDistance { 
        get { return maxDistance; }
        set {
            maxDistance = value;
            Distance = maxDistance;
        } 
    }  

    private void Start()
    {
        Distance = maxDistance;
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(Position(), Forward() * maxDistance);
        if (hit)
        {
            if (hit.transform.gameObject.tag != "wall" && hit.transform.gameObject.tag != "npc car")
                return;
            Distance = Mathf.Min(hit.distance, maxDistance);
            //if (Distance < max_distance)
                //Debug.Log("Object close");
        } else
        {
            Distance = maxDistance;
        }
    }

    private Vector2 Position() => new Vector2(transform.position.x, transform.position.y);

    // Green arrow in editor
    private Vector2 Forward() => new Vector2(transform.up.x, transform.up.y);
}
