using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public static int enemy_health;
    public static int enemy_attack;


    void Start()
    {

        //assign a random amount of health and attack
        enemy_health = Random.Range(8, 10);
        //Debug.Log(enemy_health);
        enemy_attack = Random.Range(2, 4);
    }

    void Update()
    {
        
    }
    //When enemy is 'attacked' by the player
    void OnCollisionEnter(Collision theCollision)
    {

        if (theCollision.gameObject.name == "Boat")
        {

            enemy_health -= 2;//determine amount of health loss after a collision.
            //Debug.Log(enemy_health);
            Debug.Log("Enemy health is : " + enemy_health);
            if (enemy_health <= 0)
            {
               Destroy(gameObject);
                PlayerMovement.totalEnemiesKilled++;
                PlayerMovement.playerScore += 300;
            }

            PlayerMovement.playerScore += 50;


        }
    }
}