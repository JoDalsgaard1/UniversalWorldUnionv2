using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float collisionFixForce = -0.5f;
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float playerRunSpeed = 3.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private float rotationSpeed = 5f;
    [SerializeField]
    private float animationSmoothTime = 0.1f;
    [SerializeField]
    //private float animationPlayTransition = 0.15f;
    private float initialPlayerSpeed;

    private CharacterController controller;
    //private BoxCollider collider;
    private PlayerInput playerInput;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraTransform;

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction runAction;
    private InputAction runEndAction;

    private Animator animator;
    int jumpAnimation;
    int runAnimation;
    int moveXAnimationParameterId;
    int moveZAnimationParameterId;
    int runXAnimationParameterId;
    int runZAnimationParameterId;

    Vector2 currentAnimationBlendVector;
    Vector2 animationVelocity;

    private void Start()
    {
        //collider = GetComponent<BoxCollider>();
        initialPlayerSpeed = playerSpeed;
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        runAction = playerInput.actions["Run"];
        //runEndAction = playerInput.actions["RunEnd"];
        // Animations
        animator = GetComponent<Animator>();
        jumpAnimation = Animator.StringToHash("jump");
        runAnimation = Animator.StringToHash("Run");
        moveXAnimationParameterId = Animator.StringToHash("MoveX");
        moveZAnimationParameterId = Animator.StringToHash("MoveZ");
        runXAnimationParameterId = Animator.StringToHash("RunX");
        runZAnimationParameterId = Animator.StringToHash("RunZ");
    }

    void Update()
    {
        //Debug.Log(runAction.ReadValueAsObject());
        groundedPlayer = controller.isGrounded;
        //groundedPlayer = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        //if (!groundedPlayer)
        //{
        //    Debug.Log("not grounded");
        //}
        
        //if (groundedPlayer)
        //{
        //    Debug.Log("grounded");
        //}
        
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = collisionFixForce;
            //Debug.Log("forcing player velocity");
        }
        Vector2 input = moveAction.ReadValue<Vector2>();
        currentAnimationBlendVector = Vector2.SmoothDamp(currentAnimationBlendVector, input, ref animationVelocity, animationSmoothTime);
        Vector3 move = new Vector3(currentAnimationBlendVector.x, 0, currentAnimationBlendVector.y);
        move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized;
        //move.y = 0f;
        if (runAction.ReadValueAsObject() != null)
        {
            // Blend run animation
            playerSpeed = playerRunSpeed;
            animator.SetTrigger("RunStart");
            animator.SetFloat(runXAnimationParameterId, currentAnimationBlendVector.x);
            animator.SetFloat(runZAnimationParameterId, currentAnimationBlendVector.y);
        }
        //else if (runEndAction.triggered)
        //{
        //    playerSpeed = initialPlayerSpeed;
        //    animator.SetTrigger("RunEnd");
        //    // Blend strafe animation
        //    animator.SetFloat(moveXAnimationParameterId, currentAnimationBlendVector.x);
        //    animator.SetFloat(moveZAnimationParameterId, currentAnimationBlendVector.y);
        //}
        if (runAction.ReadValueAsObject() == null)
        {
            // Blend strafe animation
            animator.SetTrigger("RunEnd");
            playerSpeed = initialPlayerSpeed;
            animator.SetFloat(moveXAnimationParameterId, currentAnimationBlendVector.x);
            animator.SetFloat(moveZAnimationParameterId, currentAnimationBlendVector.y);
        }
        
        controller.Move(move * Time.deltaTime * playerSpeed);
        

        // Changes the height position of the player..
        if (jumpAction.triggered && groundedPlayer)
        {
            Debug.Log("trying to jump");
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue + -collisionFixForce);
            //animator.CrossFade(jumpAnimation, animationPlayTransition);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        //Rotate towards cemra direction;

        if (Time.timeScale == 1)
        {
            Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}