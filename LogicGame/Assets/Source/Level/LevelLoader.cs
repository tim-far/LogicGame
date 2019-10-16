using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class LevelLoader
{
    public List<Element> elementListFromFile(string path)
    {
        List<Element> resultList = new List<Element>();
        // Read The file into a String array
        string[] lines = System.IO.File.ReadAllLines(path);

        // Loop through all file lines
        for(int curLine = 0; curLine < lines.Length; curLine++)
        {
            // Plit each line after each space to seperate the elements
            string[] elements = lines[curLine].Split(' ');
            // Loop through all elements
            for (int curRow = 0; curRow < elements.Length; curRow++)
            {
                // Check if each element is declared in the following format: 
                // <element_name>(<targetGridX>,<targetGridY>,<targetInputNum>)
                Regex levelRegex = new Regex("^([A-Z]+)\\((\\d),(\\d),(\\d)\\)$");
                Match match = levelRegex.Match(elements[curRow]);
                if (elements[curRow] == "x" || match.Success)
                {
                    if (elements[curRow] == "x")
                        continue;
                    string element = match.Groups[1].Value;
                    int targetX = System.Convert.ToInt32(match.Groups[2].Value);
                    int targetY = System.Convert.ToInt32(match.Groups[3].Value);
                    int targetInput = System.Convert.ToInt32(match.Groups[4].Value);

                    Debug.LogFormat("Found Element {0} connected to element at position ({1}, {2}), Input {3}", element, targetX, targetY, targetInput);
                    if (element == "AND")
                    {
                        // TODO: numInputs is currently hardcoded to 2
                        resultList.Add(new Element_And(new Vector2Int(curRow, lines.Length - curLine), new Vector3Int(targetX, targetY, targetInput), 2));
                    }
                    else if (element == "OR")
                    {
                        resultList.Add(new Element_Or(new Vector2Int(curRow, lines.Length - curLine), new Vector3Int(targetX, targetY, targetInput), 2));
                    }
                    else
                    {
                        Debug.LogErrorFormat("'{0}' is not a valid element. in File '{1}', Line {2}", element, path, curLine);
                    }
                }
                else
                {
                    Debug.LogErrorFormat("Unknown element format: '{0}' in File '{1}', Line {2}", elements[curRow], path, curLine);
                }
            }
            
        }
        return resultList;
    }
}
