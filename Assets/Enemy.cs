using Script.Player;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int health = 10;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}

