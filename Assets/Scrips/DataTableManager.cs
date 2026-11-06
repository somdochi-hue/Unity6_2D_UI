using System.Collections.Generic;
using UnityEngine;

public static class DataTableManager
{
    private static readonly Dictionary<string, DataTable> tables = 
        new Dictionary<string, DataTable>();

    static DataTableManager()
    {
        Init();
    }

    private static void Init()
    {
#if UNITY_EDITOR
        foreach (var id in DataTableIds.StringTableIDs)
        {
            var stringTable = new StringTable();
            stringTable.Load(id);
            tables.Add(id, stringTable);
        }
#else
        var stringTable = new StringTable();
        stringTable.Load(DataTableIds.String);
        tables.Add(DataTableIds.String, stringTable);
#endif

        var ItemTable = new ItemTable();
        ItemTable.Load(DataTableIds.Item);
        tables.Add(DataTableIds.Item, ItemTable);

        var CharacterTable = new CharacterTable();
        CharacterTable.Load(DataTableIds.Character);
        tables.Add(DataTableIds.Character, CharacterTable);
    }

    public static t Get<t>(string id) where t : DataTable
    {
        if(!tables.ContainsKey(id))
        {
            Debug.LogError("테이블 없음");
            return null;
        }

        return tables[id] as t;
    }

    public static StringTable StringTable => Get<StringTable>(DataTableIds.String);
    public static ItemTable ItemTable => Get<ItemTable>(DataTableIds.Item);
    public static CharacterTable CharacterTable => Get<CharacterTable>(DataTableIds.Character);
    public static void ChangedLanguage(Languages lang)
    {
        var newId = DataTableIds.StringTableIDs[(int)lang];
        if (tables.ContainsKey(newId))
        {
            return;
        }

        string oldId = null;
        foreach (var id in DataTableIds.StringTableIDs)
        {
            if (tables.ContainsKey(id))
            {
                oldId = id;
                break;
            }
        }

        if (oldId == null)
        {
            Debug.Log("활성화된 스트링 테이블 없음");
        }

        var table = tables[oldId] as StringTable;
        table.Load(newId);
        tables.Remove(oldId);
        tables.Add(newId, table);
    }
}
