using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;// 引入 TextMeshPro 命名空间

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

    public TextMeshProUGUI waveText; // UI 组件 - 显示剩余波数

    void Start()
    {
        Time.timeScale = 1f; // 确保游戏速度恢复正常
        congratulationsText.gameObject.SetActive(false);
        UpdateWaveUI(totalWaves); // 初始化 UI
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        for (int wave =0; wave < totalWaves; wave++)
        {
            UpdateWaveUI(totalWaves -wave); // 更新波次 UI

            Transform[] selectedPath =ChoosePath(wave);

            for (int i =0; i < enemiesPerWave; i++)
            {
                GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                enemy.GetComponent<Enemy>().waypoints =selectedPath;
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }

        //等待所有敌人消灭
        while (FindObjectsOfType<Enemy>().Length > 0)
        {
            yield return new WaitForSeconds(2f);
        }

        ShowSuccessScreen();//所有敌人清除后回到 `MainMenu`
    }

    Transform[] ChoosePath(int wave)
    {
        if (wave ==0)
        {
            return path1;
        }
        else if (wave ==1)
        {
            return path2;
        }
        else if (wave ==2)
        {
            return path3;
        }
        return path1;
    }

    void ShowSuccessScreen()
    {
        Debug.Log("显示Success界面");
        Time.timeScale =1f; //确保返回主菜单前游戏恢复正常
        congratulationsText.gameObject.SetActive(true);
    }



    public void EndGame()
    {
        Time.timeScale =1f; //确保返回主菜单前游戏恢复正常
        SceneManager.LoadScene("Panel");//直接回到主菜单
    }
    //更新UI上的波次显示
    void UpdateWaveUI(int remainingWaves)
    {
        if (waveText !=null)
        {
            waveText.text ="Waves: "+remainingWaves;
        }
    }
}
