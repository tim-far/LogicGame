using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    private float gridOffsetX;
    private float gridOffsetY;
    private float gridScaleX;
    private float gridScaleY;

    public GameObject elementTexture;

    // Start is called before the first frame update
    void Start()
    {
        gridOffsetY = 0.2f * Screen.height;
        gridOffsetX = 0.1f * Screen.width;
        gridScaleX = Screen.width / 3.8f;
        gridScaleY = Screen.width / 4;

        LevelController.initialize();
        LevelController.loadLevel("Assets/Levels/test.lvl");
        drawElements(LevelController.currentLevel.elements);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector2 screenToWorldPoint(Vector2 screenPos)
    {
        return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 0));
    }

}
