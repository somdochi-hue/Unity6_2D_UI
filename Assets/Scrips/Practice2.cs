using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Practice2 : MonoBehaviour
{
    private string folder;
    private string path;
    private Dictionary<string, string> Original = new Dictionary<string, string>();

    private void Start()
    {
        folder = Path.Combine(Application.persistentDataPath, "original");
        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }

        string path = Path.Combine(Application.persistentDataPath, "original.txt");
        string original = "Hello Unity World";
        File.WriteAllText(path, original);
        Debug.Log("설정 저정 완료");
    }

    private void Update()
    {
        
    }

    private void Load()
    {

    }

}
