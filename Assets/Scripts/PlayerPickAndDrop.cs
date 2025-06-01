using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickAndDrop : MonoBehaviour
{
    [SerializeField] private int _gridSize;
    [SerializeField] private LayerMask _fruitLayer;
    private InputAction _interact;
    private RaycastHit2D _hit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _interact = InputSystem.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {

        if (_interact.WasPressedThisFrame())
        {
            if (!_hit)
            {
                _hit = Physics2D.Raycast(transform.position, transform.up, distance: _gridSize, layerMask: _fruitLayer);

                if (_hit)
                {
                    _hit.transform.SetParent(gameObject.transform);
                    _hit.transform.GetComponent<Collider2D>().isTrigger = true;
                }
            }
                else
                {
                    _hit.transform.GetComponent<Collider2D>().isTrigger = false;
                    _hit.transform.parent = null;
                    _hit = default;
                }
        }
    }
}
