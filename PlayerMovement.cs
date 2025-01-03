using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float playerSpeed = 5f;
    public float vertical;
    public float horizontal;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 playerMovement = new Vector3 (horizontal , vertical ,0).normalized;
        
        transform.position += playerSpeed * Time.deltaTime * playerMovement;
        
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x-transform.position.x, mousePosition.y-transform.position.y);
        transform.up = direction;

    }

    
}
