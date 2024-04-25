using System.IO;
using UnityEngine;


[ExecuteInEditMode]
public abstract class PersistentClass<TargetType> : MonoBehaviour
{
    [SerializeField] private string uuid;

    public string GetUUID()
    {
        if (uuid == null || uuid == "") { uuid = GenerateUUID(); }
        return uuid;
    }

    public void Serialize(TargetType obj)
    {
        string plaintext = JsonUtility.ToJson(obj);
        StreamWriter sw = new StreamWriter(GetFilePath());
        sw.Write(plaintext);
        sw.Close();
    }

    public TargetType Deserialize()
    {
        FileInfo f = new FileInfo(GetFilePath());
        if (!f.Exists) return default(TargetType);
        StreamReader sr = new StreamReader(GetFilePath());
        string plaintext = sr.ReadToEnd();
        sr.Close();
        TargetType obj = JsonUtility.FromJson<TargetType>(plaintext);
        return obj;
    }

    string GetFilePath() { return Application.persistentDataPath + "/persistence/" + typeof(TargetType) + "-" + GetUUID() + ".json"; }

    string GenerateUUID()
    {
        float r = UnityEngine.Random.Range(0f, 1f);
        long ID = (long)(long.MaxValue * r);
        return ID + "";
    }
}
