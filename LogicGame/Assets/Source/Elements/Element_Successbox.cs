using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Successbox : Element
{
    public Successbox(Vector2 position)
    {
        type = ElementType.ELEMENT_SUCCESSBOX;
        this.position = position;
        this.numInputs = 1;
        inputs = new List<bool>();
        inputs.Add(false);
    }

    public override void computeOutput()
    {
        return;
    }
}