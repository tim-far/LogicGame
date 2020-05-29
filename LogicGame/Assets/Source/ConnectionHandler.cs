using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Connection
{
    public Vector2 sourceIndex;
    public Vector2 targetIndex;
    public int targetInput;
    public List<Vector2> waypoints;
}

public class ConnectionHandler
{
    public static List<Connection> connections = new List<Connection>();

    public static void addConnection(Element e)
    {
        Element targetElement = LevelHandler.getElement(new Vector2Int(e.connectedTo.x, e.connectedTo.y));
        if (targetElement.numInputs == 10)
        {
            Debug.LogWarningFormat("Invalid Target Element at Position {0}", (Vector2Int)e.connectedTo);
            return;
        }

        Vector2 target = LevelHandler.calculateGridPos((Vector2Int)e.connectedTo);
        Vector2 source = LevelHandler.calculateGridPos(e.position);

        source.y += CrossSceneInfo.textureSize.height / 2;
        target.y -= CrossSceneInfo.textureSize.height / 2;

        target.x -= CrossSceneInfo.textureSize.width / 2;
        target.x += ((CrossSceneInfo.textureSize.width / 2) * ((e.connectedTo.z + 1) / targetElement.numInputs) + CrossSceneInfo.textureSize.width / 4);

        // Make it fit into the openGL screenspace
        target.x /= Screen.width;
        target.y /= Screen.height;

        source.x /= Screen.width;
        source.y /= Screen.height;

        float funcXVal = 2 * Mathf.Pow(Level.dimensions.x - e.position.x, 2) / Screen.height;
        Vector2 wayPoint1 = new Vector2(source.x, source.y + funcXVal + (target.y - source.y) / 2.0f);


        Vector2 wayPoint2 = new Vector2(target.x, wayPoint1.y);

        Connection c = new Connection();
        c.sourceIndex = e.position;
        c.targetIndex = (Vector2Int)e.connectedTo;
        c.targetInput = (int)e.connectedTo.z;
        c.waypoints = new List<Vector2>();

        c.waypoints.Add(source);
        c.waypoints.Add(wayPoint1);
        c.waypoints.Add(wayPoint2);
        c.waypoints.Add(target);

        connections.Add(c);
    }

    public static int findConnection(Vector2 sourceElementIndex, Vector2 targetElementIndex)
    {
        int index = -1;
        for (int i = 0; i < connections.Count; i++)
        {
            if (connections[i].sourceIndex == sourceElementIndex && connections[i].targetIndex == targetElementIndex)
            {
                index = i;
            }
        }
        return index;
    }
}
