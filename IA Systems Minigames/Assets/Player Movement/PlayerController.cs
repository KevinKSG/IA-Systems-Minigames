using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;
    private Vector3 playerInput;

    public CharacterController player;

    public float playerSpeed;
    private Vector3 movePlayer;
    public float gravity = 9.8f;
    public float fallVelocity;
    public float jumpForce;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;

    public float health = 100f;
    private float getDamageTimer;

    private PlayerPoints playerPoints;
    public FinalFlock finalFlock;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        playerPoints = GetComponent<PlayerPoints>();
        getDamageTimer = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (getDamageTimer < 0.3f)
        {
            getDamageTimer += Time.deltaTime;
            GetComponentInChildren<Renderer>().material.color = Color.red;
        }
        else
        {
            GetComponentInChildren<Renderer>().material.color = Color.white;
        }

        //Debug.Log("Vida: " + health);


        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        movePlayer = movePlayer * playerSpeed;

        player.transform.LookAt(player.transform.position + movePlayer);

        setGravity();

        playerSkills();

        player.Move(movePlayer * Time.deltaTime);

        //Debug.Log(player.velocity.magnitude);
    }

    public void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    public void playerSkills()
    {
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
        }
    }

    public void setGravity()
    {

        if (player.isGrounded)
        {
            fallVelocity = -gravity * Time.fixedDeltaTime;
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.fixedDeltaTime;
            movePlayer.y = fallVelocity;
        }
    }

    public void getDamage(float damage)
    {
        health -= damage;
        getDamageTimer = 0f;
        
    }

    public void loseGame()
    {
        playerPoints.LoseGame();
    }

    public void loseFlocking()
    {
        finalFlock.Setup(false);
    }

    public void winFlocking()
    {
        finalFlock.Setup(true);
    }
}
