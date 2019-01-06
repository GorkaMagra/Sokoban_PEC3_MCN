using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelElement
{
    public string Character;
    public GameObject Prefab;
}

public class LevelEditor : MonoBehaviour
{
    public int CurrentLevel;
    public List<LevelElement> LevelElements;
    private Level Level;


    GameObject GetPrefab(char c) //make a element list in the inspector to be able to "chain" the characters to the prefabs.
    {
        LevelElement levelElement = LevelElements.Find(le => le.Character == c.ToString());
        if (levelElement != null)
            return levelElement.Prefab;
        else return null;
    }

    public void NextLevel() //advance to the next level so the builder will select the next one in the next level iteration.
    {
        CurrentLevel++;
        if(CurrentLevel >= GetComponent<LevelBehaviour>().Levels.Count)
        {
            CurrentLevel = 0;
        }
    }

    public void Build()
    {
        Level = GetComponent<LevelBehaviour>().Levels[CurrentLevel]; //center the level to the screen
        int startx = -Level.Width / 2;
        int x = startx;
        int y = -Level.Height / 2;
        foreach (var row in Level.Rows)
        {
            foreach(var ch in row)
            {
                GameObject prefab = GetPrefab(ch); //get the prefab chained to that character.
                if (prefab)
                {
                    Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity);           
                }
                x++;
            }
            y++;
            x = startx;
        }
    }


}
