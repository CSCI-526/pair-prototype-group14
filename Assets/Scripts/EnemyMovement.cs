using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool isDamaged = false;

    public Transform[] waypoints;
    public float moveSpeed = 3f;
    private int currentIndex = 0;

    public float HP = 100f;
    
    private Renderer enemyRenderer;
    private Color startColor = HexToColor("#FF5733");
    private Color endColor = HexToColor("#33FF57");
    public float duration = 3.0f;

    void Start()
    {
        enemyRenderer = transform.GetComponent<Renderer>();
        enemyRenderer.material.color = Color.red;
    }

    void Update()
    {
        if(currentIndex < waypoints.Length){
            Transform targetPoint = waypoints[currentIndex];
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position, targetPoint.position) < 0.1f){
                currentIndex++;
                // HP -= 30;
            }
        } else {
            // 到达终点，可以在这里添加触发事件（如扣血）等逻辑
            // Destroy(gameObject);
            // Debug.Log(gameObject.name + " destroy");
        }
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        Debug.Log("Enemy HP: " + HP);
        if (HP <= 0)
        {
            DestroyEnemy();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDamaged) return;

        if (other.gameObject.CompareTag("EndTrigger"))
        {
            isDamaged = true;
            EndTrigger endTrigger = other.GetComponent<EndTrigger>();
            if (endTrigger != null)
            {
                endTrigger.TakeDamage(1);
            }
            Debug.Log(gameObject.name + " make 1 damage");

            DestroyEnemy();
        }
    }

    void DestroyEnemy()
    {
        Debug.Log(gameObject.name + " destroy animation");
        float t = Mathf.PingPong(Time.time / duration, 1);
        enemyRenderer.material.color = Color.Lerp(startColor, endColor, t);
        Destroy(gameObject);
        Debug.Log(gameObject.name + " destroy");

    }

    private static Color HexToColor(string hex)
    {
        Color color;
        if (ColorUtility.TryParseHtmlString(hex, out color))
        {
            return color;
        }
        return Color.white;
    }
}
