using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class TPSMovement : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;
    private PlayerControls controls;
    private Transform cam;

    [Header("Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;

    private Vector2 moveInput;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        controls = new PlayerControls();

        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput =Vector2.zero;
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
    controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    
    if (moveDirection.sqrMagnitude > 0.01f)
        {
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.Slerp(
        transform.rotation,
        targetRotation,
        rotationSpeed * Time.deltaTime
        );
        }
    anim.SetBool("walking",moveDirection.magnitude > 0.1f);
    }
}