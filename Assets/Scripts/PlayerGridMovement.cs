using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGridMovement : MonoBehaviour
{
    [SerializeField] private int _gridSize;
    private LayerMask _layers;
    private InputAction _movementDir;
    private Vector3 _move;
    private RaycastHit2D _cantPass;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _movementDir = InputSystem.actions.FindAction("Move");
        _layers = ~LayerMask.GetMask("Fruit", "Ignore Raycast");
        Timer.Instance.StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        SnapToGrid();

        if (_movementDir.WasPressedThisFrame())
        {
            _move = _movementDir.ReadValue<Vector2>();
            _cantPass = Physics2D.Raycast(transform.position, _move, distance: _gridSize, _layers);
            float angle = Mathf.Atan2(-_move.x, _move.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        if (_move != Vector3.zero && !_cantPass)
        {
            transform.position += _gridSize * _move;
            _move = Vector3.zero;
        }
    }

    void SnapToGrid()
    {
        float x = Mathf.Round(transform.position.x / _gridSize) * _gridSize;
        float y = Mathf.Round(transform.position.y / _gridSize) * _gridSize;
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
