using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Level
{
    public List<Element> elements;
    public static Vector2 dimensions; // number of rows, std::max(elements in row, old)

    public void loadElementsFromFile(string path)
    {
        dimensions = new Vector2();
        elements = new List<Element>();
        // Read The file into a String array
        string[] lines = System.IO.File.ReadAllLines(path);

        // Loop through all file lines
        for (int curLine = 0; curLine < lines.Length; curLine++)
        {
            // Plit each line after each space to seperate the elements
            string[] strLineElements = lines[curLine].Split(' ');
            // Loop through all elements
            for (int curRow = 0; curRow < strLineElements.Length; curRow++)
            {
                // Check if each element is declared in the following format: 
                // <element_name>(<targetGridX>,<targetGridY>,<targetInputNum>)
                Regex levelRegex = new Regex("^([A-Z]+)\\((\\d),(\\d),(\\d)\\)$");
                Match match = levelRegex.Match(strLineElements[curRow]);
                if (strLineElements[curRow] == "x" || match.Success)
                {
                    if (strLineElements[curRow] == "x")
                        continue;
                    string strCurrentElement = match.Groups[1].Value;
                    int targetX = System.Convert.ToInt32(match.Groups[2].Value);
                    int targetY = System.Convert.ToInt32(match.Groups[3].Value);
                    int targetInput = System.Convert.ToInt32(match.Groups[4].Value);

                    Debug.LogFormat("Found Element {0} connected to element at position ({1}, {2}), Input {3}", strCurrentElement, targetX, targetY, targetInput);
                    if (strCurrentElement == "AND")
                    {
                        // TODO: numInputs is currently hardcoded to 2
                        this.elements.Add(new Element_And(new Vector2Int(curRow, lines.Length - (curLine + 1)), new Vector3Int(targetX, targetY, targetInput), 2));
                    }
                    else if (strCurrentElement == "OR")
                    {
                        this.elements.Add(new Element_Or(new Vector2Int(curRow, lines.Length - (curLine + 1)), new Vector3Int(targetX, targetY, targetInput), 2));
                    }
                    else
                    {
                        Debug.LogErrorFormat("'{0}' is not a valid element. in File '{1}', Line {2}", strCurrentElement, path, curLine);
                    }
                    if (curLine + 1 > dimensions.y)
                        dimensions.y = curLine + 1;
                    if (curRow + 1 > dimensions.x)
                        dimensions.x = curRow + 1;
                }
                else
                {
                    Debug.LogErrorFormat("Unknown element format: '{0}' in File '{1}', Line {2}", strLineElements[curRow], path, curLine);
                }
            }

        }
    }

    public void connectElements()
    {

    }
}
