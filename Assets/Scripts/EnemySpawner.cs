using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject congratulationsText;
    [Header("怪物生成配置")]
    public GameObject enemyPrefab;
    public Transform spawnPoint;

    // 预设3条路
    public Transform[] path1;
    public Transform[] path2;
    public Transform[] path3;

    [Header("波次配置")]
    public int totalWaves = 3;               // 总波数
    public int enemiesPerWave = 10;          // 每波怪物数量
    public float timeBetweenWaves = 5f;      // 两波之间的间隔时间
    public float timeBetweenEnemies = 0.5f;  // 同一波内怪物生成的间隔

    void Start()
    {
        Time.timeScale = 1f; // 确保游戏速度恢复正常
        congratulationsText.gameObject.SetActive(false);
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        for (int wave = 0; wave < totalWaves; wave++)
        {
            Transform[] selectedPath = ChoosePath(wave);

            for (int i = 0; i < enemiesPerWave; i++)
            {
                GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                enemy.GetComponent<Enemy>().waypoints = selectedPath;
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }

        // 等待所有敌人消灭
        while (FindObjectsOfType<Enemy>().Length > 0)
        {
            yield return new WaitForSeconds(2f);
        }

        ShowSuccessScreen(); // 所有敌人清除后，回到 `MainMenu`
    }

    Transform[] ChoosePath(int wave)
    {
        if (wave == 0)
        {
            return path1;
        }
        else if (wave == 1)
        {
            return path2;
        }
        else if (wave == 2)
        {
            return path3;
        }
        return path1;
    }

    void ShowSuccessScreen()
    {
        Debug.Log("显示 Success 界面");
        Time.timeScale = 1f; // 确保返回主菜单前游戏恢复正常
        congratulationsText.gameObject.SetActive(true);
        // Invoke("LoadPanel", 1f);
        // yield return new WaitForSeconds(2f);
        // SceneManager.LoadScene("MainMenu"); // 游戏胜利后回到主菜单
    }

    void LoadPanel()
    {
        SceneManager.LoadScene("Panel"); // 游戏胜利后回到主菜单
    }

    public void EndGame()
    {
        Debug.Log("游戏结束，返回 MainMenu...");
        Time.timeScale = 1f; // 确保返回主菜单前游戏恢复正常
        SceneManager.LoadScene("MainMenu"); // 直接回到主菜单
    }
}
