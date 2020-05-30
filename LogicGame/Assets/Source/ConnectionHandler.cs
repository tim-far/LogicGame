using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection
{
    public Vector2 sourceIndex;
    public Vector2 targetIndex;
    public int targetInput;
    public bool state;
    public List<Vector2> waypoints;
}

public class ConnectionHandler
{
    public static List<Connection> connections = new List<Connection>();

    public static void addConnection(Element e, bool isActive = false)
    {
        Element targetElement = LevelHandler.getElement(new Vector2(e.connectedTo.x, e.connectedTo.y));
        if (targetElement.numInputs == 10)
        {
            Debug.LogWarningFormat("Skipping invalid element {0}", e.connectedTo);
            return;
        }

        var textureRect = e.obj.GetComponent<SpriteRenderer>().sprite.textureRect;

        Vector2 target = LevelHandler.calculateGridPos(e.connectedTo);
        Vector2 source = LevelHandler.calculateGridPos(e.position);

        source.y += textureRect.height / 2;
        target.y -= textureRect.height / 2;

        target.x -= textureRect.width / 2;
        target.x += (textureRect.width / 2) * ((e.connectedTo.z + 1) / targetElement.numInputs);

        // Make it fit into the openGL screenspace
        target.x /= Screen.width;
        target.y /= Screen.height;

        source.x /= Screen.width;
        source.y /= Screen.height;

        float funcXVal = 2 * Mathf.Pow(LevelHandler.currentLevel.elements[(int)source.y].Count - e.position.x, 2) / Screen.height;
        Vector2 wayPoint1 = new Vector2(source.x, source.y + funcXVal + (target.y - source.y) / 2.0f);


        Vector2 wayPoint2 = new Vector2(target.x, wayPoint1.y);

        Connection c = new Connection();
        c.sourceIndex = e.position;
        c.targetIndex = e.connectedTo;
        c.targetInput = (int)e.connectedTo.z;
        c.waypoints = new List<Vector2>();
        c.state = isActive;

        c.waypoints.Add(source);
        c.waypoints.Add(wayPoint1);
        c.waypoints.Add(wayPoint2);
        c.waypoints.Add(target);

        connections.Add(c);
    }

    public static void setConnectionEnabled(bool enabled, Vector2 sourceElementIndex, Vector2 targetElementIndex)
    {
        for (int i = 0; i < connections.Count; i++)
        {
            if (connections[i].sourceIndex == sourceElementIndex && connections[i].targetIndex == targetElementIndex)
                connections[i].state = enabled;
        }
    }
}
