using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    public List<string> Rows = new List<string>();
    public int Height {get { return Rows.Count; } }
    public int Width
    {
        get
        {
            int maxLength = 0;
            foreach(var r in Rows)
            {
                if (r.Length > maxLength) maxLength = r.Length;
            }
            return maxLength;
        }
    }

}



public class LevelBehaviour : MonoBehaviour{
    public string filename;
    public List<Level> Levels;
    void Awake()
    {
        TextAsset textAsset = (TextAsset)Resources.Load(filename); //import the levels from the .txt file.
        if (!textAsset)
        {
            Debug.Log("levels: " + filename + ".txt does not exist.");
            return;
        }

        string completeText = textAsset.text;
        string[] lines;
        lines = completeText.Split(new string[] { "\n" }, System.StringSplitOptions.None);
        Levels.Add(new Level());
        for(long i = 0; i < lines.LongLength; i++)
        {
            string line = lines[i];
            if (line.StartsWith(";")) //the ";" will determine where one level finishes and when it begins the new one.
            {
                Levels.Add(new Level());
                continue;
            }
            Levels[Levels.Count - 1].Rows.Add(line);
        }

    }





}
