using UnityEngine;
using System;

public class ObjectsController : MonoBehaviour
{
    [SerializeField] private ObjectsStorage _storage;

    public event Action<Transform> TargetChanged;

    private void OnEnable()
    {
        if(_storage == null)
            throw new NullReferenceException("Storage component is null");

        Init();
    }

    public void SetNewTarget(Transform target)
    {
        TargetChanged?.Invoke(target);
    }

    private void Init()
    {
        foreach (var objectsmover in _storage.Objects)
            objectsmover.Init(this);
    }
}
