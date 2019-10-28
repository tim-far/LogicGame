using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelController
{
    public static Level currentLevel;

    public static void initialize()
    {
        currentLevel = new Level();
    }

    public static void loadLevel(string path)
    {
        currentLevel.loadElementsFromFile(path);
        currentLevel.connectElements();
    }
}
