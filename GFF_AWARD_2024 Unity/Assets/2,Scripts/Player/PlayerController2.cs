using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f; // インスペクターで設定可能な移動速度
    [SerializeField] public float jumpForce = 5f; // インスペクターで設定可能なジャンプ力
    [SerializeField] public float mouseSensitivity = 2f; // マウス感度
    [SerializeField] public Transform playerCamera; // プレイヤーのカメラ

    private Rigidbody rb;
    private bool isGrounded = true;
    private float verticalRotation = 0f; // カメラの上下回転制御用

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // カーソルをロックして、マウス視点移動を有効にする
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        // プレイヤーの移動処理
        if (Input.GetKey(KeyCode.W)) // 前進
        {
            moveDirection += transform.forward;
        }
        else if (Input.GetKey(KeyCode.S)) // 後退
        {
            moveDirection -= transform.forward;
        }

        if (Input.GetKey(KeyCode.A)) // 左
        {
            moveDirection -= transform.right;
        }
        else if (Input.GetKey(KeyCode.D)) // 右
        {
            moveDirection += transform.right;
        }

        if (moveDirection != Vector3.zero)
        {
            Move(moveDirection);
        }

        // マウスによる視点移動の処理
        LookAround();

        // ジャンプ処理
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Move(Vector3 direction)
    {
        Vector3 movement = direction.normalized * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    void LookAround()
    {
        // マウスの入力を取得
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // プレイヤーの横回転
        transform.Rotate(0f, mouseX, 0f);

        // カメラの上下回転制御（垂直方向の回転は制限する）
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f); // 垂直方向の視点移動の制限

        // カメラの上下回転を適用
        playerCamera.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
