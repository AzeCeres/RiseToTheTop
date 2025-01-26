using Script.Player;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private GameObject bubble;
    private int currentHealth;
    private Vector3 originalScale;
    
    public void Start()
    {
        currentHealth = maxHealth;
        originalScale = bubble.transform.localScale;
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            Die();
        }
        Size();
    }
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        Size();
    }
    void Size()
    {
        bubble.transform.localScale = new Vector3(currentHealth / maxHealth, currentHealth / maxHealth, currentHealth / maxHealth);
    }
    public void Die()
    {
        // Death animation
        // Death sound
        // Death effects
    }
}
