﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    private float gridOffsetX;
    private float gridOffsetY;
    private float gridScaleX;
    private float gridScaleY;

    public GameObject elementTexture;
    public static Level currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        gridOffsetY = 0.05f * Screen.height;
        gridOffsetX = 0.1f * Screen.width;
        gridScaleX = Screen.width / 3.8f;
        gridScaleY = Screen.width / 4;

        currentLevel = new Level();
        currentLevel.loadElementsFromFile(CrossSceneInfo.RequestedLevel);
        currentLevel.connectElements();
        drawElements(currentLevel.elements);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector2 screenToWorldPoint(Vector2 screenPos)
    {
        return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 0));
    }

    void drawElements(List<Element> elements)
    {
        foreach (Element e in elements)
        {
            e.texture = Instantiate(elementTexture) as GameObject;
            e.texture.name = "element" + e.position.x + e.position.y;

            float positionX = gridOffsetX + e.position.x * gridScaleX;
            float positionY = gridOffsetY + e.position.y * gridScaleY;

            Vector2 position = screenToWorldPoint(new Vector2(positionX, positionY));
            Debug.LogFormat("Drawing element {0}, {1}", e.texture.name, position);
            e.texture.transform.position = position;
        }
    }
}
