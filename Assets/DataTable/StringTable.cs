using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;

public class StringTable : DataTable
{
    public class Data
    {
        public string ID { get; set; }
        public string STRING { get; set; }
    }

    protected Dictionary<string, string> dic = new Dictionary<string, string>();

    public StringTable()
    {
        path = "Tables/StringTable"; // Ȯ���� ������� ��
        Load();
    }

    public override void Load()
    {
        var csvStr = Resources.Load<TextAsset>(path); // ���� �߿� path�� �ִ� ������ TextAsset���� ��ȯ

        TextReader reader = new StringReader(csvStr.text);
        var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
        var records = csv.GetRecords<Data>();

        foreach (var record in records)
        {
            dic.Add(record.ID, record.STRING);
        }
    }

    public string GetString(string id)
    {
        if(!dic.ContainsKey(id))
        {
            return string.Empty;
        }
        return dic[id];
    }
}
