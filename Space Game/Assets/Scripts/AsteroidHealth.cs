using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHealth : MonoBehaviour
{
    public int health;
    public int points;

    public GameObject bullet;
    [SerializeField] BulletMoving bulScript;
    [SerializeField] int damage;

    // Start is called before the first frame update
    void Start()
    {
        bulScript = bullet.GetComponent<BulletMoving>();
        damage = bulScript.bulletPower;

        TypeOfAsteroid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TypeOfAsteroid()
    {
        if (gameObject.name == "Asteroid 1")
        {
            health = 10;
            points = 1;

        } else if (gameObject.name == "Asteroid 2")
        {
            health = 15;
            points = 3;

        } else if (gameObject.name == "Asteroid 3")
        {
            health = 20;
            points = 5;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Bullet(Clone)")
        {
            health -= damage;
            Debug.Log(health);
        }
    }
}
