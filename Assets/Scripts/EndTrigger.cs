using System.Collections;
using System.Collections.Generic;
using TMPro;  // 引入 TextMeshPro 命名空间
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public int health = 10;          // 终点生命值
    private bool isGameOver = false; // 防止重复触发 GameOver

    public TextMeshProUGUI healthText;  // 生命值 UI 组件

    void Start()
    {
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        if (isGameOver) return;
        if (health <= 0) return;

        health -= damage;
        Debug.Log("生命值减少，当前生命值: " + health);

        UpdateHealthUI();  // 更新 UI

        if (health <= 0) GameOver();
    }

    void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        Time.timeScale = 0;
        ShowGameOverScreen();
    }

    void ShowGameOverScreen()
    {
        Debug.Log("显示 Game Over 界面");
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health " + health;
        }
    }
}
