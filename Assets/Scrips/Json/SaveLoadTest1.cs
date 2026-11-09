using Mono.Cecil;
using UnityEngine;
using UnityEngine.Rendering;

public class SaveLoadTest1 : MonoBehaviour
{
    public void Save()
    {
        SaveLoadManager.Data = new SaveDataV4();
        string fullname = "SeungTae Sim";
        SaveLoadManager.Data.PlayerName = fullname;
        SaveLoadManager.Data.nameSplit(fullname);
        SaveLoadManager.Data.Gold = Random.Range(100, 200);
        //SaveLoadManager.Data.leverUpPoint = Random.Range(50, 100);
        Debug.Log($"세이브 결과: {SaveLoadManager.Save()}");
    }

    public void Load()
    {
        SaveLoadManager.Load();
        Debug.Log(SaveLoadManager.Data.PlayerName);
        Debug.Log(SaveLoadManager.Data.Gold);
        //Debug.Log(SaveLoadManager.Data.leverUpPoint);
    }
}
