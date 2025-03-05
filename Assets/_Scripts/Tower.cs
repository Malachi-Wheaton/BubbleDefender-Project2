using UnityEngine;
using System.Collections.Generic;

public class Tower : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCooldown = 0f;
    private List<Enemy> enemiesInRange = new();

    void Update()
    {
        {
            fireCooldown -= Time.deltaTime;

            // Remove any destroyed enemies from the list
            enemiesInRange.RemoveAll(enemy => enemy == null);

            if (fireCooldown <= 0f && enemiesInRange.Count > 0)
            {
                Shoot(enemiesInRange[0]);
                fireCooldown = fireRate;
            }
        }

    }

    void Shoot(Enemy enemy)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().target = enemy;
        Debug.Log("FIRE");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Enemy>(out var enemy))
            enemiesInRange.Add(enemy);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Enemy>(out var enemy))
            enemiesInRange.Remove(enemy);
    }
}

