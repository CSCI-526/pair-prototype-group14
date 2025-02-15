using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    [Header("怪物生成配置")]
    public GameObject enemyPrefab;
    public Transform spawnPoint;

    // 预设3条路径，每条路径由一系列Transform构成
    public Transform[] path1;
    public Transform[] path2;
    public Transform[] path3;

    [Header("波次配置")]
    public int totalWaves = 3;           // 总波数
    public int enemiesPerWave = 10;      // 每波怪物数量
    public float timeBetweenWaves = 5f;  // 两波之间的间隔时间
    public float timeBetweenEnemies = 0.5f;  // 同一波内怪物生成的间隔

    void Start(){
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves(){
        for(int wave = 0; wave < totalWaves; wave++){
            // 选择一条路径：这里采用随机选择的方式
            Transform[] selectedPath = ChoosePath(wave);

            // 在一波中，依次生成多个怪物
            for(int i = 0; i < enemiesPerWave; i++){
                GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                // 将选定的路径赋值给怪物
                enemy.GetComponent<Enemy>().waypoints = selectedPath;
                yield return new WaitForSeconds(timeBetweenEnemies);
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    // 随机选择一条预设的路径
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
}
