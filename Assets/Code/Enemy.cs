using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TOM.Core.SpiritualEssence;


namespace TOM.AIEnemies
{

    public class Enemy : MonoBehaviour
    {
        public enum EnemyTypes { Walk, Fly };
        public enum EnemyAIStates { Patrol, Passive, Aggressive, Dying };


        public EnemyTypes enemyType;
        public EnemyAIStates EnemyAIState;

        [Header("EnemyStats")]
        public float moveSpeed;
        public float range;
        public float attackRange;
        public float health;
        


        [Header("Enemy Flags")]
        public bool isAlive;
        public bool isAttacking;


        [Header("Enemy Prefabs")]
        public GameObject enemyDeadPrefab;

        public void Attack() { }

        public void Damage(float value) {
            health -= value;
        
        }

        public void Death() {
            if (health < 0f)
            {
                isAlive = false;
                Vector3 spawnPosition = new Vector3(
                    transform.position.x,
                    0.025f,
                    transform.position.z
                    );

                if (enemyDeadPrefab)
                {
                    Instantiate(enemyDeadPrefab, spawnPosition, transform.rotation);
                }
                else {
                    return;
                }
                
                GameObject essenceDrop = SpirtualEssenceManager.instance.DropEssence(gameObject.transform);
                essenceDrop.GetComponent<EssenceDrop>().SetSpawnFromTransform(gameObject.transform);
                Destroy(gameObject);

            }
        }

       


        // Start is called before the first frame update
        void Start()
        {
            isAlive = true;
            health = 100f;
            EnemyAIState = EnemyAIStates.Passive;
           
        }

        // Update is called once per frame
        void Update()
        {

            Death();

        }





    }
}
