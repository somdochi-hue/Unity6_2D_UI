using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor.Overlays;

public class objstate
{
    public string name;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
}

public class JsonTest2 : MonoBehaviour
{
    // public Button[] objbutton;
    public GameObject[] prefabs;
    private List<GameObject> objects = new List<GameObject>();

    public void Create()
    {
        int randomIndex = Random.Range(0, prefabs.Length);
        Vector3 ransdomPosition = Random.insideUnitSphere * 10f;
        Quaternion randomRotation = Random.rotation;
        Vector3 randomScale = Vector3.one * Random.Range(0.5f, 2f);

        GameObject newGo = Instantiate(prefabs[randomIndex]);
        newGo.transform.position = ransdomPosition;
        newGo.transform.rotation = randomRotation;
        newGo.transform.localScale = randomScale;

        objects.Add(newGo);
    }

    public void Clear()
    {
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
        objects.Clear();
    }

    public void Save()
    {
        List<objstate> saveData = new List<objstate>();
        foreach (GameObject obj in objects)
        {
            objstate data = new objstate();
            data.name = obj.name;
            data.position = obj.transform.position;
            data.rotation = obj.transform.rotation;
            data.scale = obj.transform.localScale;
            saveData.Add(data);
        }
        string json = JsonConvert.SerializeObject(saveData, Formatting.Indented, new Vector3Converter(), new QuaternionConverter());
        string path = Path.Combine(Application.persistentDataPath,"JsonTest2.json");
        File.WriteAllText(path, json);
    }

    public void Load()
    {
        Clear();

        string path = Path.Combine(Application.persistentDataPath,"JsonTest2.json");
        string json = File.ReadAllText(path);

        var saveDatas = JsonConvert.DeserializeObject<List<objstate>>(json, new Vector3Converter(), new QuaternionConverter());

        foreach(var obj in saveDatas)
        {
            int prefabIndex = 0;
            for(int i = 0; i < prefabs.Length; ++i)
            {
                if(obj.name.Contains(prefabs[i].name))
                {
                    prefabIndex = i;
                    break;
                }
               
            }
            var newGo = Instantiate(prefabs[prefabIndex]);
            newGo.transform.position = obj.position;
            newGo.transform.rotation = obj.rotation;
            newGo.transform.localScale = obj.scale;
            objects.Add(newGo);
        }
    }


    public void Start()
    {
        
    }
}
