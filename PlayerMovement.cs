using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float climbSpeed;
    public bool isJumping=false;
    public bool isClimbing;
    public float jumpForce;
    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask colisionLayer;
    public Rigidbody2D rb;
    public CapsuleCollider2D playerColider;
    private Vector3 velocity = Vector3.zero;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private float horizontalMovement;
    private float verticalMovement;
    public static PlayerMovement instance;
    public float JumpPressedRememberTime=0.2f;
    public float JumpPressedRemember = 0f;
    public AudioClip jumpSFX;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("there is more thann one instance of PlayerMovement in the scene");
            return;
        }

        instance = this;
    }
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Time.timeScale = 0.5f;

        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Time.timeScale = 2f;

        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || (Input.GetKeyUp(KeyCode.LeftControl)))
        {
            Time.timeScale = 1f;
        }
        JumpPressedRemember -= Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            JumpPressedRemember = JumpPressedRememberTime;
        }
        if (Input.GetButtonUp("Jump"))
        {
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.65f);
            }
        }
        horizontalMovement = Input.GetAxis("Horizontal")*moveSpeed*Time.fixedDeltaTime;
        verticalMovement = Input.GetAxis("Vertical")*climbSpeed*Time.fixedDeltaTime;
        if ( (JumpPressedRemember>0) && isGrounded && !isClimbing)
        {
            isJumping = true;
        }
        Flip(rb.velocity.x);
        float characterVelocity=Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed",characterVelocity);
        
        animator.SetBool("isJumping",!this.isGrounded);
        animator.SetBool("IsClimbing", isClimbing);
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, colisionLayer); 
        MovePlayer(horizontalMovement,verticalMovement);
    }


    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        if (!isClimbing)
        {
            rb.gravityScale = 1;
            Vector3 targetVelocity = new Vector2(_horizontalMovement,rb.velocity.y);
            rb.velocity=Vector3.SmoothDamp(rb.velocity,targetVelocity,ref velocity,0.05f);
            if(isJumping)
            {
                //rb.AddForce(new Vector2(0f,jumpForce));
                AudioManager.instance.PlayClipAt(jumpSFX, transform.position);
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                JumpPressedRemember = 0;
                isJumping=false;
            }
        }
        else
        {
            //vertical movement
            rb.gravityScale = 0; //deactivate gravity
            Vector3 targetVelocity = new Vector2(0,_verticalMovement);
            rb.velocity=Vector3.SmoothDamp(rb.velocity,targetVelocity,ref velocity,0.05f);
        }
    }
    void Flip(float _velocity)
    {
        if(_velocity > 0.1f)
        {
            spriteRenderer.flipX=false;
        }else if(_velocity < -0.1f)
        {
            spriteRenderer.flipX=true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
