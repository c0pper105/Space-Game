using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingFunction : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] float attackRate;
    [SerializeField] float nextAttack;
    [SerializeField] float timer;
    [SerializeField] float dir;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        attackRate = 3f;
        nextAttack = 0f;

        
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.time;
        dir = player.transform.eulerAngles.z;

        ContinouslyShooting();
    }

    IEnumerator SpawnBullet()
    {
            yield return new WaitForSeconds(3f);
            GameObject bullet = Instantiate(gameObject, player.transform.position, Quaternion.identity);
    }

    void ContinouslyShooting()
    {
        if (nextAttack <= timer)
        {
            StartCoroutine(SpawnBullet());

            nextAttack += attackRate;
        }
    }
}
