using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element_And : Element
{
    public Element_And(Vector2 position, Vector3 connectedTo, int numInputs)
    {
        type = ElementType.ELEMENT_AND;
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
        bool result = true;
        foreach (bool b in inputs)
        {
            result &= b;
        }
        output = result;
    }
}
