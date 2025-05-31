using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGridMovement : MonoBehaviour
{
    [SerializeField] private int _gridSize;
    private InputAction _movementDir;
    private Vector3 _move;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _movementDir = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        if(_movementDir.WasPressedThisFrame())
            _move = _movementDir.ReadValue<Vector2>();

        if (_move != Vector3.zero)
        {
            transform.position += _gridSize * _move;
            float angle = Mathf.Atan2(-_move.x,_move.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            _move = Vector3.zero;
        }
    }
}
