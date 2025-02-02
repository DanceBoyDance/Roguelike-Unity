using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;
    public GameObject player;
    public float health;
    public float maxHealth;
    public int gold;
    public int gems;

    void Awake()
    {
        if (playerStats == null)
        {
            playerStats = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        health = maxHealth;

    }

    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
    }

    void CheckOverheal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    void CheckDeath()
    {
        if (health <= 0)
        {
            Destroy(player);
        }
    }

}
