using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorScript : MonoBehaviour
{
    public bool collided = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        print("S");
        if (other.gameObject.tag == "wall"){
            collided = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        print("S");
        if (other.gameObject.tag == "wall"){
            collided = false;
        }
        
    }
}
