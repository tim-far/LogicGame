using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionRenderer
{
    // Draws a line from "startVertex" var to the curent mouse position.
    public Material mat;

    public ConnectionRenderer(Material mat)
    {
        this.mat = mat;
    }

    private List<Vector2> createLineVertices(Vector2 start, Vector2 end)
    {
        List<Vector2> vertices = new List<Vector2>();
        Vector2 tmpStart = new Vector2(start.x, start.y);
        Vector2 tmpEnd = new Vector2(end.x, end.y);

        float angle = Mathf.Round(Mathf.Atan(Mathf.Abs(end.y - start.y) / Mathf.Abs(end.x - start.x)) * (180.0f / 3.141592653589793238463f));

        if (angle == 90.000)
        {
            tmpStart.x += .005f;
            tmpEnd.x += .005f;
        }
        else if (angle == 0.000)
        {
            tmpStart.y += .005f;
            tmpEnd.y += .005f;
        }
           
        vertices.Add(start);
        vertices.Add(tmpStart);
        vertices.Add(tmpEnd);
        vertices.Add(end);
        return vertices;
    }


    public void OnPostRender()
    {
        if (!mat)
        {
            Debug.LogError("Please Assign a material on the inspector");
            return;
        }
        GL.PushMatrix();
        mat.SetPass(0);
        GL.LoadOrtho();
        GL.Begin(GL.QUADS);
        GL.Color(Color.red);
        foreach (var connection in ConnectionHandler.connections)
        {
            if (connection.waypoints.Count % 4 != 0)
            {
                Debug.LogError("Wrong vertex count for connection");
                return;
            }
            for (int n = 0; n < connection.waypoints.Count - 1; n++)
            {
                foreach (var lineVert in createLineVertices(connection.waypoints[n], connection.waypoints[n + 1]))
                {
                    GL.Vertex(lineVert);
                }
            }
        }

        GL.End();
        GL.PopMatrix();
    }
}