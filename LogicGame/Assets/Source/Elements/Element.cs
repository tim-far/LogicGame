using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ElementType
{
    ELEMENT_AND,
    ELEMENT_OR,
    ELEMENT_PUSHBUTTON
}

public abstract class Element
{
    // Unity
    public GameObject obj;                  // Element texture, this variable is set in the Unity Editor

    // Element specifications
    public Vector2 position;                 // Position of the element int the format Vector2(Line, Row)
    public ElementType type;                    // Specifies the element type (AND, OR, etc.)

    // I/O
    public int numInputs;                       // Number of inputs a given element has
    public List<bool> inputs;                   // List of all inputs (0 - numInputs)
    public bool output;                         // Every element can only have one output
    public Vector3 connectedTo;              // List of elements the output from the current element is connected to

    // Member functions
    public abstract void computeOutput();       // Calculate output from inputs
}
