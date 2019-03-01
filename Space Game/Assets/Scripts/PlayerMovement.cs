using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;

    [SerializeField] float speed;
    [SerializeField] float horizontal;
    [SerializeField] float vertical;
    [SerializeField] float angle;
    [SerializeField] Vector2 dir;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();

        speed = 100f;

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        angle = transform.eulerAngles.z;

        DirectionFunction();
        Steering(horizontal);
    }

    private void FixedUpdate()
    {
        RocketOn(dir);

    }

    private void RocketOn(Vector2 dir)
    {
        if (Input.GetKey(KeyCode.W))
        {

            playerRb.AddForce(dir * speed * Time.fixedDeltaTime);
        }
    }

    private void Steering(float horizontal)
    {
        transform.Rotate(0f, 0f, -horizontal * 5f);
    }

    void DirectionFunction()
    {
        float curSin = 0;
        float curCos = 0;



        if (angle > 90 && 270 > angle)
        {
            curSin = Mathf.Sin(transform.rotation.z);
            curCos = Mathf.Cos(transform.rotation.z) * -1;

            Debug.Log("Facing Left");

        } else
        {
            curSin = Mathf.Sin(transform.rotation.z);
            curCos = Mathf.Cos(transform.rotation.z);
        }

        Debug.Log(curCos + " " + curSin);

        dir = new Vector2(curCos, curSin);
    }
}
