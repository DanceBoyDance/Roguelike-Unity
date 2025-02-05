using Unity.VisualScripting;
using UnityEngine;

public class CurrencyPickup : MonoBehaviour
{
    public enum pickupObjects { COIN, GEM };
    public pickupObjects currentPickup;
    public int pickupQuantity;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats.playerStats.AddCurrency(this);
            Destroy(gameObject);
        }
    }
}
