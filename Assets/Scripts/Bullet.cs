using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 100;
    private Transform target;
    private Vector2 moveDirection;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        if (target != null)
        {
            moveDirection = (target.position - transform.position).normalized;
        }
        else
        {
            moveDirection = transform.right;
        }
    }

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        // if (target != null)
        // {
        //     moveDirection = (target.position - transform.position).normalized;
        // }
        transform.position += (Vector3)moveDirection * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Bullet triggered");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
