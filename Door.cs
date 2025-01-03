using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
    private GameObject player;
    private float distance;

    public GameObject[] enemyArray;
    public int currentEnemyAmount;

    public GameObject roomPrefab;
    private Vector3 roomPrefabLocation;

    public GameObject enemyPrefab;
    public GameObject slimelv2Prefab;
    private Vector3 enemyPrefabLocation;
    private int enemyAmount;

    public GameObject trapPrefab;
    private Vector3 trapPrefabLocation;
    private int trapAmount;

    public GameObject cratePrefab;
    private Vector3 cratePrefabLocation;
    private int crateAmount;
    public GameObject barrelPrefab;
    private Vector3 barrelPrefabLocation;
    private int barrelAmount;

    public GameManager manager;
    public int roomAmount;

    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");

        manager = GameObject.Find("First Room Floor").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        GameObject[] enemyArray = GameObject.FindGameObjects("Enemy");
        currentEnemyAmount = enemyArray.Length;
        roomAmount = manager.roomAmount;
        distance = Vector2.Distance(player.transform.position, transform.position);

        if ((Mathf.Abs(distance) < 3 && (Input.GetKeyDown(KeyCode.E)) || manager.isShot == true) && enemyArray.Length==0)
        {
            /* Level 1 (<5 rooms): 1-3 enemies & 0-2 crates & 0-2 barrels
             * Level 2 (5-9 rooms): 1-3 enemies & 0-1 traps & 0-2 crates & 0-2 barrels
             * Level 3 (10-19 rooms): 1-5 enemies & 0-2 traps & 0-3 crates & 0-3 barrels
             * Level 4 (20-29 rooms): 1-7 enemies & 0-3 traps & 1-4 crates & 1-4 barrels
             * Level 5 (30-39 rooms): 1-9 enemies & 1-3 traps & 1-5 crates & 1-5 barrels
             * Level 6 (40-49 rooms): 4-12 enemies & 2-3 traps & 2-5 crates & 2-5 barrels
             * Level 7 (50> rooms): 8-15 red enemies & 3-4 traps & 3-6 crates & 3-6 barrels
            */
            //Level 1
            if ( roomAmount <= 4)
            {
                roomPrefabLocation = transform.position + new Vector3(0, 7.5f, 0);
                Instantiate(roomPrefab, roomPrefabLocation, Quaternion.identity);

                enemyAmount = Random.Range(1, 4);
                //trapAmount = Random.Range(0, 3);
                crateAmount = Random.Range(0, 3);
                barrelAmount = Random.Range(0, 3);
                for (int i = 0; i < enemyAmount; i++)
                {
                    enemyPrefabLocation = transform.position + new Vector3(Random.Range(-7f, 7f), Random.Range(1, 15), 0);
                    Instantiate(enemyPrefab, enemyPrefabLocation, Quaternion.identity);
                }
                /*for (int i = 0; i < trapAmount; i++)
                {
                    trapPrefabLocation = transform.position + new Vector3(Random.Range(-5.5f, 5.5f), Random.Range(3, 12), 0);
                    Instantiate(trapPrefab, trapPrefabLocation, Quaternion.identity);
                }
                */
                for (int i = 0; i < crateAmount; i++)
                {
                    cratePrefabLocation = transform.position + new Vector3(Random.Range(-7f, 7f), Random.Range(1, 15), 0);
                    Instantiate(cratePrefab, cratePrefabLocation, Quaternion.identity);
                }
                for (int i = 0; i < barrelAmount; i++)
                {
                    barrelPrefabLocation = transform.position + new Vector3(Random.Range(-7f, 7f), Random.Range(1, 15), 0);
                    Instantiate(barrelPrefab, barrelPrefabLocation, Quaternion.identity);
                }
                if(Mathf.Abs(distance) < 3 && Input.GetKeyDown(KeyCode.E))
                {
                    manager.DoorOpeningSound();
                }
                if(manager.isShot == true)
                {
                    manager.WoodBreakSound();
                    
                }
                manager.isShot = false;
                Destroy(gameObject);
            }

            //Level 2
            if ( roomAmount > 4 && roomAmount <=9)
            {
                roomPrefabLocation = transform.position + new Vector3(0, 7.5f, 0);
                Instantiate(roomPrefab, roomPrefabLocation, Quaternion.identity);

                enemyAmount = Random.Range(1, 4);
                trapAmount = Random.Range(0, 2);
                crateAmount = Random.Range(0, 3);
                barrelAmount = Random.Range(0, 3);
                for (int i = 0; i < enemyAmount; i++)
                {
                    enemyPrefabLocation = transform.position + new Vector3(Random.Range(-7f, 7f), Random.Range(1, 15), 0);
                    Instantiate(enemyPrefab, enemyPrefabLocation, Quaternion.identity);
                }
                for (int i = 0; i < trapAmount; i++)
                {
                    trapPrefabLocation = transform.position + new Vector3(Random.Range(-5.5f, 5.5f), Random.Range(5, 10), 0);
                    Instantiate(trapPrefab, trapPrefabLocation, Quaternion.identity);
                }
                for (int i = 0; i < crateAmount; i++)
                {
                    cratePrefabLocation = transform.position + new Vector3(Random.Range(-7f, 7f), Random.Range(1, 15), 0);
                    Instantiate(cratePrefab, cratePrefabLocation, Quaternion.identity);
                }
                for (int i = 0; i < barrelAmount; i++)
                {
                    barrelPrefabLocation = transform.position + new Vector3(Random.Range(-7f, 7f), Random.Range(1, 15), 0);
                    Instantiate(barrelPrefab, barrelPrefabLocation, Quaternion.identity);
                }
                if (Mathf.Abs(distance) < 3 && Input.GetKeyDown(KeyCode.E))
                {
                    manager.DoorOpeningSound();
                }
                if (manager.isShot == true)
                {
                    manager.WoodBreakSound();

                }
                manager.isShot = false;
                Destroy(gameObject);
            }

            //Level 3
            if ( roomAmount > 9 && roomAmount <= 19)
            {
                roomPrefabLocation = transform.position + new Vector3(0, 7.5f, 0);
                Instantiate(roomPrefab, roomPrefabLocation, Quaternion.identity);

                enemyAmount = Random.Range(1, 6);
                trapAmount = Random.Range(0, 3);
                crateAmount = Random.Range(0, 4);
                barrelAmount = Random.Range(0, 4);
                for (int i = 0; i < enemyAmount; i++)
                {
                    enemyPrefabLocation = transform.position + new Vector3(Random.Range(-7f, 7f), Random.Range(1, 15), 0);
                    Instantiate(enemyPrefab, enemyPrefabLocation, Quaternion.identity);
                }
                for (int i = 0; i < trapAmount; i++)
                {
                    trapPrefabLocation = transform.position + new Vector3(Random.Range(-5.5f, 5.5f), Random.Range(5, 10), 0);
                    Instantiate(trapPrefab, trapPrefabLocation, Quaternion.identity);
                }
                for (int i = 0; i < crateAmount; i++)
                {
                    cratePrefabLocation = transform.position + new Vector3(Random.Range(-7f, 7f), Random.Range(1, 15), 0);
                    Instantiate(cratePrefab, cratePrefabLocation, Quaternion.identity);
                }
                for (int i = 0; i < barrelAmount; i++)
                {
                    barrelPrefabLocation = transform.position + new Vector3(Random.Range(-7f, 7f), Random.Range(1, 15), 0);
                    Instantiate(barrelPrefab, barrelPrefabLocation, Quaternion.identity);
                }
                if (Mathf.Abs(distance) < 3 && Input.GetKeyDown(KeyCode.E))
                {
                    manager.DoorOpeningSound();
                }
                if (manager.isShot == true)
                {
                    manager.WoodBreakSound();

                }
                manager.isShot = false;
                Destroy(gameObject);
            }

            //Level 4
            if (roomAmount > 19 && roomAmount <= 29)
            {
                roomPrefabLocation = transform.position + new Vector3(0, 7.5f, 0);
                Instantiate(roomPrefab, roomPrefabLocation, Quaternion.identity);

                enemyAmount = Random.Range(1, 8);
                trapAmount = Random.Range(0, 4);
                crateAmount = Random.Range(1, 5);
                barrelAmount = Random.Range(1, 5);
                for (int i = 0; i < enemyAmount; i++)
                {
                    enemyPrefabLocation = transform.position + new Vector3(Random.Range(-7f, 7f), Random.Range(1, 15), 0);
                    Instantiate(enemyPrefab, enemyPrefabLocation, Quaternion.identity);
                }
                for (int i = 0; i < trapAmount; i++)
                {
                    trapPrefabLocation = transform.position + new Vector3(Random.Range(-5.5f, 5.5f), Random.Range(5, 10), 0);
                    Instantiate(trapPrefab, trapPrefabLocation, Quaternion.identity);
                }
                for (int i = 0; i < crateAmount; i++)
                {
                    cratePrefabLocation = transform.position + new Vector3(Random.Range(-7f, 7f), Random.Range(1, 15), 0);
                    Instantiate(cratePrefab, cratePrefabLocation, Quaternion.identity);
                }
                for (int i = 0; i < barrelAmount; i++)
                {
                    barrelPrefabLocation = transform.position + new Vector3(Random.Range(-7f, 7f), Random.Range(1, 15), 0);
                    Instantiate(barrelPrefab, barrelPrefabLocation, Quaternion.identity);
                }
                if (Mathf.Abs(distance) < 3 && Input.GetKeyDown(KeyCode.E))
                {
                    manager.DoorOpeningSound();
                }
                if (manager.isShot == true)
                {
                    manager.WoodBreakSound();

                }
                manager.isShot = false;
                Destroy(gameObject);
            }

            //Level 5
            if (roomAmount > 29 && roomAmount <= 39)
            {
                roomPrefabLocation = transform.position + new Vector3(0, 7.5f, 0);
                Instantiate(roomPrefab, roomPrefabLocation, Quaternion.identity);

                enemyAmount = Random.Range(1, 10);
                trapAmount = Random.Range(0, 4);
                crateAmount = Random.Range(1, 6);
                barrelAmount = Random.Range(1, 6);
                for (int i = 0; i < enemyAmount; i++)
                {
                    enemyPrefabLocation = transform.position + new Vector3(Random.Range(-7f, 7f), Random.Range(1, 15), 0);
                    Instantiate(enemyPrefab, enemyPrefabLocation, Quaternion.identity);
                }
                for (int i = 0; i < trapAmount; i++)
                {
                    trapPrefabLocation = transform.position + new Vector3(Random.Range(-5.5f, 5.5f), Random.Range(5, 10), 0);
                    Instantiate(trapPrefab, trapPrefabLocation, Quaternion.identity);
                }
                for (int i = 0; i < crateAmount; i++)
                {
                    cratePrefabLocation = transform.position + new Vector3(Random.Range(-7f, 7f), Random.Range(1, 15), 0);
                    Instantiate(cratePrefab, cratePrefabLocation, Quaternion.identity);
                }
                for (int i = 0; i < barrelAmount; i++)
                {
                    barrelPrefabLocation = transform.position + new Vector3(Random.Range(-7f, 7f), Random.Range(1, 15), 0);
                    Instantiate(barrelPrefab, barrelPrefabLocation, Quaternion.identity);
                }
                if (Mathf.Abs(distance) < 3 && Input.GetKeyDown(KeyCode.E))
                {
                    manager.DoorOpeningSound();
                }
                if (manager.isShot == true)
                {
                    manager.WoodBreakSound();

                }
                manager.isShot = false;
                Destroy(gameObject);
            }

            //Level 6
            if (roomAmount > 39 && roomAmount <= 49)
            {
                roomPrefabLocation = transform.position + new Vector3(0, 7.5f, 0);
                Instantiate(roomPrefab, roomPrefabLocation, Quaternion.identity);

                enemyAmount = Random.Range(4, 13);
                trapAmount = Random.Range(0, 4);
                crateAmount = Random.Range(2, 6);
                barrelAmount = Random.Range(2, 6);
                for (int i = 0; i < enemyAmount; i++)
                {
                    enemyPrefabLocation = transform.position + new Vector3(Random.Range(-7f, 7f), Random.Range(1, 15), 0);
                    Instantiate(enemyPrefab, enemyPrefabLocation, Quaternion.identity);
                }
                for (int i = 0; i < trapAmount; i++)
                {
                    trapPrefabLocation = transform.position + new Vector3(Random.Range(-5.5f, 5.5f), Random.Range(5, 10), 0);
                    Instantiate(trapPrefab, trapPrefabLocation, Quaternion.identity);
                }
                for (int i = 0; i < crateAmount; i++)
                {
                    cratePrefabLocation = transform.position + new Vector3(Random.Range(-7f, 7f), Random.Range(1, 15), 0);
                    Instantiate(cratePrefab, cratePrefabLocation, Quaternion.identity);
                }
                for (int i = 0; i < barrelAmount; i++)
                {
                    barrelPrefabLocation = transform.position + new Vector3(Random.Range(-7f, 7f), Random.Range(1, 15), 0);
                    Instantiate(barrelPrefab, barrelPrefabLocation, Quaternion.identity);
                }
                if (Mathf.Abs(distance) < 3 && Input.GetKeyDown(KeyCode.E))
                {
                    manager.DoorOpeningSound();
                }
                if (manager.isShot == true)
                {
                    manager.WoodBreakSound();

                }
                manager.isShot = false;
                Destroy(gameObject);
            }

            //Level 7 (HARD MODE)
            if ( roomAmount > 49)
            {
                roomPrefabLocation = transform.position + new Vector3(0, 7.5f, 0);
                Instantiate(roomPrefab, roomPrefabLocation, Quaternion.identity);

                enemyAmount = Random.Range(8, 16);
                trapAmount = Random.Range(0, 4);
                crateAmount = Random.Range(3, 7);
                barrelAmount = Random.Range(3, 7);
                for (int i = 0; i < enemyAmount; i++)
                {
                    enemyPrefabLocation = transform.position + new Vector3(Random.Range(-7f, 7f), Random.Range(1, 15), 0);
                    Instantiate(slimelv2Prefab, enemyPrefabLocation, Quaternion.identity);
                }
                for (int i = 0; i < trapAmount; i++)
                {
                    trapPrefabLocation = transform.position + new Vector3(Random.Range(-5.5f, 5.5f), Random.Range(5, 10), 0);
                    Instantiate(trapPrefab, trapPrefabLocation, Quaternion.identity);
                }
                for (int i = 0; i < crateAmount; i++)
                {
                    cratePrefabLocation = transform.position + new Vector3(Random.Range(-7f, 7f), Random.Range(1, 15), 0);
                    Instantiate(cratePrefab, cratePrefabLocation, Quaternion.identity);
                }
                for (int i = 0; i < barrelAmount; i++)
                {
                    barrelPrefabLocation = transform.position + new Vector3(Random.Range(-7f, 7f), Random.Range(1, 15), 0);
                    Instantiate(barrelPrefab, barrelPrefabLocation, Quaternion.identity);
                }
                if (Mathf.Abs(distance) < 3 && Input.GetKeyDown(KeyCode.E))
                {
                    manager.DoorOpeningSound();
                }
                if (manager.isShot == true)
                {
                    manager.WoodBreakSound();

                }
                manager.isShot = false;
                Destroy(gameObject);
            }
        }
    }
    
}
