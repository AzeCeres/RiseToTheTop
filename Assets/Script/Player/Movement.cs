using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float shotKnockback = 5f;
    [SerializeField] private int shotCost = 5;
    //[SerializeField] private float boostSpeed = 10f;
    [SerializeField] private float speedMultiplierMax = 2f;
    private float speedMultiplier = 1f;
    [SerializeField][Tooltip("The speed the character goes upwards")] private float floatSpeed = 5f;
   
    private Rigidbody2D _rb;
    private Input _input;
    private PlayerManager _playerManager;

    [SerializeField]private GameObject bullet;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _input = GetComponent<Input>();
        _playerManager = GetComponent<PlayerManager>();
    }
    
    private void FixedUpdate()
    {
        speedMultiplier = speedMultiplierMax - _playerManager.currentHealth / (float)_playerManager.maxHealth;
        _rb.AddForce(new Vector3(_input.moveDirection.x, _input.moveDirection.y, 0)* (speedMultiplier*moveSpeed), ForceMode2D.Force); 
    }
    void Update()
    {
        if (_input.isShooting)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        //Debug.Log("Shooting");
        if (_playerManager.currentHealth <= shotCost) return;
        var bulletObj = Instantiate(bullet, transform.position, transform.rotation);
        //var bulletClass = bullet.GetComponent<Bullet>();
        bullet.GetComponent<Bullet>().SetOwner(gameObject);
        _playerManager.TakeDamage(shotCost);
        _rb.AddForce(-transform.up * shotKnockback, ForceMode2D.Impulse);
    }
}
