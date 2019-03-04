using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoving : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] GameObject player;
    PlayerMovement playerMoveScript;
    [SerializeField] float cos;
    [SerializeField] float sin;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerMoveScript = player.GetComponent<PlayerMovement>();
        cos = playerMoveScript.curCos;
        sin = playerMoveScript.curSin;

        speed = 7f;

        StartCoroutine(BulletDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = new Vector2(transform.position.x + cos, transform.position.y + sin);
        transform.position = Vector2.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
    }

    IEnumerator BulletDestroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
