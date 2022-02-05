using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public  float forwardSpeed;
    public float maxSpeed;
    private int desiredLane = 1;
    public float laneDistance = 4;
    public float jumpForce;
    public float increasingSpeed = 0.1f;
    public float Gravity = -20;
    public GameObject particleJump;
    public GameObject particleWin;

    private bool isSliding = false;

    private bool isDeath = false;

    private CapsuleCollider mr;

    public bool isGrounded;




    public LayerMask groundLayer;
    public Transform groundCheck;

    public Animator animator;

    public static PlayerController instance;

    [SerializeField] private GameObject lostLifeAnimationPrefab;
    [SerializeField] private int lives = 1;

    private void awake()
    {
        instance = this;

        mr = GetComponent<CapsuleCollider>();

    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;
        if(forwardSpeed < maxSpeed)
        forwardSpeed += increasingSpeed * Time.deltaTime;

        animator.SetBool("isGameStarted", true);

        
        direction.z = forwardSpeed;

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);

        if (controller.isGrounded)
        {
           
            if (SwipeManager.swipeUp)
            {
                Jump();

            }
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;
        }

        if (SwipeManager.swipeDown && !isSliding)

        {
            StartCoroutine(Slide());

        }

        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
            FindObjectOfType<AudioManger>().PlaySound("swipeLeft");
        }
        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
            FindObjectOfType<AudioManger>().PlaySound("swipeLeft");
        }

        Vector3 targetPostion = transform.position.z * transform.forward + transform.position.y * transform.up;
        if(desiredLane == 0)
        {
            targetPostion += Vector3.left * laneDistance;

        }
        else if(desiredLane == 2)
        {
            targetPostion += Vector3.right * laneDistance;
        }
      if(transform.position != targetPostion)
        {
            Vector3 diff = targetPostion - transform.position;
            Vector3 moveDir = diff.normalized * 80 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.magnitude)
                controller.Move(moveDir);
            else
                controller.Move(diff);
            
        }

        
        controller.Move(direction * Time.deltaTime);

    }
   

    private void Jump()
    {
        direction.y = jumpForce;
        FindObjectOfType<AudioManger>().PlaySound("jump");
        GameObject ball = Instantiate(particleJump, groundCheck.position, Quaternion.identity);


    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            lives--;
            if(lives <=0)
            {
                PlayerManager.gameOver = true;
                FindObjectOfType<AudioManger>().PlaySound("GameOver");

                isDeath = true;
                animator.SetBool("isDeath", true);
            }
            else
            {
                StartCoroutine(onLostLifeWithoutLosing());
            }

        }
        
       
         
    }

    private IEnumerator onLostLifeWithoutLosing()
    {
    
        
        Time.timeScale = 0.5f;
        gameObject.layer = 9;

        GameObject lostLifeAnimationSpawned = Instantiate(lostLifeAnimationPrefab, transform.position, Quaternion.identity);
        Destroy(lostLifeAnimationSpawned, 2);

        int i = 0;
        while(i<9)
        {
            i++;
            mr.enabled = false;
            yield return new WaitForSeconds(2f);
            mr.enabled = true;
            yield return new WaitForSeconds(2f);


        }
        
        
        
       


        Time.timeScale = 1;
        gameObject.layer = 0;


    }

    public void SecondChance()
    {
        StartCoroutine(onLostLifeWithoutLosing());
    }
    
    private IEnumerator Slide()
    {
        isSliding = true;
        animator.SetBool("isSliding", true);
        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1;
        FindObjectOfType<AudioManger>().PlaySound("slide");
        
        yield return new WaitForSeconds(0.9f);
        controller.center = new Vector3(0, 0, 0);
        controller.height = 2;
        GameObject ball1 = Instantiate(particleWin, groundCheck.position, Quaternion.identity);




        animator.SetBool("isSliding", false);
        isSliding = false;
       

    }

}
