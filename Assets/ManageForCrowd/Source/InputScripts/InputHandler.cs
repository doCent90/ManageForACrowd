using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private ObjectsController _objectsController;
    [Header("Targets")]
    [SerializeField] private Transform _redTarget;
    [SerializeField] private Transform _blueTarget;
    [SerializeField] private Transform _greenTarget;
    [Header("Buttons")]
    [SerializeField] private Button _red;
    [SerializeField] private Button _blue;
    [SerializeField] private Button _green;
    [SerializeField] private Button _stop;

    private void OnEnable()
    {
        _stop.onClick.AddListener(Stop);
        _red.onClick.AddListener(SetRedTarget);
        _blue.onClick.AddListener(SetBlueTarget);
        _green.onClick.AddListener(SetGreenTarget);
    }

    private void OnDisable()
    {
        _stop.onClick.RemoveListener(Stop);
        _red.onClick.RemoveListener(SetRedTarget);
        _blue.onClick.RemoveListener(SetBlueTarget);
        _green.onClick.RemoveListener(SetGreenTarget);
    }

    private void SetRedTarget()
    {
        _objectsController.SetNewTarget(_redTarget);
    }

    private void SetBlueTarget()
    {
        _objectsController.SetNewTarget(_blueTarget);
    }

    private void SetGreenTarget()
    {
        _objectsController.SetNewTarget(_greenTarget);
    }

    private void Stop()
    {
        _objectsController.Stop();
    }
}
