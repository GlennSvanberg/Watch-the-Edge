using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public GameObject focalPoint;

    [SerializeField] float speed = 25.0f;
    [SerializeField] float powerUpStrength = 15.0f;
    [SerializeField] float jumpForce = 4.0f;

    public float verticalInput;
    bool hasPowerup = false;
    bool isOnGround = false;
    private static string verticalString = "Vertical";
    private GameManager gameManager;
    public GameObject powerupIndicator;
    private Rigidbody playerRb;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        if (gameManager.gameIsActive)
        {
            verticalInput = Input.GetAxis(verticalString);
            playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed);

            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
            }

                if (transform.position.y < -10)
            {
                gameManager.GameOver();
            }
        }
        
    }
    private void LateUpdate()
    {
        powerupIndicator.transform.position = transform.position + new Vector3(0, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());

        }
        else if (other.CompareTag("Life"))
        {


        }
        else if (other.CompareTag("Jump"))
        {


        }
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {

            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            
        } else if(collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;
        }
    }

}
