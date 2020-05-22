
public class CrossSceneInfo
{
    private static CrossSceneInfo instance;
    public static CrossSceneInfo getInstance()
    {
        if (instance == null)
        {
            instance = new CrossSceneInfo();
        }
        return instance;
    }

    public string RequestedLevel = "Assets/Levels/lvl1.lvl";
};
