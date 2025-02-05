using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;
    public GameObject player;
    public TextMeshProUGUI healthText;
    public Slider healthBarSlider;
    public float health;
    public float maxHealth;
    public int coins;
    public int gems;
    public TextMeshProUGUI coinsValue;
    public TextMeshProUGUI gemsValue;

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
        UpdateHealthUI();
        coinsValue.text = "Gold: " + coins.ToString();
        gemsValue.text = "Gems: " + gems.ToString();
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
        UpdateHealthUI();
    }

    public void HealCharacter(float heal)
    {
        health += heal;
        CheckOverheal();
        UpdateHealthUI();
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
            health = 0;
            Destroy(player);
        }
    }

    float CalculateHealthPercentage()
    {
        return health / maxHealth;
    }

    void UpdateHealthUI()
    {
        healthBarSlider.value = CalculateHealthPercentage();
        healthText.text = Mathf.Ceil(health).ToString() + "/" + Mathf.Ceil(maxHealth).ToString();
    }

    public void AddCurrency(CurrencyPickup currency) {
        if (currency.currentPickup == CurrencyPickup.pickupObjects.COIN)
        {
            coins += currency.pickupQuantity;
            coinsValue.text = "Gold: " + coins.ToString();
        }
        else if (currency.currentPickup == CurrencyPickup.pickupObjects.GEM)
        {
            gems += currency.pickupQuantity;
            gemsValue.text = "Gems: " + gems.ToString();
        }
    }
}
