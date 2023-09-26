using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEditor.UIElements;
using SaveDataVC = SaveDataV3; // ±³Ã¼

[System.Serializable]
public struct CubeInfo
{
    public string name;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;

    public CubeInfo(string n, Vector3 pos, Quaternion rot, Vector3 sc)
    {
        name = n;
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
        var saveData = new SaveDataVC();

        var cubes = GameObject.FindGameObjectsWithTag("cube");
        foreach(var cube in cubes)
        {
            saveData.cubeList.Add(new CubeInfo(cube.name, cube.transform.position, cube.transform.rotation, cube.transform.localScale));
        }
        SaveLoadSystem.Save(saveData, "test2.json");
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
        SaveDataVC loadData = (SaveDataVC)SaveLoadSystem.Load("test2.json");

        foreach (var cubeInfo in loadData.cubeList)
        {
            var obj = Instantiate(prefab, cubeInfo.position, cubeInfo.rotation);
            obj.transform.localScale = cubeInfo.scale;
            obj.name = cubeInfo.name;
        }
    }
}
