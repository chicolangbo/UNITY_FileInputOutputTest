using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataTableMgr
{
    private static Dictionary<System.Type, DataTable> tables = new Dictionary<System.Type, DataTable>();

    // ����ƽ ������
    static DataTableMgr()
    {
        tables.Clear();

        // STRING TABLE LOAD -> ADD
        var stringTable = new StringTable();
        tables.Add(typeof(StringTable), stringTable);
    }

    public static T GetTable<T>() where T : DataTable
    {
        var id = typeof(T);
        if(!tables.ContainsKey(id))
        {
            return null;
        }
        return tables[id] as T;
    }
}
