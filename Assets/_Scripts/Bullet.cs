using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Enemy target;
    public float speed = 5f;
    public int damage = 1;

    void Update()
    {
        if (target == null) { Destroy(gameObject); return; }
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target.transform.position) < 0.1f)
        {
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
