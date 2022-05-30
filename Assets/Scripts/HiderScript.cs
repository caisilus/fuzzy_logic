using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiderScript : MonoBehaviour
{
    public bool collisions_enabled;
    private Renderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
        collisions_enabled = false;
        _renderer = gameObject.GetComponent<Renderer>();
        setTransparency();
    }

    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            collisions_enabled = !collisions_enabled;
            Debug.Log("Object status = " + collisions_enabled);
            setTransparency();
        }
    }

    private void setTransparency()
    {
        Color c = _renderer.material.color;
        if (collisions_enabled)
        {
            _renderer.material.color = new Color(c.r, c.g, c.b, 1.0f);
        }
        else
        {
            _renderer.material.color = new Color(c.r, c.g, c.b, 0.5f);
        }
    }
}
