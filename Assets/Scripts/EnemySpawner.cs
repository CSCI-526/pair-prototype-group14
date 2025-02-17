using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
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

    void Start(){
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves(){
        for(int wave = 0; wave < totalWaves; wave++){
            Transform[] selectedPath = ChoosePath(wave);

            for(int i = 0; i < enemiesPerWave; i++){
                GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                enemy.GetComponent<Enemy>().waypoints = selectedPath;
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
        int enemyCount = FindObjectsOfType<Enemy>().Length;
        Debug.Log("当前场上敌人数量:" + enemyCount);
        while(enemyCount > 0){
            yield return new WaitForSeconds(2f);
            enemyCount = FindObjectsOfType<Enemy>().Length;
            Debug.Log("当前场上敌人数量: " + enemyCount);
        }
        if(enemyCount == 0){
            ShowSuccessScreen();
            Time.timeScale = 0;
        }    
    }

    Transform[] ChoosePath(int wave){
        if(wave == 0){
            return path1;
        }
        else if (wave == 1){
            return path2;
        }
        else if (wave == 2){
            return path3;
        }
        return path1;
    }

    void ShowSuccessScreen()
    {
        Debug.Log("显示 Success 界面");
    }
}
