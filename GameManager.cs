using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] roomsArray;
    public TextMeshProUGUI roomtext;
    public int highscore;
    public TextMeshProUGUI highscoretext;
    public string newhighscore;
    public int roomAmount;
    public bool isdead;
    public bool isShot;

    public AudioSource slimeDeathSFXSource;
    public AudioClip slimeDeathSFXClip;
    public AudioClip fireballImpactSFXClip;
    public AudioClip doorOpeningSFXClip;
    public AudioClip woodBreakSFXClip;
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt(newhighscore);
        highscoretext.text = "Highscore = " + highscore;

        isdead = false;

        slimeDeathSFXSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] roomsArray = GameObject.FindGameObjectsWithTag("Room");
        roomtext.text = "Room = " + roomsArray.Length;
        roomAmount = roomsArray.Length;
        
        if (roomsArray.Length > highscore)
        {
            highscore = roomsArray.Length;
            highscoretext.text = "Highscore = " + roomsArray.Length;
            PlayerPrefs.SetInt(newhighscore, highscore);
        }

        if (isdead && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void SetIsDead()
    {
        isdead = true;
    }
    public void IsShotTrue()
    {
        isShot = true;
    }

    public void SlimeDeathSound()
    {
        slimeDeathSFXSource.PlayOneShot(slimeDeathSFXClip, 0.4f);
    }

    public void FireballImpactSound()
    {
        slimeDeathSFXSource.PlayOneShot(fireballImpactSFXClip, 0.2f);
    }
    public void DoorOpeningSound()
    {
        slimeDeathSFXSource.PlayOneShot(doorOpeningSFXClip, 0.2f);
    }
    public void WoodBreakSound()
    {
        slimeDeathSFXSource.PlayOneShot(woodBreakSFXClip, 0.3f);
    }
}
