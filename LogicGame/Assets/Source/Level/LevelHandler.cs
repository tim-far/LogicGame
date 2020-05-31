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
    public GameObject pushButtonTexture;
    public GameObject successBoxTexture;
    public Material lineMaterial;
    public static Level currentLevel;

    private static Successbox successbox;
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
        drawSuccessbox();
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
                // check if one of the pushbuttins has been clicked and switch its state if yes
                var buttonPos = worldToScreenPoint(button.obj.transform.position);
                // Debug.LogFormat("Clicked at {2}; Button at {0} (Screenspace: {1})", buttonPos, button.obj.transform.position, Input.mousePosition);
                if (Input.mousePosition.x > buttonPos.x - textureRect.width / 2
                    && Input.mousePosition.x < buttonPos.x + textureRect.width / 2
                    && Input.mousePosition.y < buttonPos.y + textureRect.height / 2
                    && Input.mousePosition.y > buttonPos.y - textureRect.height / 2)
                {
                    // swich input state and use it as the gates input
                    button.inputs[0] = button.inputs[0] == true ? false : true;
                    // get the element the pushbuttin is connected to and set its input to the pushbuttin state
                    getElement(button.connectedTo).inputs[(int)button.connectedTo.z] = button.inputs[0];
                    // update the connection information for the renderer
                    ConnectionHandler.setConnectionEnabled(button.inputs[0], button.position, button.connectedTo);
                    // update all connections
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
                // get the element the current on is connected to and set its input to the output of the current element
                // the utputs have to be calculated per row before moving to the next higer row because all inputs have to be set correctly
                getElement(e.connectedTo).inputs[(int)e.connectedTo.z] = e.output;
                ConnectionHandler.setConnectionEnabled(e.output, e.position, e.connectedTo);
            }
        }
    }

    void OnPostRender()
    {
        // renderer for connections
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
                if (e.connectedTo == new Vector3(9, 9, 9))
                {
                    // this vector indicated that the element is connected to the level success indicator 
                    // the placeholder needs to be removed and replaces with the actual successbox position
                    e.connectedTo = new Vector3(successbox.position.x, successbox.position.y, 0);
                    ConnectionHandler.addConnection(e);

                }
                else
                {
                    ConnectionHandler.addConnection(e);
                }
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
                pb.position.x += 0.21f * (n < 1 ? -1 : 1);

                var position = calculateGridPos(pb.position);

                pb.obj = Instantiate(pushButtonTexture) as GameObject;
                pb.obj.name = "pushButton" + pb.position.x + n;


                pb.obj.transform.position = screenToWorldPoint(position);
                ConnectionHandler.addConnection(pb);
                buttons.Add(pb);
            }
        }
    }

    public void drawSuccessbox()
    {
        Element e = currentLevel.elements[currentLevel.elements.Count - 1][0];
        successbox = new Successbox(new Vector2(e.position.x, e.position.y + 1));
        successbox.obj = Instantiate(successBoxTexture) as GameObject;
        successbox.obj.name = "successbox";
        successbox.obj.transform.position = screenToWorldPoint(calculateGridPos(successbox.position));
    }

    public static Vector2 calculateGridPos(Vector2 position)
    {
        // translate the coordinated e.g. (1, 0) into a position on the screen in pixels e.g. (200, 0)
        float gridPositionX = gridOffsetX + position.x * gridScaleX;
        float gridPositionY = gridOffsetY + (position.y + 1) * gridScaleY;
        return new Vector2(gridPositionX, gridPositionY);
    }

    public static Element getElement(Vector2 pos)
    {
        if (pos == successbox.position)
            return successbox;
        if (pos.y >= 0 && pos.y <= currentLevel.elements.Count)
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
