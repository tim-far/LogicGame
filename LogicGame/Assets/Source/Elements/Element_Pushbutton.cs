using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pushbutton : Element
{
    public Pushbutton(Vector2 position, Vector3 connectedTo)
    {
        type = ElementType.ELEMENT_PUSHBUTTON;
        this.position = position;
        this.connectedTo = connectedTo;
        this.numInputs = 1;
        inputs = new List<bool>();
        inputs.Add(false);
    }

    public override void computeOutput()
    {
        output = inputs[0];
    }
}