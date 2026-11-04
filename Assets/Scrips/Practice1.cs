using UnityEngine;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class Practice1 : MonoBehaviour
{
    private string folder;
    private string path1;
    private string path2;
    private string path3;

    private Dictionary<string, string> saveData  = new Dictionary<string, string>();

    private void Start()
    {
        folder = Path.Combine(Application.persistentDataPath, "SaveData");
        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }
        path1 = Path.Combine(folder, "save1.txt");
        File.WriteAllText(path1, "Hello");
        path2 = Path.Combine(folder, "save2.txt");
        File.WriteAllText(path2, "World");
        path3 = Path.Combine(folder, "save3.txt");
        File.WriteAllText(path3, "Good");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Load();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Copy();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Delete();
        }
        
    }

    private void Load()
    {
        string[] files = Directory.GetFiles(folder);
        foreach (string file in files)
        {
            Debug.Log($"{Path.GetFileName(file)}, {Path.GetExtension(file)}");
        }
    }

    private void Copy()
    {
        string save1 = Path.Combine(folder, "save1.txt");
        string save1_backup = Path.Combine(folder, "save1_backup.txt");

        if (File.Exists(path1))
        {
            File.Copy(save1, save1_backup, true);
            Debug.Log("파일 복사 완료: " + save1_backup);
        }
        else
        {
            Debug.LogWarning("복사할 원본 파일이 없습니다: " + save1);
        }
    }

    private void Delete()
    {
        string save3 = Path.Combine(folder, "save3.txt");
        if (save3 != null)
        {
            File.Delete(save3);
            Debug.Log("삭제 완료");
        }
    }
}
