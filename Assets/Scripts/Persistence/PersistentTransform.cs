using UnityEngine;

public class PersistentTransform : PersistentClass<TransformStruct>
{

    void OnEnable()
    {
        TransformStruct t = Deserialize();
        if (t != null) t.Apply(transform);
    }

    void OnDisable()
    {
        Serialize(new TransformStruct(transform));
    }
}

public class TransformStruct
{
    public Vector3 postion;
    public Quaternion rotation;
    public Vector3 scale;

    public TransformStruct(Transform t)
    {
        this.postion = t.position;
        this.rotation = t.rotation;
        this.scale = t.localScale;
    }

    public void Apply(Transform t)
    {
        t.position = postion;
        t.rotation = rotation;
        t.localScale = scale;
    }
}
