using System;
using UnityEngine;

public class Files : MonoBehaviour
{
    private TextAsset jsonFile;
    
    public Configs ReadConfigFile()
    {
        jsonFile = (TextAsset) Resources.Load("config");
       return JsonUtility.FromJson<Configs>(jsonFile.text);
    }

    [Serializable]
    public class Configs
    {
        public float delayBetweenWaves;
    }
}
