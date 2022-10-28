using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    [Range(1, 20)][SerializeField] private float _lifeTime;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(_lifeTime);
        Kill();
    }

    private void FixedUpdate()
    {
        var direction = PlayerController.Instance.transform.position - transform.position; // iki nokta aras�nda y�n belirtmi� olduk
        direction = direction.normalized; // direction uzunlu�u ne olursa olsun de�eri 0-1 aras�nda getir.

        var rotateAmount = Vector3.Cross(direction, transform.up).z;

        // missile move start
        _rigidbody2D.velocity = transform.up * (_moveSpeed * Time.deltaTime);
        _rigidbody2D.angularVelocity = -rotateAmount * (_rotateSpeed * Time.deltaTime);
        // missile move end
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile"))
        {
            Kill();
        }
    }

    private void Kill()
    {
        _spriteRenderer.enabled = false;
        _boxCollider2D.enabled = false;
        _moveSpeed = 0;
    }
}
