using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelOnClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(delegate ()
        {
            Debug.LogFormat("Load Level {0}", b.name);
            CrossSceneInfo.levelTextFile = Resources.Load<TextAsset>(b.name);
            SceneManager.LoadScene("LevelScene");
        });
    }


    // Update is called once per frame
    void Update()
    {

    }
}
