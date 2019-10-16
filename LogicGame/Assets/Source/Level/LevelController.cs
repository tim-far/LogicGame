using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelController
{
    public static Level currentLevel;
    public static LevelLoader levelLoader;

    public static void initialize()
    {
        currentLevel = new Level();
        levelLoader = new LevelLoader();
    }

    public static void loadLevel(string path)
    {
        currentLevel.elements = levelLoader.elementListFromFile(path);
    }

    public static void updateLevel()
    {

    }
}
