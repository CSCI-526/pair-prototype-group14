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
        GameObject enemy = GameObject.FindWithTag("Enemy");
        float distance = Vector2.Distance(firePoint.position, enemy.transform.position);
        if (enemy != null && distance <= maxDistance){
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Bullet>().SetTarget(enemy.transform);
        }
    }
}
