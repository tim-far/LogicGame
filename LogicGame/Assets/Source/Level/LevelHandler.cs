using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelHandler : MonoBehaviour
{
    private static float gridOffsetX;
    private static float gridOffsetY;
    private static float gridScaleX;
    private static float gridScaleY;

    public GameObject elementTexture;
    public Texture2D textureSize;
    public Material lineMaterial;
    public static Level currentLevel;

    private ConnectionRenderer connectionRenderer;

    // Start is called before the first frame update
    void Start()
    {
        if (!textureSize)
        {
            Debug.LogError("Please set the textureSize Object first!");
            return;
        }
        CrossSceneInfo.textureSize = textureSize;

        connectionRenderer = new ConnectionRenderer(lineMaterial);

        currentLevel = new Level();
        currentLevel.loadElementsFromFile(CrossSceneInfo.RequestedLevel);
        gridOffsetY = 0.05f * Screen.height;
        gridOffsetX = 0.1f * Screen.width;
        gridScaleX = Screen.width / Level.dimensions.x;
        gridScaleY = Screen.width / Level.dimensions.y;

        currentLevel.connectElements();
        drawElements(currentLevel.elements);
        drawConnections(currentLevel.elements);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnPostRender()
    {
        connectionRenderer.OnPostRender();
    }

    Vector2 screenToWorldPoint(Vector2 screenPos)
    {
        return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 0));
    }

    void drawConnections(List<Element> elements)
    {
        foreach (Element e in elements)
        {
            ConnectionHandler.addConnection(e);

            Debug.LogFormat("Adding Connection from {0}", e.position);
        }
    }

    void drawElements(List<Element> elements)
    {
        foreach (Element e in elements)
        {
            e.obj = Instantiate(elementTexture) as GameObject;
            e.obj.name = "element" + e.position.x + e.position.y;

            Vector2 position = screenToWorldPoint(calculateGridPos(e.position));
            Debug.LogFormat("Drawing element {0}, {1}, {2}, {3}", e.obj.name, position, textureSize.width, textureSize.height);
            e.obj.transform.position = position;
        }
    }

    public static Vector2 calculateGridPos(Vector2Int position)
    {
        float gridPositionX = gridOffsetX + position.x * gridScaleX;
        float gridPositionY = gridOffsetY + (position.y + 1) * gridScaleY;
        return new Vector2(gridPositionX, gridPositionY);
    }

    public static int getElementsAtY(int y)
    {
        int result = 0;
        foreach (Element e in currentLevel.elements)
        {
            if (e.position.y == y)
                result++;
        }
        return result;
    }

    public static Element getElement(Vector2Int pos)
    {
        foreach (Element e in currentLevel.elements)
        {
            if (e.position == pos)
                return e;
        }
        return new Element_And(new Vector2Int(10, 10), new Vector3Int(10, 10, 10), 10);
    }

}
