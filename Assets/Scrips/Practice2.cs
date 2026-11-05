using System.Collections.Generic;
using System.IO;
using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.Rendering;

public class Practice2 : MonoBehaviour
{
    private const byte Key = 0xAB;
    private string folder;
    private string srcPath;
    private string encPath;
    private string decPath;

    private void Start()
    {
        folder = Path.Combine(Application.persistentDataPath, "Secret");
        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }

        srcPath = Path.Combine(folder, "original.txt");
        encPath = Path.Combine(folder, "encrypted.txt");
        decPath = Path.Combine(folder, "decrypted.txt");

        ;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WriteOriginal();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Encrypt();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Decrypt();
        }
    }

    private void WriteOriginal()
    {
        File.WriteAllText(srcPath, "Hello Unity World");
        Debug.Log("설정 저정 완료");
    }

    private void Encrypt()
    {
        using(Stream input = new FileStream(srcPath, FileMode.Open))
        using(Stream output = new FileStream(encPath, FileMode.Create))
        {
            int b;
            while((b = input.ReadByte()) != -1)
            {
                output.WriteByte((byte)(b^Key));
                Debug.Log($"암호화 완료 (파일 크키: {(byte)(b^Key)}bytes)");
            }
        }
        
    }

    private void Decrypt()
    {
        using(Stream input = new FileStream(encPath, FileMode.Open))
        using(Stream output = new FileStream(decPath, FileMode.Create))
        {
            int b;
            while((b = input.ReadByte()) != -1)
            {
                output.WriteByte((byte)(b^Key));
                Debug.Log($"복호화 완료");
            }
        }
        
        string result = File.ReadAllText(decPath);
        Debug.Log($"복호화 결과 {result}");
        bool equal = result == File.ReadAllText(srcPath);
        Debug.Log($"{equal}");
    }
}
