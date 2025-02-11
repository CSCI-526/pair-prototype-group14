using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 2.0f;  // 敌人移动速度
    private Transform target;   // 目标点（终点）
    private bool isDamaged = false; // **防止重复触发**

    void Start()
    {
        GameObject endTriggerObject = GameObject.Find("EndTrigger");
        if (endTriggerObject != null)
        {
            target = endTriggerObject.transform;
        }
    }

    void Update()
    {
        if (target != null && !isDamaged)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDamaged) return;

        if (other.gameObject.CompareTag("EndTrigger"))
        {
            //Debug.Log(gameObject.name + " 进入 EndTrigger，造成伤害！");

            isDamaged = true;  // **防止重复扣血**

            // 造成伤害
            EndTrigger endTrigger = other.GetComponent<EndTrigger>();
            if (endTrigger != null)
            {
                endTrigger.TakeDamage(1);
            }

            // **停止移动**
            StopEnemy();
        }
    }

    void StopEnemy()
    {
        //Debug.Log(gameObject.name + " 停止移动！");
        speed = 0; // **速度归零**
        transform.position += new Vector3(0.5f, 0, 0); // **稍微移动到终点后方**
    }
}
