using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickAndDrop : MonoBehaviour
{
    [SerializeField] private int _gridSize;
    [SerializeField] private LayerMask _fruitLayer;
    [SerializeField] private float _throwForce = 32f;
    private InputAction _interact;
    private InputAction _boost;
    private RaycastHit2D _hit;
    private RaycastHit2D _hit2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _interact = InputSystem.actions.FindAction("Interact");
        _boost = InputSystem.actions.FindAction("Throw");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;

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

        if (PlayerAbilityManager.Instance.CanPickUp)
        {
            if (_boost.WasPressedThisFrame())
            {
                if (!_hit2)
                {
                    _hit2 = Physics2D.Raycast(transform.position, transform.up, distance: _gridSize, layerMask: _fruitLayer);

                    if (_hit2)
                    {
                        _hit2.transform.SetParent(gameObject.transform);
                        _hit2.transform.GetComponent<Collider2D>().isTrigger = true;
                    }
                }
                else
                {
                    _hit2.transform.GetComponent<Collider2D>().isTrigger = false;
                    _hit2.transform.parent = null;
                    _hit2 = default;
                }
            }
        }
        
        if (PlayerAbilityManager.Instance.CanThrow)
        {
            if (_boost.WasPressedThisFrame() && _hit)
            {
                _hit.transform.parent = null;
                _hit.transform.GetComponent<Rigidbody2D>().AddForce(transform.up * _throwForce);
                _hit = default;
            }
        }
    }
}
