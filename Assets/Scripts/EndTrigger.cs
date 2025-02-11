using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public int health = 10;  // 终点生命值
    private bool isGameOver = false; // 防止重复触发 GameOver

    public void TakeDamage(int damage)
    {
        if (isGameOver) return; // **如果游戏已经结束，就不再扣血**
        if (health <= 0) return;

        health -= damage;
        if (health < 0) health = 0;

        //Debug.Log("EndTrigger 生命值减少，当前生命值: " + health);

        if (health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        if (isGameOver) return; // **防止重复调用**
        isGameOver = true;

        //Debug.Log("游戏失败！终点被摧毁！");

        // **暂停游戏**
        Time.timeScale = 0;

        // 这里可以添加游戏失败的 UI
        ShowGameOverScreen();
    }

    void ShowGameOverScreen()
    {
        // 这里可以调用你的 UI 管理器，显示一个 Game Over 界面
        Debug.Log("显示 Game Over 界面");
    }
}
