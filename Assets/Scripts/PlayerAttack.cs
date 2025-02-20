using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    [SerializeField] private float atkRange = 5f;
    //[SerializeField] private Transform turretRotationPoint;
    [SerializeField] private LayerMask enemyMask;
    
    //[SerializeField] private float bps = 1f;

    private Transform target;
    private float timeUntilFire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }
        else
        {
            // Vector3 from = transform.up;
            // Vector3 to = target.position - transform.position;
            // Debug.Log("from: " + from + ", to: " + to);
            // float angle = Vector3.Angle(from, to);
            // Vector3 rotationAxis = Vector3.Cross(from, to).normalized;
            // Quaternion rotation = Quaternion.AngleAxis(angle, rotationAxis);
            // transform.rotation = rotation;
            //transform.LookAt(target.transform, Vector3.forward);
            Vector3 dir = target.position - transform.position;
            //TODO: Direction vector should be rotated

            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            transform.rotation  = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        

        // if (!InRange())
        // {
        //     target = null;
        // }
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, atkRange, (Vector2) transform.position, 0f, enemyMask);
        if (hits.Length > 0)
        {
            //Debug.Log("FindTarget");
            target = hits[0].transform;
        }
    }

    private bool InRange()
    {
        return Vector2.Distance(target.position, transform.position) <= atkRange;
    }

    // private void RotateTowardsTarget()
    // {
    //     //transform.forward = target.position - transform.position;
    //     float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg;
    //     Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    //     transform.rotation = targetRotation;
    // }

    // void OnTriggerStay2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Enemy"))
    //     {
    //         timeUntilFire += Time.deltaTime;

    //         if (timeUntilFire >= 1f / bps)
    //         {
    //             Shoot();
    //         }
    //     }
    //     else
    //     {
    //         target = null;
    //     }
    // }

    // private void Shoot()
    // {
    //     Debug.Log("Shoot");
    // }
}
