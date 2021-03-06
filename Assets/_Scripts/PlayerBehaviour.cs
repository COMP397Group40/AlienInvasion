using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Controls")]
    public Joystick joystick;
    public float horizontalSensitivity;
    public float verticalSensitivity;

    public CharacterController controller;

    float CurrentFallTime;
    public float MaxFallTime = 3;

    bool PlayerIsFalling;

    public float maxSpeed = 10.0f;
    public float gravity = -30.0f;
    public float jumpHeight = 3.0f;

    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask groundMask;

    public Vector3 velocity;
    public bool isGrounded;

    [Range(0, 100)]
    public int health = 100;

    public HealthBarScreenSpaceController healthBar;
    public new AudioSource audio;
    [Header("MiniMap")]
    public GameObject miniMap;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame - once every 16.6666ms

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);

        if (isGrounded == false)
        {
            PlayerIsFalling = true;
            
        }
        else PlayerIsFalling = false;

        if (PlayerIsFalling)
        {
            CurrentFallTime += Time.deltaTime;
        }

        if (CurrentFallTime >= MaxFallTime)
        {
            PlayerDeath();
        }


        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }

        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");
        float x = joystick.Horizontal;
        float z = joystick.Vertical;

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * maxSpeed * Time.deltaTime);

        //if (Input.GetButton("Jump") && isGrounded)
        //{
        //    velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        //}

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (isGrounded == true && move.magnitude != 0 && audio.isPlaying == false)
        {
            audio.volume = Random.Range(0.8f, 1);
            audio.pitch = Random.Range(0.8f, 1.1f);
            audio.Play();
        }
        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    // toggle the MiniMap on/off
        //    miniMap.SetActive(!miniMap.activeInHierarchy);
        //}
    }
    void ToggleMinimap()
    {
        // toggle the MiniMap on/off
        miniMap.SetActive(!miniMap.activeInHierarchy);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.TakeDamage(damage);
        if (health < 0)
        {
            health = 0;
        }
    }
    public void OnMapButtonPressed()
    {
        ToggleMinimap();
    }
    public void PlayerDeath() {
        SceneManager.LoadScene("GameOver");
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
    void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        //jumpSound.Play();
    }
    public void OnJumpButtonPressed()
    {
        if (isGrounded)
        {
            Jump();
        }
    }
}
