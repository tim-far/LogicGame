using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject ob;
    public GameObject player;

    private Utility utility;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started GameHandler");   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                player = createGameObject(t);
            }
            else if (t.phase == TouchPhase.Ended)
            {
               Destroy(player);
            }
            else if (t.phase == TouchPhase.Moved && ob)
            {
                player.transform.position = getTouchPosition(t.position);
            }
        }
     
    }

    Vector2 getTouchPosition(Vector2 touchPosition)
    {
        return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, 0));
    }

    GameObject createGameObject(Touch t)
    {
        GameObject c = Instantiate(ob) as GameObject;
        c.name = "test";
        c.transform.position = getTouchPosition(t.position);
        return c;   
    }
}
