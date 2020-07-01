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

    // compute the parth each connection line takes from one element to another
    // a straight line wouldn't look nice so onlyorthoonal lines are used
    // this is achieved by adding two middle points in each connection line to which both elements can connect orthogonally
    // each point is represented by a 'X'
    //
    //  X (Line end)
    //  *
    //  *
    //  X*******X (waypoint 1 & 2)
    //          *
    //          *
    //          X (line start)
    //
    //
    public static void addConnection(Element e, bool isActive = false)
    {
        Element targetElement = LevelHandler.getElement(new Vector2(e.connectedTo.x, e.connectedTo.y));
        // target element was not found
        if (targetElement.numInputs == 10)
        {
            Debug.LogWarningFormat("Skipping invalid element {0}", e.connectedTo);
            return;
        }

        var textureRect = LevelHandler.currentLevel.elements[0][0].obj.GetComponent<SpriteRenderer>().sprite.textureRect;
        textureRect.width *= 0.28f;
        textureRect.height *= 0.28f;

        Vector2 target = LevelHandler.calculateGridPos(e.connectedTo);
        Vector2 source = LevelHandler.calculateGridPos(e.position);

        source.y += textureRect.height / 2;
        target.y -= textureRect.height / 2;

        // place the input correctly
        target.x -= textureRect.width / 2;
        float sectionSize = textureRect.width / targetElement.numInputs;
        float currentSection = e.connectedTo.z;
        target.x += currentSection * sectionSize + sectionSize / 2;

        // Make it fit into the openGL screenspace
        target.x /= Screen.width;
        target.y /= Screen.height;

        source.x /= Screen.width;
        source.y /= Screen.height;

        // Verbindungshöhe bei Waypoint 1 Parabelförmig 5x^2 + offset
        float xVal = (2 * e.position.x - Level.dimensions.x) / 2;
        float offset = (target.y - source.y) / 3.5f;
        float funcXVal = (5 * Mathf.Pow(xVal, 2) / Screen.height) + offset;
        Vector2 wayPoint1 = new Vector2(source.x, source.y + funcXVal);
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
