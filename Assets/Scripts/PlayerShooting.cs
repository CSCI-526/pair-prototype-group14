using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private GameObject closest = null;
    public GameObject bulletPrefab;

    public float fireRate = 0.5f;
    private float nextFireTime = 0f;
    public float maxDistance = 10f;

    void Update()
    {
        // if (Time.time >= nextFireTime)
        // {
        //     Shoot();
        //     nextFireTime = Time.time + fireRate;
        // }
    }

    void FixedUpdate()
    {
        
        if (closest != null)
        {
            Transform target = closest.transform;
            Vector3 dir = target.position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            transform.rotation  = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject enemy = GetEnemyInRange(maxDistance);
        if (enemy != null){
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Bullet>().SetTarget(enemy.transform);
        }
    }

    GameObject GetEnemyInRange(float radius)
    {
        closest = null;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        float minDistance = Mathf.Infinity;

        foreach (Collider2D col in colliders)
        {
            if (col.CompareTag("Enemy"))
            {
                // float distance = Vector2.Distance(transform.position, col.transform.position);
                float distance = Vector2.Distance(GameObject.Find("EndTrigger").transform.position, col.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closest = col.gameObject;
                }
            }
        }
        return closest;
    }
}
