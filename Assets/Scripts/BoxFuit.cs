using UnityEngine;

public class BoxFuit : MonoBehaviour
{
    [SerializeField] private string _fruitName;
    [SerializeField] private int _maxStorage = 10;
    [SerializeField] private Sprite _sprite;
    private Fruit _fruit;
    private int _count;

    void Start()
    {
        _count = 0;
    }

    void Update()
    {
        if (_count >= _maxStorage)
            gameObject.GetComponent<SpriteRenderer>().sprite = _sprite;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        _fruit = collision.gameObject.GetComponent<Fruit>();

        if (_fruit)
        {
            Destroy(collision.gameObject);
            if (_fruit.name.Contains(_fruitName) && _count < _maxStorage)
            {
                _count++;
                ScoreManager.Instance.AddScore(_fruit);
            }
        }
    }
}
