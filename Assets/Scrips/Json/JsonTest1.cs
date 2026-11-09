using UnityEngine;
using Newtonsoft.Json;
using System;
using System.IO;

[Serializable]
public class Playerstate
{
    public string playerName;
    public int lives;
    public float health;
    public Vector3 position;
    public Quaternion rotation;
    public Color color;
    public override string ToString()
    {
        return $"{playerName} / {lives} / {health} / {position} / {rotation} / {color}";
    }
}

public class JsonTest1 : MonoBehaviour
{
    public void Start()
    {
        {
            var obj = new Playerstate
            {
                playerName = "ABC",
                lives = 10,
                health = 10.999f,
                position = new Vector3(1f,2f,3f),
                rotation = new Quaternion(1f,2f,3f,4f),
                color = new Color(0.1f, 0.2f, 0.3f, 0.5f)
            };

            var path = Path.Combine(Application.persistentDataPath, "test.json");
            Debug.Log(path);
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented, new Vector3Converter(), new QuaternionConverter(), new ColorConverter());
            File.WriteAllText(path, json);

            var json2 = File.ReadAllText(path);
            var obj2 = JsonConvert.DeserializeObject<Playerstate>(json2, new Vector3Converter(), new QuaternionConverter(), new ColorConverter());
            Debug.Log(obj2);
        }
    }
}
