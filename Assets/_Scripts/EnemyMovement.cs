using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private int damageToBase = 10; // Amount of damage enemy deals to the base

    private Transform target;
    private int pathIndex = 0;
    private bool isFrozen = false;

    private void Start()
    {
        target = LevelManager.main.path[0];
    }

    private void Update()
    {
        if (isFrozen) return;

        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;
            if (pathIndex == LevelManager.main.path.Length)
            {
                DealDamageToBase();
                Destroy(gameObject);
            }
            else
            {
                target = LevelManager.main.path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        if (isFrozen) return;

        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

    private void DealDamageToBase()
    {
        if (PlayerHealth.instance != null)
        {
            PlayerHealth.instance.TakeDamage(damageToBase);
        }
        else
        {
            Debug.LogWarning("PlayerHealth instance not found!");
        }
    }

    public void Freeze(float duration)
    {
        StartCoroutine(FreezeCoroutine(duration));
    }

    private IEnumerator FreezeCoroutine(float duration)
    {
        isFrozen = true;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(duration);
        isFrozen = false;
    }
}


















