using UnityEngine;
using Newtonsoft.Json;
using System;
using JetBrains.Annotations;

public class SaveCharacterData
{
    public Guid InstanceId { get; set; }

    [JsonConverter(typeof(ItemDataConverter))]
    public ItemData ItemData { get; set; }
    public DateTime CreationTime { get; set; }

    public SaveCharacterData()
    {
        InstanceId = Guid.NewGuid();
        CreationTime = DateTime.Now;
    }

    public override string ToString()
    {
        return $"{InstanceId} {ItemData:Id}: (${CreationTime})";
    }

    public static SaveCharacterData GetRandomCharacter()
    {
        var newCharacter = new SaveCharacterData();
        newCharacter.ItemData = DataTableManager.ItemTable.GetRandom();
        return newCharacter;
    }
}
