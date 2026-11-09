using UnityEngine;
using CsvHelper;
using System.IO;
using System.Globalization;
using JetBrains.Annotations;

public class CsvData
{
    public string ID {get; set;}
    public string STRING {get; set;}
}

public class CSVTest1 : MonoBehaviour
{
    public UiItemButton[] itemButton;
    public UiItemInfo itemInfo;

    private void Update()
    {
        itemButton[0].SetItem("ITEM_1");
        itemButton[0].button.onClick.AddListener(() => itemInfo.SetItem("ITEM_1"));

        itemButton[1].SetItem("ITEM_2");
        itemButton[1].button.onClick.AddListener(() => itemInfo.SetItem("ITEM_2"));

        itemButton[2].SetItem("ITEM_3");
        itemButton[2].button.onClick.AddListener(() => itemInfo.SetItem("ITEM_3"));

        itemButton[3].SetItem("ITEM_4");
        itemButton[3].button.onClick.AddListener(() => itemInfo.SetItem("ITEM_4"));
    }
    //private StringTable stringTable;
    /*private void Start()
    {
        stringTable = DataTableManager.StringTable;

        Debug.Log(stringTable.Get("HELLO"));
        Debug.Log(stringTable.Get("BYE"));
        Debug.Log(stringTable.Get("YOU_DIE"));

        var ItemData = DataTableManager.ItemTable.Get("ITEM_1");
        Debug.Log($"{ItemData.StringName} / {ItemData.StringDesc} ");
    }*/


    /*public TextAsset textAsset;
    private void Start()
    {
        TextAsset csv = Resources.Load<TextAsset>("DataTables/StringTablekr");

        using (var reader = new StringReader(csv.text))
        using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csvReader.GetRecords<CsvData>();
            foreach (var record in records)
            {
                Debug.Log($"{record.ID} : {record.STRING}");
            }
        }
    }*/
}