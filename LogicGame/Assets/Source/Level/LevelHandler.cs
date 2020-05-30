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
    public GameObject pushButton;
    public GameObject successBox;
    public Material lineMaterial;
    public static Level currentLevel;

    private List<Pushbutton> buttons;
    private ConnectionRenderer connectionRenderer;

    // Start is called before the first frame update
    void Start()
    {
        buttons = new List<Pushbutton>();

        connectionRenderer = new ConnectionRenderer(lineMaterial);

        currentLevel = new Level();
        currentLevel.loadElementsFromFile(CrossSceneInfo.RequestedLevel);
        gridOffsetY = 0.05f * Screen.height;
        gridOffsetX = 0.12f * Screen.width;
        gridScaleX = Screen.width / Level.dimensions.x;
        gridScaleY = Screen.width / Level.dimensions.y;

        currentLevel.connectElements();
        drawElements();
        drawPushbuttons();
        addConnections();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var textureRect = elementTexture.GetComponent<SpriteRenderer>().sprite.textureRect;
            foreach (var button in buttons)
            {
                var buttonPos = worldToScreenPoint(button.obj.transform.position);
                // Debug.LogFormat("Clicked at {2}; Button at {0} (Screenspace: {1})", buttonPos, button.obj.transform.position, Input.mousePosition);
                if (Input.mousePosition.x > buttonPos.x - textureRect.width / 2
                    && Input.mousePosition.x < buttonPos.x + textureRect.width / 2
                    && Input.mousePosition.y < buttonPos.y + textureRect.height / 2
                    && Input.mousePosition.y > buttonPos.y - textureRect.height / 2)
                {
                    button.inputs[0] = button.inputs[0] == true ? false : true;
                    getElement(button.connectedTo).inputs[(int)button.connectedTo.z] = button.inputs[0];
                    ConnectionHandler.setConnectionEnabled(button.inputs[0], button.position, button.connectedTo);
                    updateConnections();
                }
            }
        }
    }

    private void updateConnections()
    {
        foreach (var line in currentLevel.elements)
        {
            foreach (Element e in line)
            {
                e.computeOutput();

                if (e.connectedTo == new Vector3(9, 9, 9))
                {
                    // SUCCESS BOX
                }
                else
                {
                    getElement(e.connectedTo).inputs[(int)e.connectedTo.z] = e.output;
                    ConnectionHandler.setConnectionEnabled(e.output, e.position, e.connectedTo);
                }
            }
        }
    }

    void OnPostRender()
    {
        connectionRenderer.OnPostRender();
    }

    Vector2 screenToWorldPoint(Vector2 screenPos)
    {
        return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 0));
    }

    Vector2 worldToScreenPoint(Vector2 worldPos)
    {
        return GetComponent<Camera>().WorldToScreenPoint(worldPos);
    }

    void addConnections()
    {
        foreach (var line in currentLevel.elements)
        {
            foreach (Element e in line)
            {
                ConnectionHandler.addConnection(e);

                Debug.LogFormat("Adding Connection from {0}", e.position);
            }
        }
    }

    void drawElements()
    {
        foreach (var line in currentLevel.elements)
        {
            foreach (Element e in line)
            {
                e.obj = Instantiate(elementTexture) as GameObject;
                e.obj.name = "element" + e.position.x + e.position.y;

                Vector2 position = screenToWorldPoint(calculateGridPos(e.position));
                Debug.LogFormat("Drawing element {0}, {1}", e.obj.name, position);
                e.obj.transform.position = position;
            }
        }
    }

    public void drawPushbuttons()
    {
        foreach (Element e in currentLevel.elements[0])
        {
            for (int n = 0; n < e.numInputs; n++)
            {
                Pushbutton pb = new Pushbutton(new Vector2(e.position.x, -1), new Vector3(e.position.x, e.position.y, n));
                var textureRect = e.obj.GetComponent<SpriteRenderer>().sprite.textureRect;

                var targetInputs = getElement(pb.connectedTo).numInputs;
                pb.position.x += 0.2f * (n < 1 ? -1 : 1);

                var position = calculateGridPos(pb.position);

                pb.obj = Instantiate(pushButton) as GameObject;
                pb.obj.name = "pushButton" + pb.position.x + n;


                pb.obj.transform.position = screenToWorldPoint(position);
                ConnectionHandler.addConnection(pb);
                buttons.Add(pb);
            }
        }
    }

    public static Vector2 calculateGridPos(Vector2 position)
    {
        float gridPositionX = gridOffsetX + position.x * gridScaleX;
        float gridPositionY = gridOffsetY + (position.y + 1) * gridScaleY;
        return new Vector2(gridPositionX, gridPositionY);
    }

    public static Element getElement(Vector2 pos)
    {
        if (pos.y >= 0)
        {
            foreach (Element e in currentLevel.elements[(int)pos.y])
            {
                if (e.position.x == pos.x)
                    return e;
            }
        }
        return new Element_And(new Vector2Int(10, 10), new Vector3Int(10, 10, 10), 10);
    }

}
