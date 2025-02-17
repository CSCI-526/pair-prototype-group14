using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public int health = 10;          // 终点生命值
    private bool isGameOver = false; // 防止重复触发 GameOver

    public void TakeDamage(int damage)
    {
        if (isGameOver) return;
        if (health <= 0) return;

        health -= damage;
        Debug.Log("生命值减少，当前生命值: " + health);
        if (health <= 0)    GameOver();
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
}
