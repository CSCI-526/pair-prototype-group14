using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float fireRate = 0.5f;
    private float nextFireTime = 0f;
    public float maxDistance = 10f;

    void Update()
    {
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
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Bullet>().SetTarget(enemy.transform);
        }
    }

    GameObject GetEnemyInRange(float radius)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        GameObject closest = null;
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
