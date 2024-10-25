using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    // プレイヤーのTransform
    public Transform player;

    // 追尾する速度
    public float followSpeed = 1f;

    // 一定距離を保つかどうか
    public float stoppingDistance = 2f;

    void Update()
    {
        // プレイヤーとの距離を計算
        float distance = Vector3.Distance(transform.position, player.position);

        // プレイヤーが一定距離より遠ければ追尾する
        if (distance > stoppingDistance)
        {
            // プレイヤーの方向を計算
            Vector3 direction = (player.position - transform.position).normalized;

            // プレイヤーの方向に移動する
            transform.position += direction * followSpeed * Time.deltaTime;

            // プレイヤーの方を向くように回転
            transform.LookAt(player);
        }
    }
}
