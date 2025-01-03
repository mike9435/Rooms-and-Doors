using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{

    public float furnitureHealth = 3;

    public GameObject destroyedCrate;
    public GameObject destroyedBarrel;

    public GameManager manager;

    private SpriteRenderer furnitureSprite;
    private Material defaultMaterial;
    public Material whiteMaterial;

    public AudioSource woodDamageSFXSource;
    public AudioClip woodDamageSFXClip;
    public AudioClip woodDamage2SFXClip;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("First Room Floor").GetComponent<GameManager>();

        furnitureSprite = GetComponent<SpriteRenderer>();
        defaultMaterial = furnitureSprite.material;

        woodDamageSFXSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FurnitureHit(string tag)
    {
        furnitureHealth--;
        furnitureSprite.material = whiteMaterial;
        if (furnitureHealth == 2)
        {
            woodDamageSFXSource.PlayOneShot(woodDamageSFXClip, 0.5f);
        }
        if (furnitureHealth == 1)
        {
            woodDamageSFXSource.PlayOneShot(woodDamage2SFXClip, 0.5f);
        }
        if (furnitureHealth <= 0)
        {
            manager.WoodBreakSound();
            if(tag == "Crate")
            {
                GameObject insantiatedCrate = Instantiate(destroyedCrate, transform.position, Quaternion.identity);
                insantiatedCrate.transform.rotation = transform.rotation;
            }
            else if (tag == "Barrel")
            {
                GameObject insantiatedBarrel = Instantiate(destroyedBarrel, transform.position, Quaternion.identity);
                insantiatedBarrel.transform.rotation = transform.rotation;
            }
            
            Destroy(gameObject);
        }
        else
        {
            Invoke("ResetMaterial", 0.1f);
        }
    }
    private void ResetMaterial()
    {
        furnitureSprite.material = defaultMaterial;
    }
}
