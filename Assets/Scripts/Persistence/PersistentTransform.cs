using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PersistentClass))]
public class PersistentTransform : MonoBehaviour
{
    private PersistentClass pc;

    void Start()
    {
        pc = GetComponent<PersistentClass>();
        Serialize();
    }


    public void Serialize()
    {
        TransformStruct t = new TransformStruct();
        t.postion = transform.position;
        t.rotation = transform.rotation;
        t.scale = transform.localScale;
        pc.OnSerialize(t);
    }

    void OnDisable()
    {
        
    }
}

public struct TransformStruct
{
    public Vector3 postion;
    public Quaternion rotation;
    public Vector3 scale;
}
