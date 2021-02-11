using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchDown : MonoBehaviour
{
    private List<GameObject> touchedObjects;

    void Awake()
    {
        touchedObjects = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            touchedObjects.Add(null);
        }
    }


    void Update()
    {
        RaycastHit hit = new RaycastHit();
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase.Equals(TouchPhase.Began))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                if (Physics.Raycast(ray, out hit))
                {
                    hit.transform.gameObject.SendMessage("OnMouseDown");
                    touchedObjects.Insert(i, hit.transform.gameObject);
                }

            }
            else if (Input.GetTouch(i).phase.Equals(TouchPhase.Ended))
            {
                hit.transform.gameObject.SendMessage("OnMouseUp");
                touchedObjects[i] = null;
            }
        }
    }
}

