using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float enemySpeed = 3;
    private float enemyDirection;
    public bool canRotate;
    public float obstacleRange = 1f;
    public float enemyHealth = 3;

    public GameManager manager;
    public GameObject slimeSplatter;

    public AudioSource slimeDamageSFXSource;
    public AudioClip slimeDamageSFXClip;

    private Rigidbody2D rb;
    public float knockback = 15;

    private SpriteRenderer slimeSprite;
    private Material defaultMaterial;
    public Material whiteMaterial;
    public GameObject slimeExplosion;

    // Start is called before the first frame update
    void Start()
    {
        canRotate = true;

        manager = GameObject.Find("First Room Floor").GetComponent<GameManager>();

        rb = GetComponent<Rigidbody2D>();

        slimeSprite = GetComponent<SpriteRenderer>();
        defaultMaterial = slimeSprite.material;

        slimeDamageSFXSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * enemySpeed);
        Debug.DrawRay(transform.position +transform.right*0.75f, transform.right *2, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.right * 0.75f, transform.right * 2);
        
            if (hit.collider != null)
            {
                
                GameObject hitObject = hit.transform.gameObject;
                //Debug.Log("raycast hit: "+hitObject.name+" distance : "+hit.distance);
                
                if ((hitObject.tag == "Wall" || hitObject.tag == "Trap") && hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0,0, angle);
                    //Debug.Log("rotate");
                }
                else if(canRotate) {
                    StartCoroutine(RandomRotation());
                }
            }
    }

    IEnumerator RandomRotation()
    {
        canRotate = false;
        enemyDirection = Random.Range(0, 360);
        transform.Rotate(0, 0, enemyDirection);

        yield return new WaitForSeconds(3);
        canRotate = true;
    }

    public void EnemyHit()
    {
        enemyHealth--;
        //rb.AddForce(hitDirection * knockback, ForceMode2D.Impulse);
        slimeSprite.material = whiteMaterial;
        slimeDamageSFXSource.PlayOneShot(slimeDamageSFXClip, 0.5f);
        if (enemyHealth <= 0)
        {
            manager.SlimeDeathSound();
            Instantiate(slimeSplatter, transform.position, Quaternion.identity);
            Instantiate(slimeExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            Invoke("ResetMaterial", 0.1f);
        }
    }
    private void ResetMaterial()
    {
        slimeSprite.material = defaultMaterial;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Trap")
        {
            manager.SlimeDeathSound();
            Instantiate(slimeSplatter, transform.position, Quaternion.identity);
            Instantiate(slimeExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
}
