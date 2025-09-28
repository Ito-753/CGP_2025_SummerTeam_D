using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class TPSMovement : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;
    private PlayerControls controls;
    private Transform cam;
    private PlayerPowerUp powerUp;


    [Header("Settings")]
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float gravity = -9.81f;

    

    private Vector2 moveInput;
    private Vector3 velocity;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        powerUp = GetComponent<PlayerPowerUp>();
        controls = new PlayerControls();

        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput =Vector2.zero;

        controls.Player.Punch.performed += _ => Punch();
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {

        cam = Camera.main.transform;
    }

    void Update()
    {
        Move();
        ApplyGravity();
    }

    private void Move()
    {
    Vector3 forward = cam.forward;
    Vector3 right = cam.right;
    forward.y = 0;
    right.y = 0;
    forward.Normalize();
    right.Normalize();

    Vector3 moveDirection = forward * moveInput.y + right * moveInput.x;

    // 入力が無ければここで終了
    if (moveInput == Vector2.zero)
    {
        anim.SetBool("walking", false);
        return;
    }

    controller.Move(moveDirection * powerUp.currentSpeed * Time.deltaTime);

    // 回転処理
    Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
    transform.rotation = Quaternion.Slerp(
        transform.rotation,
        targetRotation,
        rotationSpeed * Time.deltaTime
    );

    // アニメーション
    anim.SetBool("walking", true);
    }

    private void Punch()
        {
        Debug.Log("パンチ発動！");

        // アニメーション再生
        anim.SetTrigger("Punch");

        // ここで当たり判定を呼ぶ or コルーチンで攻撃タイミングを制御してもOK
    }

    private void ApplyGravity()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // 地面に押し付ける
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
