using System;
using Script.Player;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float lifeTime = 2f;
    [SerializeField] private int damage = 1;
    private Rigidbody2D _rb;
    private GameObject _owner;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Destroy(gameObject, lifeTime);
        // Impulse
        _rb.AddForce(transform.up * moveSpeed, ForceMode2D.Impulse);
    }
    public void SetOwner(GameObject owner)
    {
        _owner = owner;
    }
    
    // CONSTANT SPEED (LINEAR MOVEMENT)
    //private void FixedUpdate()
    //{
    //    transform.position += (moveSpeed * Time.fixedDeltaTime) * transform.right;
    //}
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == _owner) return;
        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
