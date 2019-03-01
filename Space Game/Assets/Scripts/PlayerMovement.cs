using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;

    [SerializeField] float speed;
    [SerializeField] Vector2 playerDir;
    [SerializeField] float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        RocketOn();
        //Steering();
    }

    private void RocketOn()
    {

    }

    private void Steering()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerRb.AddForce(playerDir * speed);
        }
    }
}
