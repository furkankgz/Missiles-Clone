using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; } // Missiles tarafýndan referans alýnabilmesi için static hale getirdik.

    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    private float _input;

    private void Awake()
    {
        Instance = this; // Instance'ý kendisine eþitledik.
    }

    private void Update()
    {
        _input = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        // player move start
        _rigidbody2D.velocity = transform.up * (_moveSpeed * Time.deltaTime);
        _rigidbody2D.angularVelocity = -_input * (_rotateSpeed * Time.deltaTime);
        // player move end
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile"))
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
        }
    }
}
