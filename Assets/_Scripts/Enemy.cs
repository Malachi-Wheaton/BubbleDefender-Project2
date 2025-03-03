using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public int health = 3;
    public Transform[] pathPoints;
    private int targetIndex = 0;

    void Update()
    {
        if (targetIndex < pathPoints.Length)
        {
            transform.position = Vector2.MoveTowards(transform.position, pathPoints[targetIndex].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, pathPoints[targetIndex].position) < 0.1f)
                targetIndex++;
        }
        else
        {
            PlayerHealth.instance.TakeDamage(1);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);
    }
}



