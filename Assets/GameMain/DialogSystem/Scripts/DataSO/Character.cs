using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public struct Mood
{
    public string Name;
    public Sprite avatar;
    public Sprite half;
}

[CreateAssetMenu(fileName = "Character", menuName = "GameMain/Character", order = 0)]
public class Character : ScriptableObject
{
    public string idName;
    public string displayName;
    public Color iconicColor;
    [TextArea] public string introduction;
    public List<Mood> moods;

    public Mood GetMood(string name)
    {
        for (int i = 0; i < moods.Count; i++)
        {
            if (moods[i].Name.Equals(name))
            {
                return moods[i];
            }
        }
        return moods.Count > 1 ? moods.First() : default(Mood);
    }
}
