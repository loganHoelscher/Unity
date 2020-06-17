using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{

    public Text PlayerHealth;
    public Text GameOver;
    public Text timerText;
    public Text lvlClear;
    public Text finScore;

    public GameObject bottle;
    public GameObject laser;
    public GameObject player;

    public Camera playerCam;
    public Camera mainCam;

    private int damage = 20;
    private int bossDamage = 34;
    private string health;
    private float startHealth = 100.0f;
    private float bottleHealth = 50.0f;
    private float updatedHealth;
    public float startTime;
    private string score;
    private float bonusScore = 1000.0f;

    public string level;



    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        player = GameObject.FindWithTag("Player");
        updatedHealth = startHealth;
        PlayerHealth.text = "HEALTH: " + 100 + " / " + "100";

        startTime = 120.0f;

        GameOver.GetComponent<Text>().enabled = false;
        lvlClear.GetComponent<Text>().enabled = false;
        finScore.GetComponent<Text>().enabled = false;
        playerCam.enabled = true;
        mainCam.enabled = false;

        level = SceneManager.GetActiveScene().name;

        if (level == "levelone")
        {
            level = "leveltwo";
        }
        else if (level == "leveltwo")
        {
            level = "levelthree";
        }
        else if (level == "levelthree")
        {
            level = "BOSS";
        }
        else if (level == "BOSS")
        {
            level = "end";
        }


    }

    // Update is called once per frame
    void Update()
    {

        if (updatedHealth <= 0)
        {
            GameOver.GetComponent<Text>().enabled = true;
            finScore.GetComponent<Text>().enabled = true;
            finScore.text = "SCORE: " + score;
            lvlClear.GetComponent<Text>().enabled = false;
            Time.timeScale = 0;
            playerCam.enabled = false;
            mainCam.enabled = true;
           

        }

        float t = startTime - Time.time;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");
        timerText.text = minutes + ":" + seconds;

        if (minutes == "0" && seconds == "0")
        {
            GameOver.GetComponent<Text>().enabled = true;
            finScore.GetComponent<Text>().enabled = true;
            finScore.text = "SCORE: " + score;
            lvlClear.GetComponent<Text>().enabled = false;
            Time.timeScale = 0;
            playerCam.enabled = false;
            mainCam.enabled = true;

        }

        if (GameObject.FindWithTag("Finish") == null)
        {
            
            Time.timeScale = 0;
        
            lvlClear.GetComponent<Text>().enabled = true;



            if(level == "levelone")
            {
                SceneManager.LoadScene("levelone");
            }
                
            else if (level == "leveltwo")
            {
                SceneManager.LoadScene("leveltwo");
            }
            else if (level == "levelthree")
            {
                SceneManager.LoadScene("levelthree");
            }
            else if (level == "BOSS")
            {
                SceneManager.LoadScene("BOSS");
            }
            else if (level == "end")
            {
                Time.timeScale = 0;
                finScore.GetComponent<Text>().enabled = true;
                finScore.text = "SCORE: " + score;
                lvlClear.GetComponent<Text>().enabled = true;
            }

        }

        score = ((float)updatedHealth + t + bonusScore).ToString("f0");


    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "laser(Clone)")
        {
            updatedHealth = updatedHealth - damage;
            health = ((float)updatedHealth).ToString("f2");
            PlayerHealth.text = "HEALTH: " + health + " / " + "100";
        }
        if (collision.gameObject.name == "beer")
        {
            updatedHealth = updatedHealth + bottleHealth;
            if (updatedHealth > 100)
            {
                updatedHealth = 100;
                PlayerHealth.text = "HEALTH: " + health + " / " + "100";
            }
            health = ((float)updatedHealth).ToString("f2");
            PlayerHealth.text = "HEALTH: " + health + " / " + "100";
            Destroy(bottle);
        }
        if (collision.gameObject.name == "megaLaser(Clone)")
        {
            updatedHealth = updatedHealth - bossDamage;
            health = ((float)updatedHealth).ToString("f2");
            PlayerHealth.text = "HEALTH: " + health + " / " + "100";
        }

    }

}
