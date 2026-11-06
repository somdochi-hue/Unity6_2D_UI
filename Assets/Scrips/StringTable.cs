using System.Collections.Generic;
using UnityEngine;

public class StringTable : DataTable
{
    public class Data
    {
        public string ID {get; set;}
        public string STRING {get; set;}
    }

    private readonly Dictionary<string, string> dictionary = new Dictionary<string, string>();

    public override void Load(string filename)
    {
        dictionary.Clear();

        string path = string.Format(FormatPath, filename);
        TextAsset textAsset = Resources.Load<TextAsset>(path);
        List<Data> list = LoadCSV<Data>(textAsset.text);
        

        foreach (var item in list)
        {
            if (!dictionary.ContainsKey(item.ID))
            {
                dictionary.Add(item.ID, item.STRING);
            }
            else
            {
                Debug.LogError($"키 중복: {item.ID}");
            }
        }

        foreach (var character in list)
        {
            if (!dictionary.ContainsKey(character.ID))
            {
                dictionary.Add(character.ID, character.STRING);
            }
            else
            {
                Debug.LogError($"키 중복: {character.ID}");
            }
        }
    }
    
    public readonly static string Unknown = "키 없음";

    public string Get(string id)
    {
        if (!dictionary.ContainsKey(id))
        {
            return Unknown;
        }
        return dictionary[id];
    }
}
