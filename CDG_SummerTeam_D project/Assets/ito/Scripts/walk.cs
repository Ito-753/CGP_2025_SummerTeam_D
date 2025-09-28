using UnityEngine;
using UnityEngine.InputSystem;

public class Walk : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private Vector2 moveInput;
    private float speed = 3f;

    private PlayerControls controls;

    void Awake()
    {
        controls = new PlayerControls();

        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
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
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Vector3 velocity = new Vector3(moveInput.x, 0, moveInput.y).normalized;
        rb.linearVelocity = velocity * speed;
    }

    void Update()
    {
        Vector3 velocity = new Vector3(moveInput.x, 0, moveInput.y).normalized;
        anim.SetBool("walking", velocity.magnitude > 0.1f);
    }
}
