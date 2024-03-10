using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FigMove : MonoBehaviour
{
    bool Clicked;
    Camera cam;
    Collider PlaneCollider;
    RaycastHit hit;
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        PlaneCollider = GameObject.Find("Map").GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Clicked)
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == PlaneCollider)
                {
                    transform.position = hit.point;
                }
            }
        }
    }

    private void OnMouseDown()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == this)
            {
                Clicked = true;
            }
        }
    }

    private void OnMouseUp()
    {
        Clicked = false;
    }
}
