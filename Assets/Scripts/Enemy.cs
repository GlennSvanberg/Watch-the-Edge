using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 500.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(playerDirection * speed);

        if(transform.position.y < -10)
        {
            gameManager.UpdateScore(1);
            Destroy(gameObject);
        }

    }
}
