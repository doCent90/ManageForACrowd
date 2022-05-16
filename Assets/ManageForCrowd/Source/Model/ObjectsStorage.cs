using UnityEngine;
using System.Collections.Generic;
using System;

public class ObjectsStorage : MonoBehaviour
{
    [SerializeField] private List<ObjectMover> _objects;

    public IReadOnlyList<ObjectMover> Objects => _objects;

    private void Awake()
    {
        if(_objects == null)
            throw new ArgumentOutOfRangeException("Storage is empty");
    }
}
