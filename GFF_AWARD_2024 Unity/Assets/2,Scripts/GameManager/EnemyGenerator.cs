using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public enum EnemySpawnPoint // 敵出現位置
    {
        /* メモ：enum(列挙型)は「複数の定数を一つに纏めることができる型」
                switch文で処理を場合分けしたいときに有効*/

        // ランダム、上、下、左、右、左上、左下、右上、右下
        Random, 
        Upward_Direction, 
        Downward_Direction, 
        Leftward_Direction, 
        Rightward_Direction,
        UpLeft_Direction, 
        UpRight_Direction, 
        DownLeft_Direction, 
        DownRight_Direction
    }

    [System.Serializable]
    public class EnemySpawnInfo // 敵出現情報
    {
        [Header("敵の種類")]
        public GameObject enemyPrefab; // 生成する敵のプレハブを決める 

        [Header("敵の数")]
        public int enemySpawnCount;    // 生成する敵の数を決める

        [Header("出現までの時間")]
        public float spawnDelay;       // 生成を開始するまでの時間

        [Header("生成間隔")]
        public float spawnInterval;    // 敵の出現間隔

        [Header("出現場所")]
        public EnemySpawnPoint enemySpawnPoint;  // 生成する場所を決める
    }

    [System.Serializable]
    public class WaveInfo // ウェーブ数
    {
        public List<EnemySpawnInfo> enemySpawnInfos = new List<EnemySpawnInfo>(); // 各ウェーブごとの敵出現情報
    }

    [Header("ウェーブ情報リスト")]
    public List<WaveInfo> waveInfos = new List<WaveInfo>();

    public GameObject player; // プレイヤーの位置を取得

    [Header("プレイヤーから敵生成位置までの距離")]
    public float spawnDistance = 5f; // プレイヤーからスポーン位置までの距離

    private int currentWave = 0; // 現在のウェーブ番号
    private bool enemySpawnSwitch = false; // 敵の生成を行うかどうかのスイッチ

    void Start()
    {
        if (player == null) // プレイヤーオブジェクトが設定されていなければ
        {
            player = GameObject.FindWithTag("Player"); // プレイヤータグを持つオブジェクトを探す

            if (player == null) // 探しても見つからなければ
            {
                Debug.LogError("シーン内にプレイヤーオブジェクトが見つからず、敵の生成を開始できません。");
            }
        }

        if (player != null) // プレイヤーオブジェクトが設定されているとき
        {
            enemySpawnSwitch = true;
            StartCoroutine(StartWave(currentWave)); // 最初のウェーブを開始する
        }
    }

    IEnumerator StartWave(int waveIndex)
    {
        if (waveIndex >= waveInfos.Count)
        {
            Debug.Log("ゲームクリア！");
            yield break; // 全ウェーブが終了した場合は処理を終了する
        }

        Debug.Log($"ウェーブ{waveIndex + 1}開始！");

        WaveInfo currentWaveInfo = waveInfos[waveIndex];

        foreach (var spawnInfo in currentWaveInfo.enemySpawnInfos)
        {
            StartCoroutine(SpawnEnemies(spawnInfo));
        }
    }

    IEnumerator SpawnEnemies(EnemySpawnInfo spawnInfo)
    {
        yield return new WaitForSeconds(spawnInfo.spawnDelay); // 指定された遅延時間を待つ

        for (int i = 0; i < spawnInfo.enemySpawnCount; i++)
        {
            Vector3 spawnPosition = GetSpawnPosition(spawnInfo.enemySpawnPoint);
            Instantiate(spawnInfo.enemyPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInfo.spawnInterval); // 指定された間隔で敵を生成する
        }

        // ウェーブ中のすべての敵を生成した後、次のウェーブに移行する条件を確認する
        if (AllEnemiesCleared())
        {
            currentWave++;
            StartCoroutine(StartWave(currentWave));
        }
    }

    Vector3 GetSpawnPosition(EnemySpawnPoint spawnPoint)
    {
        Vector3 direction = Vector3.zero;

        switch (spawnPoint)
        {
            case EnemySpawnPoint.Upward_Direction:
                direction = Vector3.up;
                break;
            case EnemySpawnPoint.Downward_Direction:
                direction = Vector3.down;
                break;
            case EnemySpawnPoint.Leftward_Direction:
                direction = Vector3.left;
                break;
            case EnemySpawnPoint.Rightward_Direction:
                direction = Vector3.right;
                break;
            case EnemySpawnPoint.UpLeft_Direction:
                direction = (Vector3.up + Vector3.left).normalized;
                break;
            case EnemySpawnPoint.UpRight_Direction:
                direction = (Vector3.up + Vector3.right).normalized;
                break;
            case EnemySpawnPoint.DownLeft_Direction:
                direction = (Vector3.down + Vector3.left).normalized;
                break;
            case EnemySpawnPoint.DownRight_Direction:
                direction = (Vector3.down + Vector3.right).normalized;
                break;
            case EnemySpawnPoint.Random:
            default:
                direction = Random.insideUnitSphere.normalized;
                break;
        }

        return player.transform.position + direction * spawnDistance;
    }

    bool AllEnemiesCleared()
    {
        // 現在のシーン上の敵オブジェクトをカウントし、0の場合にクリアと判断する
        return GameObject.FindGameObjectsWithTag("Enemy").Length == 0;
    }

    public int GetCurrentWave()
    {
        return currentWave + 1; // 現在のウェーブを取得する（1ベース）
    }
}