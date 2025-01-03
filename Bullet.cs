using System.Collections;
using System.Collections.Generic;
using UnityEditor;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 15;
    private Vector2 direction;
    //private ContactPoint2D slimeHit;

    private Enemy Enemy;
    private Furniture Furniture;

    public GameManager manager;
    public Door door;

    private float fireballAngle;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("First Room Floor").GetComponent<GameManager>();
        door = GameObject.Find("Door").GetComponent<Door>();

        fireballAngle = Random.Range(-7.5f, 7.5f);
        transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z + fireballAngle);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * bulletSpeed*Time.deltaTime);
        //direction = Vector2.up;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy = collision.gameObject.GetComponent<Enemy>();
            //I am trying to figure out how to get the contact point of the collision and make a force in that direction but I am unsure how
            //slimeHit = collision.contacts[0];
            //Enemy.EnemyHit(slimeHit.point);
            Enemy.EnemyHit();

            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Wall")
        {
            if (collision.gameObject.name == "Door" && door.currentEnemyAmount==0)
            {
                manager.IsShotTrue();
            }
            manager.FireballImpactSound();
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Crate"|| collision.gameObject.tag == "Barrel")
        {
            Furniture = collision.gameObject.GetComponent<Furniture>();
            Furniture.FurnitureHit(collision.gameObject.tag);
            Destroy(gameObject);
        }
    }
}
