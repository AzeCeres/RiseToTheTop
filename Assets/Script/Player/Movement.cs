using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float shotKnockback = 5f;
    
    //[SerializeField] private float boostSpeed = 10f;
    [SerializeField][Tooltip("The speed the character goes upwards")] private float floatSpeed = 5f;
   
    private Rigidbody2D _rb;
    private Input _input;

    [SerializeField]private GameObject bullet;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _input = GetComponent<Input>();
    }
    
    private void FixedUpdate()
    {
        _rb.AddForce(new Vector3(_input.moveDirection.x * moveSpeed, _input.moveDirection.y * moveSpeed, 0), ForceMode2D.Force); 
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
        var bulletObj = Instantiate(bullet, transform.position, transform.rotation);
        //var bulletClass = bullet.GetComponent<Bullet>();
        bullet.GetComponent<Bullet>().SetOwner(gameObject);
        _rb.AddForce(-transform.up * shotKnockback, ForceMode2D.Impulse);
    }
}
