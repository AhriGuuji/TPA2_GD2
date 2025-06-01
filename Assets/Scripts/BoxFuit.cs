using UnityEngine;

public class BoxFuit : MonoBehaviour
{
    [SerializeField] private string _fruitName;
    private Fruit _fruit;
    void OnCollisionStay2D(Collision2D collision)
    {
        _fruit = collision.gameObject.GetComponent<Fruit>();

        if (_fruit)
        {
            Destroy(collision.gameObject);
            if(_fruit.name.Contains(_fruitName))
                ScoreManager.Instance.AddScore(_fruit);
        }
    }
}
