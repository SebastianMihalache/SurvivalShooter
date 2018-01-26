using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;


    void Start ()
    {
        //repeats the spawn every "spawnTime" seconds
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        //does not spawn if the player is dead
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        //sets the spawn points for the enemies at random
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        //spawns the "enemy" at the random spawn position with a random spawn rotation
        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
