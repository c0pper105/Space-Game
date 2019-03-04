using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingFunction : MonoBehaviour
{
    public GameObject bullet = null;

    [SerializeField] Vector2 spawnPoint;


    [SerializeField] GameObject player;
    PlayerMovement playerMoveScript;
    [SerializeField] float cos;
    [SerializeField] float sin;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerMoveScript = player.GetComponent<PlayerMovement>();

        StartCoroutine(SpawnBullet());
    }

    private void Update()
    {
        cos = playerMoveScript.curCos;
        sin = playerMoveScript.curSin;

        spawnPoint = new Vector2(transform.position.x + cos * 0.8f, transform.position.y + sin * 0.8f);
    }

    IEnumerator SpawnBullet()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(0.3f);
            GameObject bul = Instantiate(bullet, spawnPoint, Quaternion.identity);
        }
    }
}
