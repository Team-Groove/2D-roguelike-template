using UnityEngine;

public enum States { idle, running, attacking, guarding, hurt, pistolup };
public class PlayerController : MonoBehaviour
{

    public float horizontal_speed;
    public float vertical_speed;
    
    private Rigidbody2D rigidBody = null;
    private SpriteRenderer spriteRenderer = null;
    private Animator animator = null;
    
    private Vector2 controls;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D> ();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        RunningInput();
        FlipSprite();

        if (controls.x != 0)
        {
            animator.SetBool("IsWalkingSides", true);
        }
        else if (controls.x == 0)
        {
            animator.SetBool("IsWalkingSides", false);
        }

        if (controls.y < -0.01f && controls.x == 0)
        {
            animator.SetBool("IsWalkingDown", true);
        }
        else if (controls.y > 0.01f && controls.x == 0)
        {
            animator.SetBool("IsWalkingUp", true);
        }

        if (controls.y == 0)
        {
            animator.SetBool("IsWalkingDown", false);
            animator.SetBool("IsWalkingUp", false);
        }
    
    }

    private void FixedUpdate()
    {    
        PhysicsMovement();      
    }
    
    private void PhysicsMovement()
    {

        rigidBody.velocity = new Vector2(controls.x * horizontal_speed, controls.y * vertical_speed);
            
    }
    private void FlipSprite()
    {
        
        if (controls.x < 0)
        {
            spriteRenderer.transform.localRotation = new Quaternion(0.0f, 180f, 0.0f, 0.0f);
        }
        else if (controls.x > 0)
        {
            spriteRenderer.transform.localRotation = new Quaternion(0.0f, 0f, 0.0f, 0.0f);
        }
        
    }
    
    private void RunningInput()
    {
      
        controls = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
    }


}
