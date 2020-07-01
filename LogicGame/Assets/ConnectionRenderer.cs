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

        // lines are drawn by using quads
        // each line basically is a quad, thats why lines have to be straight
        // opecgl offers the gl_quads function for that
        // for each line, the start and endpoint is duplicated and shifted a bit to the top or right, depending on the direction of the line
        // so that we get a quad with a minimum width or height making it look like a line

        // if the line is vertical, make it wider
        if (angle == 90.000)
        {
            tmpStart.x += .005f;
            tmpEnd.x += .005f;
        }
        // if the line is horizontal, make it higher
        else if (angle == 0.000)
        {
            // line rendering connection beause a piece of the line was missing so we have to make it a tiny bit loger
            // it depends on where the line starts because we have to ass a bit either at the beginning or the end of the line depending on the direction
            if (start.x < end.x)
            {
                tmpEnd.x += 0.005f;
                end.x += 0.005f;
            }
            else
            {
                tmpStart.x += 0.005f;
                start.x += 0.005f;
            }
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
        foreach (var connection in ConnectionHandler.connections)
        {
            if (connection.state == true)
                GL.Color(Color.red);
            else
                GL.Color(Color.grey);

            if (connection.waypoints.Count % 4 != 0)
            {
                Debug.LogError("Wrong vertex count for connection");
                return;
            }
            for (int n = 0; n < connection.waypoints.Count - 1; n++)
            {
                foreach (var lineVert in createLineVertices(connection.waypoints[n], connection.waypoints[n + 1]))
                    GL.Vertex(lineVert);
            }
        }

        GL.End();
        GL.PopMatrix();
    }
}