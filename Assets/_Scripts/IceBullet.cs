using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 8f;
    [SerializeField] private int bulletDamage = 1;
    private float freezeDuration; 

    private Transform target;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    public void SetFreezeEffect(float duration)
    {
        freezeDuration = duration;
    }

    private void FixedUpdate()
    {
        if (!target) return;

        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ice Bullet Hit!");

        EnemyMovement enemy = other.gameObject.GetComponent<EnemyMovement>();
        if (enemy != null)
        {
            enemy.Freeze(freezeDuration); 
        }

        other.gameObject.GetComponent<EnemyHealth>()?.TakeDamage(bulletDamage);

        Destroy(gameObject);
    }
}








