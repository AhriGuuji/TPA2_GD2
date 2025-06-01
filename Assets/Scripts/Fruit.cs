using System.Collections;
using UnityEngine;

public abstract class Fruit : MonoBehaviour
{
    public abstract int _Score { get; set; }
    [SerializeField] protected float _lifeSpan;

    void Start()
    {
        StartCoroutine(RootingTime());
    }

    public IEnumerator RootingTime()
    {
        yield return new WaitForSeconds(_lifeSpan);

        GetComponent<SpriteRenderer>().color = Color.black;
        _Score = 0;

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
}
