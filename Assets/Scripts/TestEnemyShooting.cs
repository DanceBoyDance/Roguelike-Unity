using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TestEnemyShooting : MonoBehaviour
{
    public GameObject projectile;
    private GameObject player;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;
    public float cooldown;

    void Start()
    {
        StartCoroutine(ShootPlayer());
        player = FindFirstObjectByType<PlayerMovement>().gameObject;
    }


    IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(cooldown);
        if (player != null)
        {
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 direction = (player.transform.position - transform.position).normalized;
            spell.GetComponent<Rigidbody2D>().linearVelocity = direction * projectileForce;
            spell.GetComponent<TestEnemyProjectile>().damage = Random.Range(minDamage, maxDamage);
            StartCoroutine(ShootPlayer());
        }
    }
}
