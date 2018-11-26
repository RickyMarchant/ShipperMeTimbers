using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballCollision : MonoBehaviour
{

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnCollisionEnter(Collision theCollision)
    {

        
        if (theCollision.gameObject.name == "Player")
        {
                PlayerMovement.playerHealth -= 2;//determine amount of health loss after a collision.
        }

        if (theCollision.gameObject.name == "Tower")
            {

                Enemy.enemy_health -= 2;//determine amount of health loss after a collision.
                Debug.Log(Enemy.enemy_health);
                Debug.Log("Enemy health is : " + Enemy.enemy_health);
                if(Enemy.enemy_health<=0)
            {
                PlayerMovement.playerScore += 300;
                PlayerMovement.totalEnemiesKilled++;
                DestroyObject(theCollision.gameObject );
                
            }

                PlayerMovement.playerScore += 50;


            }
        if (theCollision.gameObject.name == "Big Enemy")
        {

            Enemy.enemy_health -= 2;//determine amount of health loss after a collision.
            Debug.Log(Enemy.enemy_health);
            Debug.Log("Enemy health is : " + Enemy.enemy_health);
            if (Enemy.enemy_health <= 0)
            {
                DestroyObject(theCollision.gameObject);
                PlayerMovement.totalEnemiesKilled++;

            }

            PlayerMovement.playerScore += 50;


        }



    }
}
    

       
    

