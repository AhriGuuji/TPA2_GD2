using UnityEngine;

public class BoxFuit : MonoBehaviour
{
    private Fruit _fruit;
    void OnCollisionStay2D(Collision2D collision)
    {
        _fruit = collision.gameObject.GetComponent<Fruit>();
        Debug.Log(collision.transform.name);

        if (_fruit)
        {
            Destroy(collision.gameObject);
            ScoreManager.Instance.AddScore(_fruit);
        }
    }
}
