using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEditor.UIElements;

[System.Serializable]
public struct CubeInfo
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
}

public class CubeSaveLoad : MonoBehaviour
{
    public GameObject prefab;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Save();
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Load();
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            Clear();
        }
    }

    public void Save()
    {
        var cubeList = new List<CubeInfo>();
        var cubes = GameObject.FindGameObjectsWithTag("cube");
        foreach(var cube in cubes)
        {
            cubeList.Add(new CubeInfo());
        }

        var json = JsonConvert.SerializeObject(cubeList, new Vector3Converter(), new QuaternionConverter());
        Debug.Log(json);

        var path = Path.Combine(Application.persistentDataPath, "cubes.json"); // 윈도우에서 허용하는 빌드했을 때 읽기 쓰기 가능한 경로를 리턴해줌
        Debug.Log(path);
        File.WriteAllText(path, json);
    }

    public void Clear()
    {
        var cubes = GameObject.FindGameObjectsWithTag("cube");
        foreach(var cube in cubes)
        {
            Destroy(cube);
        }
    }

    public void Load()
    {
        var path = Path.Combine(Application.persistentDataPath, "cubes.json");
        var json = File.ReadAllText(path);
        var cubePosList = JsonConvert.DeserializeObject<List<(Vector3, Quaternion,Vector3)>>(json, new Vector3Converter(), new QuaternionConverter());

        foreach(var item in cubePosList)
        {
            var obj = Instantiate(prefab, item.Item1, item.Item2);
            obj.transform.localScale = item.Item3;
        }
    }
}
