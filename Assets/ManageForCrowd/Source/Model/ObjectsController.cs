using UnityEngine;
using System;

[RequireComponent(typeof(ObjectsStorage))]
public class ObjectsController : MonoBehaviour
{
    private ObjectsStorage _storage;

    public event Action Stoped;
    public event Action<Transform> TargetChanged;

    private void OnEnable()
    {
        _storage = GetComponent<ObjectsStorage>();
        Init();
    }

    public void SetNewTarget(Transform target)
    {
        TargetChanged?.Invoke(target);
    }

    public void Stop()
    {
        Stoped?.Invoke();
    }

    private void Init()
    {
        foreach (var objectsmover in _storage.Objects)
            objectsmover.Init(this);
    }
}
