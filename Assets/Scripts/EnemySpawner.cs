using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{
    [Header("Total Enemy Waves Configration")]
    public Wave[] enemyWaves;

    [System.Serializable]
    public class Wave
    {
        [Header("Configuration Per Wave")]
        public GameObject enemyPrefab;           // 敌人类型
        public int enemyCount;                   // 这一波的敌人数量
        public Transform spawnPoint;             // 敌人出生点
        public float timeBetweenEnemies = 0.5f;  // 同一波内怪物生成的间隔
        public Transform[] path;                 // 敌人路径点
        public float timeAfterWave = 5f;         // 与下一波的间隔时间
    }

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        for(int wave = 0; wave < enemyWaves.Length; wave++)
        {
            Wave waveConfig = enemyWaves[wave];
            for(int i = 0; i < waveConfig.enemyCount; i++)
            {
                GameObject enemy = Instantiate(waveConfig.enemyPrefab, waveConfig.spawnPoint.position, Quaternion.identity);
                enemy.GetComponent<Enemy>().waypoints = waveConfig.path;
                yield return new WaitForSeconds(waveConfig.timeBetweenEnemies);
            }
            yield return new WaitForSeconds(waveConfig.timeAfterWave);
        }

        int resEnemyCount = FindObjectsOfType<Enemy>().Length;
        Debug.Log("Enemy Remaining: " + resEnemyCount);
        while(resEnemyCount > 0)
        {
            yield return new WaitForSeconds(2f);
            resEnemyCount = FindObjectsOfType<Enemy>().Length;
            Debug.Log("Enemy Remaining: " + resEnemyCount);
        }
        
        if(resEnemyCount == 0)  ShowSuccessScreen();
    }

    void ShowSuccessScreen()
    {
        Debug.Log("显示 Success 界面");
        Time.timeScale = 0;
    }
}
