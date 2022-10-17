using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TOM.AIEnemies;

public class Spawner : MonoBehaviour
{

    public Transform spawnPoint;
    public GameObject spawnable;
    public int max;

    public float xBoundsMax;
    public float zBoundsMax;
    public float zBoundsMin;
    public float xBoundsMin;




    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < max; i++) {

            float modifier = Random.Range(0.8f, 1.6f);
            /*
            Vector3 location = new Vector3(
               transform.position.x + Random.Range(xBoundsMin, xBoundsMax),
                modifier/2,
                transform.position.z + Random.Range(zBoundsMin, zBoundsMax)
                ) ;
            */
            Vector3 location = new Vector3(
              transform.position.x + Random.Range(xBoundsMin, xBoundsMax),
               0.5f,
               transform.position.z + Random.Range(zBoundsMin, zBoundsMax)
               ) ;
            var enemySpawn = Instantiate(spawnable, location, Quaternion.identity);

            //create a modifier 
           
           // enemySpawn.transform.localScale = new Vector3(modifier, modifier, modifier);
            //get enemy stats 
            Enemy enemy = enemySpawn.GetComponent<Enemy>();
            enemy.health *= modifier;
        
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }





}
