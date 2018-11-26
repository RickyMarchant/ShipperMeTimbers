using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigShipEnemy : Enemy {
    
    
    public float speedOfBigShip = 8f;
    protected float rotationSpeed = .5f;
    public Transform target;
    private GameObject wayPoint;
    private Vector3 wayPointPos;


    public AudioClip deathBlowSound;
    public AudioClip cannonSound;
    public AudioSource source;
    

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate = 3f;
    public float nextFire = 0f;

    protected float distanceToPlayer;

    void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        source = GetComponent<AudioSource>();
        
    }
	
	// Update is called once per frame
	void Update () {
        
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), rotationSpeed*Time.deltaTime);
        transform.position += transform.forward *6f* speedOfBigShip*Time.deltaTime;

        distanceToPlayer = Vector3.Distance(transform.position, target.position);
       
        if (distanceToPlayer <=18 && Time.time > nextFire)
        {
            createCannonBall();
            

        }
    }

    protected void createCannonBall()
    {
        source.PlayOneShot(cannonSound, 5F);
        GameObject cannonInstance;
        nextFire = Time.time + fireRate;

        cannonInstance = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject; //Create cannonball for firing.
        cannonInstance.GetComponent<Rigidbody>().AddForce(shotSpawn.forward * 3000);
        

        Destroy(cannonInstance, 4);
    }


    
}
