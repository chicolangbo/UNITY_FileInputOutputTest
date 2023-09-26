using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CsvHelper;
using CsvHelper.Configuration;
using System.IO;
using System.Globalization;

public class StringElement
{
    public string ID { get; set; }
    public string KOREAN { get; set; }
}

public class TableExample : MonoBehaviour
{
    public TextAsset csvFile;

    public void Start()
    {
        var str = DataTableMgr.GetTable<StringTable>().GetString("YOU DIE");
        Debug.Log(str);
    }
}
