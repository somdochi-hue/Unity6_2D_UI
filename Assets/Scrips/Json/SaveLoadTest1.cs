using Mono.Cecil;
using UnityEngine;
using UnityEngine.Rendering;

public class SaveLoadTest1 : MonoBehaviour
{
    public void CreateItem()
    {
        SaveLoadManager.Data.ItemList.Add(SaveItemData.GetRandomItem());
    }
    public void Save()
    {
        Debug.Log($"세이브 결과: {SaveLoadManager.Save()}");
        /*SaveLoadManager.Data = new SaveDataV5();
        string fullname = "SeungTae Sim";
        SaveLoadManager.Data.PlayerName = fullname;
        SaveLoadManager.Data.nameSplit(fullname);
        SaveLoadManager.Data.Gold = Random.Range(100, 200);
        //SaveLoadManager.Data.leverUpPoint = Random.Range(50, 100);
        Debug.Log($"세이브 결과: {SaveLoadManager.Save()}");*/
    }

    public void Load()
    {
        Debug.Log($"로드 결과: {SaveLoadManager.Load()}");
        foreach(var data in SaveLoadManager.Data.ItemList)
        {
            Debug.Log(data);
        }
        /*Debug.Log("");
        SaveLoadManager.Load();
        Debug.Log(SaveLoadManager.Data.PlayerName);
        Debug.Log(SaveLoadManager.Data.Gold);
        //Debug.Log(SaveLoadManager.Data.leverUpPoint);*/
    }
}
