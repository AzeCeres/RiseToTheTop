namespace Script.Player
{
    public interface IDamageable
    {
        //private int maxHealth = 100;
        //private int currentHealth;
        public void TakeDamage(int damage)
        {
            //currentHealth -= damage;
            //if (currentHealth <= 0)
            //{
            //    Die();
            //}
        }
        public void Heal(int healAmount)
        {
            //currentHealth += healAmount;
            //if (currentHealth > maxHealth)
            //{
            //    currentHealth = maxHealth;
            //}
        }
        void Die()
        {
            // Death animation
            // Death sound
            // Death effects
        }
    }
}
