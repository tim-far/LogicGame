using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System;

public class Level
{
    public List<List<Element>> elements;
    public static Vector2 dimensions; // number of rows, std::max(elements in row, old)

    public void loadElementsFromFile(string path)
    {
        dimensions = new Vector2();
        elements = new List<List<Element>>();
        // Read The file into a String array
        string[] lines = System.IO.File.ReadAllLines(path);
        Array.Reverse(lines); 
       
        // Loop through all file lines
        for (int currentLine = 0; currentLine < lines.Length; currentLine++)
        {
            elements.Add(new List<Element>());
            // Plit each line after each space to seperate the elements
            string[] strLineElements = lines[currentLine].Split(' ');
            // Loop through all elements
            for (int currentColumn = 0; currentColumn < strLineElements.Length; currentColumn++)
            {
                // Check if each element is declared in the following format: 
                // <element_name>(<targetGridX>,<targetGridY>,<targetInputNum>)
                Regex levelRegex = new Regex("^([A-Z]+)\\((\\d),(\\d),(\\d)\\)$");
                Match match = levelRegex.Match(strLineElements[currentColumn]);
                if (strLineElements[currentColumn] == "x" || match.Success)
                {
                    if (strLineElements[currentColumn] == "x")
                        continue;
                    string strCurrentElement = match.Groups[1].Value;
                    int targetX = System.Convert.ToInt32(match.Groups[2].Value);
                    int targetY = System.Convert.ToInt32(match.Groups[3].Value);
                    int targetInput = System.Convert.ToInt32(match.Groups[4].Value);

                    Debug.LogFormat("Found Element {0} connected to element at position ({1}, {2}), Input {3}", strCurrentElement, targetX, targetY, targetInput);
                    if (strCurrentElement == "AND")
                    {
                        // TODO: numInputs is currently hardcoded to 2
                        this.elements[currentLine].Add(new Element_And(new Vector2Int(currentColumn, currentLine), new Vector3Int(targetX, targetY, targetInput), 2));
                    }
                    else if (strCurrentElement == "OR")
                    {
                        this.elements[currentLine].Add(new Element_Or(new Vector2Int(currentColumn, currentLine), new Vector3Int(targetX, targetY, targetInput), 2));
                    }
                    else
                    {
                        Debug.LogErrorFormat("'{0}' is not a valid element. in File '{1}', Line {2}", strCurrentElement, path, currentLine);
                    }
                    if (currentLine + 1 > dimensions.y)
                        dimensions.y = currentLine + 1;
                    if (currentColumn + 1 > dimensions.x)
                        dimensions.x = currentColumn + 1;
                }
                else
                {
                    Debug.LogErrorFormat("Unknown element format: '{0}' in File '{1}', Line {2}", strLineElements[currentColumn], path, currentLine);
                }
            }

        }
    }

    public void connectElements()
    {

    }
}
