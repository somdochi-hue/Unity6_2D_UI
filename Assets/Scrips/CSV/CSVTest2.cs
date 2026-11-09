using UnityEngine;
using CsvHelper;
using System.IO;
using System.Globalization;
using JetBrains.Annotations;

public class CsvData2
{
    public string ID {get; set;}
    public string STRING {get; set;}
}

public class CSVTest2 : MonoBehaviour
{
    public UiCharacterButton[] characterButton;
    public UiCharacterInfo characterInfo;

    private void Update()
    {
        characterButton[0].SetCharacter("CHAR_1");
        characterButton[0].button.onClick.AddListener(() => characterInfo.SetCharacter("CHAR_1"));

        characterButton[1].SetCharacter("CHAR_2");
        characterButton[1].button.onClick.AddListener(() => characterInfo.SetCharacter("CHAR_2"));

        characterButton[2].SetCharacter("CHAR_3");
        characterButton[2].button.onClick.AddListener(() => characterInfo.SetCharacter("CHAR_3"));

        characterButton[3].SetCharacter("CHAR_4");
        characterButton[3].button.onClick.AddListener(() => characterInfo.SetCharacter("CHAR_4"));
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