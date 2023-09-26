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

    public CubeInfo(Vector3 pos, Quaternion rot, Vector3 sc)
    {
        position = pos;
        rotation = rot;
        scale = sc;
    }
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
            cubeList.Add(new CubeInfo(cube.transform.position, cube.transform.rotation, cube.transform.localScale));
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
        var cubeInfoList = JsonConvert.DeserializeObject<List<CubeInfo>>(json, new Vector3Converter(), new QuaternionConverter());

        foreach(var cubeInfo in cubeInfoList)
        {
            var obj = Instantiate(prefab, cubeInfo.position, cubeInfo.rotation);
            obj.transform.localScale = cubeInfo.scale;
        }
    }
}
