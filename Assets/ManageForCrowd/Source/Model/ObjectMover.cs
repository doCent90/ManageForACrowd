using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ObjectMover : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private ObjectsController _objectsController;

    public event Action Moved;
    public event Action Stoped;

    private void OnEnable()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.isStopped = true;
    }

    private void OnDisable()
    {
        _objectsController.Stoped -= StopMove;
        _objectsController.TargetChanged -= MoveToTarget;        
    }

    public void Init(ObjectsController objectsController)
    {
        _objectsController = objectsController;
        _objectsController.Stoped += StopMove;
        _objectsController.TargetChanged += MoveToTarget;
    }

    private void MoveToTarget(Transform target)
    {
        _navMeshAgent.isStopped = false;
        Vector3 destination = target.position;
        _navMeshAgent.destination = destination;

        Moved?.Invoke();
    }

    private void StopMove()
    {
        _navMeshAgent.isStopped = true;
        Stoped?.Invoke();
    }
}
