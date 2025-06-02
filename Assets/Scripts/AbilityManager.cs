using UnityEngine;

public class PlayerAbilityManager : MonoBehaviour
{
    public static PlayerAbilityManager Instance;

    public bool CanPickUp { get; private set; }
    public bool CanThrow { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EnablePickUpAbility()
    {
        CanPickUp = true;
        CanThrow = false;
        Debug.Log("Pick Up ability enabled");
    }

    public void EnableThrowAbility()
    {
        CanPickUp = false;
        CanThrow = true;
        Debug.Log("Throw ability enabled");
    }
}