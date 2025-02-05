using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    protected GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        player = FindFirstObjectByType<PlayerMovement>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
