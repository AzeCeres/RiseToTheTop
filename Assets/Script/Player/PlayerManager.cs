using System;
using Script.Player;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
{
    [SerializeField] public int maxHealth { get; private set; } = 100;
    [SerializeField] private GameObject bubble;
    public int currentHealth { get; private set; }
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
        var newScale = originalScale.x * (currentHealth / (float)maxHealth);
        bubble.transform.localScale = new Vector3(newScale, newScale, newScale);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        print("Trigger");
        if (other.gameObject.CompareTag("Air"))
        {
            Heal(1);
        }
        Heal(1);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
    }
    public void Die()
    {
        // Death animation
        // Death sound
        // Death effects
    }
}
