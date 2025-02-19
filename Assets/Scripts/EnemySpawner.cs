using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    [Header("UI配置")]
    public GameObject congratulationsCanvas;     // UI 组件 - 胜利界面
    public TextMeshProUGUI waveText;             // UI 组件 - 剩余波数

    [Header("怪物波次配置")]
    public Wave[] enemyWaves;
    private int totalWaves;

    [System.Serializable]
    public class Wave
    {
        [Header("Configuration Per Wave")]
        public GameObject enemyPrefab;           // 敌人类型
        public int enemyCount = 5;               // 这一波的敌人数量
        public Transform spawnPoint;             // 敌人出生点
        public float timeBetweenEnemies = 0.5f;  // 同一波内怪物生成的间隔
        public Transform[] path;                 // 敌人路径点
        public float timeAfterWave = 5f;         // 与下一波的间隔时间
    }

    void Start()
    {
        Time.timeScale = 1f;
        if (congratulationsCanvas !=null)   congratulationsCanvas.SetActive(false);

        totalWaves = enemyWaves.Length;
        UpdateWaveUI(totalWaves);
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        for (int wave =0; wave < totalWaves; wave++)
        {
            UpdateWaveUI(totalWaves -wave);

            Wave waveConfig = enemyWaves[wave];
            for(int i = 0; i < waveConfig.enemyCount; i++)
            {
                GameObject enemy = Instantiate(waveConfig.enemyPrefab, waveConfig.spawnPoint.position, Quaternion.identity);
                enemy.GetComponent<Enemy>().waypoints = waveConfig.path;
                yield return new WaitForSeconds(waveConfig.timeBetweenEnemies);
            }
            yield return new WaitForSeconds(waveConfig.timeAfterWave);
        }

        while (FindObjectsOfType<Enemy>().Length > 0)   yield return new WaitForSeconds(2f);
        ShowSuccessScreen();
    }

    void ShowSuccessScreen()
    {
        Debug.Log("显示Success界面");
        Time.timeScale =1f;
        if (congratulationsCanvas !=null)   congratulationsCanvas.SetActive(true);
        Time.timeScale=0;
    }

    public void EndGame()
    {
        Time.timeScale =1f;
        SceneManager.LoadScene("Panel");
    }
    
    void UpdateWaveUI(int remainingWaves)
    {
        if (waveText !=null)    waveText.text ="Waves: "+remainingWaves;
    }
}
