using Script.Player;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
{
    public int maxHealth = 100;
    public int currentHealth;
    public void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    public void Die()
    {
        // Death animation
        // Death sound
        // Death effects
    }
}
