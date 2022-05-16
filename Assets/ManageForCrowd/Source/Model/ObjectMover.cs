using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ObjectMover : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private ObjectsController _objectsController;

    public event Action Moved;

    private void OnEnable()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.enabled = false;
    }

    private void OnDisable()
    {
        _objectsController.TargetChanged -= MoveToTarget;        
    }

    public void Init(ObjectsController objectsController)
    {
        _objectsController = objectsController;
        _objectsController.TargetChanged += MoveToTarget;
    }

    private void MoveToTarget(Transform target)
    {
        _navMeshAgent.enabled = true;
        Vector3 destination = target.position;
        _navMeshAgent.destination = destination;

        Moved?.Invoke();
    }
}
