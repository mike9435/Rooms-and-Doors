using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public AudioSource fireballSFXSource;
    public AudioClip fireballSFXClip;
    public float knockback = 10;
    private float fireballAngle;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        fireballSFXSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //I could not figure out how to add inaccuracy to the firing
            //fireballAngle = Random.Range(-5, 5);
            //Quaternion accuracy = Quaternion.Euler(0,0, fireballAngle);
            Instantiate(bullet, transform.position + (transform.up), transform.rotation);
            fireballSFXSource.PlayOneShot(fireballSFXClip,0.6f);

            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            transform.up = direction;

            rb.AddForce(-direction * knockback, ForceMode2D.Impulse);
        }
    }
}
