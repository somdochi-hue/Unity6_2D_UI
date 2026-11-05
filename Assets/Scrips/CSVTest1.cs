using UnityEngine;
using CsvHelper;
using System.IO;
using System.Globalization;

public class CsvData
{
    public string ID {get; set;}
    public string STRING {get; set;}
}

public class CSVTest1 : MonoBehaviour
{
    private StringTable stringTable;
    private void Start()
    {
        stringTable = new StringTable();
        stringTable.Load("StringTablekr");

        Debug.Log(stringTable.Get("Hello"));
        Debug.Log(stringTable.Get("Bye"));

        Debug.Log(stringTable.Get("DIE"));
    }


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