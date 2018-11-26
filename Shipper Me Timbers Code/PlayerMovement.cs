using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    private float speed = 10f;
    public float breakFactor = .5f;
    public Transform startingPosition;
    public Text scoreText;
    public Text livesText;
    public Text healthText;
    public static int totalEnemiesKilled;
   
    public AudioClip deathBlowSound;
    public AudioClip cannonSound;
    private AudioSource source;
    public Rigidbody rb;

    public static int playerHealth;
    public int attack = 5;
    public static int playerScore;
    public static int numberOfLives;

    
    public GameObject shot;
    public Transform shotSpawn;
    public Transform shotSpawn2;

    public float fireRate = .5f;
    private float nextFire = 0f;


    public int someNumber = 0;

    void Start() {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
        numberOfLives = 3;
        playerScore = 0;
        playerHealth = 5;
        setScoreText();
        setLivesText();
        setHealthText();
        totalEnemiesKilled=0;


    }

    // Update is called once per frame
    void Update()
    {
        setScoreText();
        setLivesText();
        setHealthText();

        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            createCannonBall();

        }

        if (Input.GetButtonDown("Fire2") && Time.time > nextFire)
        {
            createCannonBallRightSide();

        }

        if (Input.GetKeyDown("space"))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * speed * -.1f);

        }


        if (playerHealth <= 0) //if player dies reset location and then reset health to 100 and subtract a life.
        {

            { 
                someNumber = 1;
                numberOfLives--;
                source.PlayOneShot(deathBlowSound, 10F); //deathBlow explosion
                resetPlayer();
            }
            

        }

        if(totalEnemiesKilled >=18)
        {
            Debug.Log("Close enough.");
            SceneManager.LoadScene("GameOver");
        }
        //load game over scene.
        if (numberOfLives == 0)
        {
            SceneManager.LoadScene("GameOver");

        }
    }
   
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * speed); // This is to set up movement for player. 
        
    }

    
    
    //3 methods for writing providing stats in game.
    void setScoreText()
    {
        scoreText.text = "Score " + playerScore.ToString();

    }

    void setLivesText()
    {
        livesText.text = "Lives left: " + numberOfLives.ToString();
    }

    void setHealthText()
    {
        healthText.text = "Health remaining: " + playerHealth.ToString();
    }

    void resetPlayer()
    { 
        
        transform.position = new Vector3(0f, 0f, 0f);
        GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        playerHealth = 5;
        
    }
    void createCannonBall()
    {

        source.PlayOneShot(cannonSound, 5F);
        GameObject cannonInstance;
        nextFire = Time.time + fireRate;

        cannonInstance = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject; //Create cannonball for firing.
        cannonInstance.GetComponent<Rigidbody>().AddForce(shotSpawn.forward * 3000);
        
        Destroy(cannonInstance, 4);
    }

    void createCannonBallRightSide()
    {

        source.PlayOneShot(cannonSound, 5F);
        GameObject cannonInstance;
        nextFire = Time.time + fireRate;

        cannonInstance = Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation) as GameObject; //Create cannonball for firing on RIGHT side
        cannonInstance.GetComponent<Rigidbody>().AddForce(shotSpawn2.forward * 3000);

        Destroy(cannonInstance, 4);
    }

    //for collision with buoy and Enemy. 
    void OnCollisionEnter(Collision theCollision)
    {
        
        if (theCollision.gameObject.name == "buoy" || theCollision.gameObject.name == "buoy2")
        {
            
            playerHealth -= 2;//determine amount of health loss after a collision. Change back to 2 or so.
           
        }
        else if (theCollision.gameObject.name == "Big Enemy")
        {
            if (theCollision.relativeVelocity.x > 4 || theCollision.relativeVelocity.x < -4 || theCollision.relativeVelocity.z < -4 || theCollision.relativeVelocity.z > 4) ///based on if speed of collision
            {
               
                playerHealth -= 10;//set this back to 10.
                
                GetComponent<AudioSource>().volume=1;
               
                
            }
            
           
        }
    }
   




    }