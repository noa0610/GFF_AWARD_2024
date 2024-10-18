using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public float moveSpeed = 5f; // 移動速度
    public float jumpForce = 5f; // ジャンプ力

    private Rigidbody rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // プレイヤーの移動処理
        Move();

        // ジャンプ処理
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Move()
    {
        // 入力の取得
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // 移動方向の計算
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized * moveSpeed;

        if (movement.magnitude > 0)
        {
            // Rigidbodyを使った移動
            rb.MovePosition(transform.position + movement * Time.deltaTime);
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    // 地面判定用のトリガーを使用した接触判定
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
