using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

    public int health;
    public TextMeshProUGUI healthtext;
    public GameObject youdiedtext;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    

    private bool invulnerable = false;

    public AudioSource spikeTrapSFXSource;
    public AudioClip spikeTrapSFXClip;

    //private float force = 3;

    public GameObject player;
    Renderer ren;

    public GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        
        health = 3;
        healthtext.text = "Health = "+health;

        player = GameObject.Find("Player");
        ren = player.GetComponent<Renderer>();
        //Color blue = new Color(0, 0.2f, 1.0f);
        //ren.material.color = blue;

        manager= GameObject.Find("First Room Floor").GetComponent<GameManager>();

        spikeTrapSFXSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && invulnerable == false)
        {
            TakeDamage();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trap" && invulnerable == false)
        {
            spikeTrapSFXSource.PlayOneShot(spikeTrapSFXClip, 0.5f);
            TakeDamage();
        }
        if (collision.gameObject.tag == "Lava" && invulnerable == false)
        {
            TakeDamage();
        }
    }

    IEnumerator InvinicibilityTimer()
    {
        Color lightblue = new Color(0, 0.7f, 1.0f);
        ren.material.color = lightblue;
        yield return new WaitForSeconds(1);
        //Color blue = new Color(0, 0.2f, 1.0f);
        //ren.material.color = blue;
        Color white = new Color(1, 1, 1);
        ren.material.color = white;
        invulnerable = false;
    }

    public void TakeDamage()
    {
        invulnerable = true;
        health--;
        healthtext.text = "Health = " + health;
        if (health == 2)
        {
            heart3.SetActive(false);
        }
        else if (health == 1)
        {
            heart2.SetActive(false);
        }
        else if (health <= 0)
        {
            heart1.SetActive(false);
            manager.SetIsDead();
            
            youdiedtext.SetActive(true);
            Destroy(gameObject);
        }

        StartCoroutine(InvinicibilityTimer());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //This just keeps pushing the player in the same direction forever
        /*if (collision.gameObject.tag == "Enemy")
        {
            Vector2 PlayerPosition = new Vector2(transform.position.x, transform.position.y);
            Vector2 dir = collision.contacts[0].point - PlayerPosition;
            dir=-dir.normalized;
            GetComponent<Rigidbody2D>().AddForce(dir*force);
        }
        */
    }
}
