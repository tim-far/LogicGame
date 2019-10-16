using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element_Or : Element
{
    public Element_Or(Vector2Int position, Vector3Int connectedTo, int numInputs)
    {
        type = ElementType.ELEMENT_OR;
        this.position = position;
        this.connectedTo = connectedTo;
        this.numInputs = numInputs;
        inputs = new List<bool>(numInputs);

        for (int i = 0; i < numInputs; i++)
        {
            inputs.Add(false);
        }
    }

    public override void computeOutput()
    {
        bool result = false;
        foreach (bool b in inputs)
        {
            result |= b;
        }
        output = result;
    }
}
