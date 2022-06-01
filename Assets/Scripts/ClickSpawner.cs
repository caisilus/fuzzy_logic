using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSpawner : MonoBehaviour
{
    public GameObject[] prefabs; //Prefabs to spawn

    Camera c;

    // Start is called before the first frame update
    void Start()
    {
        c = GetComponent<Camera>();
        if (prefabs.Length == 0)
        {
            Debug.LogError("You haven't assigned enough Prefabs to spawn");
        }
        if(prefabs.Length > 3)
        {
            Debug.LogError("You have assigned too much Prefabs to spawn");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                GameObject outObject;
                if(DetectObject(Input.mousePosition, out outObject) && outObject.tag == "npc car")
                {
                    Destroy(outObject);
                    return;
                }

            }
            Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, c.transform.position.z * -1.0f));
            if (!DetectObject(Input.mousePosition))
            {
                GameObject go = Instantiate(prefabs[0], p, Quaternion.identity);
                go.name += " _instantiated";
                go.GetComponent<NPCCarController>().setMoveDir(true);
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, c.transform.position.z * -1.0f));
            if (!DetectObject(Input.mousePosition))
            {
                GameObject go = Instantiate(prefabs[0], p, Quaternion.identity);
                go.name += " _instantiated";
                go.GetComponent<NPCCarController>().setMoveDir(false);
            }
        }
    }

    bool DetectObject(Vector3 target, out GameObject gameObject)
    {
        Ray ray = c.ScreenPointToRay(target);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        if (hit.collider != null)
        {
            gameObject = hit.collider.gameObject;
            return true;
        }
        gameObject = null;
        return false;
    }
    bool DetectObject(Vector3 target)
    {
        Ray ray = c.ScreenPointToRay(target);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }
}

