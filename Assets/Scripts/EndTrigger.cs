using System.Collections;
using System.Collections.Generic;
using TMPro;  // 引入TextMeshPro命名空间
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public int health = 10;          //终点生命值
    private bool isGameOver =false; //防止重复触发 GameOver

    public TextMeshProUGUI healthText;  //生命值 UI 组件
    public GameObject sorryYouLoseCanvas; //失败界面 Canvas
    void Start()
    {
        UpdateHealthUI();
        if (sorryYouLoseCanvas !=null)
        {
            sorryYouLoseCanvas.SetActive(false);  //初始时隐藏失败界面
        }
    }

    public void TakeDamage(int damage)
    {
        if (isGameOver) return;
        if (health <= 0) return;

        health -= damage;
        //Debug.Log("生命值减少，当前生命值: " + health);

        UpdateHealthUI(); //更新UI

        if (health <= 0) GameOver();
    }

    void GameOver()
    {
        if (isGameOver) return;
        isGameOver =true;
        Time.timeScale=0;
        if (sorryYouLoseCanvas !=null)
        {
            sorryYouLoseCanvas.SetActive(true); //显示失败界面
        }
    }

    void UpdateHealthUI()
    {
        if (healthText !=null)
        {
            healthText.text ="Health " + health;
        }
    }
}
