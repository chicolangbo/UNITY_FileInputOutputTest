using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

[System.Serializable]
public class MyClass
{
    public string myClassName;
}

[System.Serializable]
public class MyClass2 : MyClass
{
    public string myClassName2 = "2";
}


[System.Serializable]
public class PlayerInfo
{
    public string name;
    public int lives;
    public float health;

    public MyClass myClass;

    public int[] array;
    public Hashtable hit;

    // 저장 시 애로사항
    public Vector3 position; // 순환구조라서 저장할 수가 없음 (normalsized같은 필드들도 저장되어야 하는데 이게 vector3형이라서)

    //public string SaveToString()
    //{
    //    // return JsonUtility.ToJson(this);
    //    return JsonConvert.SerializeObject(this); // 직렬화. 위의 코드를 대신해줌
    //}

    //public static PlayerInfo CreateFromJSON(string jsonString)
    //{
    //    // return JsonUtility.FromJson<PlayerInfo>(jsonString);
    //    return JsonConvert.DeserializeObject<PlayerInfo>(jsonString);
    //}

    // Given JSON input:
    // {"name":"Dr Charles","lives":3,"health":0.8}
    // this example will return a PlayerInfo object with
    // name == "Dr Charles", lives == 3, and health == 0.8f.
}

public class JsonTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        // 1
        {
            //string jsonString = @"{""name"":""Dr Charles"",""lives"":3,""health"":0.8, ""array"":[1,2,3]}";
            //var info = PlayerInfo.CreateFromJSON(jsonString);

            //info.name = "Dr Charles Jr !!!";
            //info.lives = 9;
            //info.health = 0.9f;

            //jsonString = info.SaveToString();
            //Debug.Log(jsonString);
            //foreach(var item in info.array)
            //{
            //    Debug.Log(item);
            //}
        }

        // 2
        {
            //var info = new PlayerInfo();

            //info.name = "Dr Charles";
            //info.lives = 3;
            //info.health = 0.8f;
            //info.array = new int[3] { 10,20,30 };

            //var json = info.SaveToString();
            //Debug.Log(json);
        }

        // 3
        {
            //var info = new PlayerInfo();

            //info.name = "Dr Charles";
            //info.lives = 3;
            //info.health = 0.8f;
            //info.myClass = new MyClass();
            //info.myClass.myClassName = "myClassName";
            //info.array = new int[3] { 10, 20, 30 };
            //info.hit = new Hashtable();
            //info.hit.Add("key1", "value1");

            //var json = info.SaveToString();
            //Debug.Log(json);
        }

        // 4
        {
            //var info = new PlayerInfo();

            //info.name = "Dr Charles";
            //info.lives = 3;
            //info.health = 0.8f;
            //info.myClass = new MyClass2();
            //info.array = new int[3] { 10, 20, 30 };

            //var json = info.SaveToString();
            //Debug.Log(json);
        }

        // 5
        {
            //var info = new PlayerInfo();

            //info.name = "Dr Charles";
            //info.lives = 3;
            //info.health = 0.8f;
            //info.myClass = new MyClass2();
            //info.array = new int[3] { 10, 20, 30 };
            //info.hit = new Hashtable();
            //info.hit.Add("key1", "value1");
            //info.position = new Vector3(1, 2, 3);

            //var json = JsonConvert.SerializeObject(info, new Vector3Converter());
            //Debug.Log(json);
        }
    }
}
