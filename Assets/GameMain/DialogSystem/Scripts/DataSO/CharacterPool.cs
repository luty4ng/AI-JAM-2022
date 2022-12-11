using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterPool", menuName = "GameMain/CharacterPool", order = 0)]
public class CharacterPool : ScriptableObject
{
    public List<Character> characters;
    public Character FindCharacter(string name)
    {
        foreach (var character in characters)
        {
            if (character.displayName == name)
            {
                return character;
            }
        }

        Debug.LogError($"Didn't find match character: " + name);
        return null;
    }

    public string GetBytesStr(byte[] data)
    {
        string result = "";
        for (int i = 0; i < data.Length; i++)
        {
            result += data[i];
        }
        return result;
    }
}
