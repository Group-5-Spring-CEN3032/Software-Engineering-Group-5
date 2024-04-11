using Palmmedia.ReportGenerator.Core.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;

[ExecuteInEditMode]
public class PersistentClass : MonoBehaviour
{
    [SerializeField] private string uuid;
    public string UUID { 
        set {
            uuid = value;
        } 
        get { 
            if (uuid == null || uuid == "") { uuid = GenerateUUID(); }
            return uuid; 
        } 
        
    }

    public void OnSerialize(object target)
    {
        string json = JsonUtility.ToJson(target);
        string filename = target.GetType() + "-" + UUID + ".json";
        string directory = Application.persistentDataPath + "/persistence/";
        string path = directory + filename;
        Debug.Log(json);
        Debug.Log(filename);
        Debug.Log(directory);
        Debug.Log(path);
        UnicodeEncoding e = new UnicodeEncoding();
        if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
        File.WriteAllBytes(path, e.GetBytes(json.ToCharArray()));
    }

    public void OnDeserialize()
    {
        
    }

    

    string GenerateUUID()
    {
        /*DateTime currentTime = DateTime.Now;
        long unixTime = ((DateTimeOffset)currentTime).ToUnixTimeSeconds();
        UnityEngine.Random.InitState((int)unixTime);
        UnityEngine.Random*/

        float r = UnityEngine.Random.Range(0f, 1f);
        long ID = (long)(long.MaxValue * r);
        return ID + "";
    }
}
