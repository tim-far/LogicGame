using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPosition : MonoBehaviour
{
    public GameObject gobj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            if(t.phase == TouchPhase.Began)
            {
                Debug.Log("Touch Began");
                gobj = createCircle();
            }
            else if (t.phase == TouchPhase.Ended)
            {
                Debug.Log("Touch Ended");
                Destroy(gobj);
            }
        }
    }

    GameObject createCircle()
    {
        GameObject tmp = Instantiate(gobj) as GameObject;
        tmp.name = "Circle";
        tmp.transform.position = transform.position;
        return tmp;
    }
}
