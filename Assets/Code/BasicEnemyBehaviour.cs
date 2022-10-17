using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TOM.Core;

namespace TOM.AIEnemies
{
    public class BasicEnemyBehaviour : MonoBehaviour
    {
        public Enemy enemy;
        public Transform target;
        public Player player;

        public float cooldown;


        //behaviour flag
        public bool HasAttacked;

        // Start is called before the first frame update
        void Start()
        {
            enemy = gameObject.GetComponent<Enemy>();
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            player = target.gameObject.GetComponent<Player>();

            HasAttacked = false;

            cooldown = 3f;
        }

        // Update is called once per frame
        void Update()
        {
            
            float distance = Vector3.Distance(target.position, transform.position);
            //Debug.Log(distance);

            if (Vector3.Distance(target.position, transform.position) < enemy.range || enemy.EnemyAIState == Enemy.EnemyAIStates.Aggressive)
            {
                BasicMove();

                if (Vector3.Distance(transform.position, target.position) < enemy.attackRange) {
                    if (!HasAttacked)
                    {
                        player.DamagePlayer(20f);
                        HasAttacked = true;
                    }
                    else {
                        cooldown -= Time.deltaTime;
                        if (cooldown < 0f) {
                            HasAttacked = false;
                            cooldown = 3f;
                        }
                    }
                    
                }

            }
            else {
                //do nothing
               
            }
        }



        public void BasicMove() {
            transform.LookAt(target);
            transform.Translate(-transform.forward * enemy.moveSpeed * Time.deltaTime);
           // var yOffset = new Vector3(transform.position.x,0.26f,transform.position.z);
          //  transform.position = yOffset;
            //control y ground level
            
        
        
        }
        //basic follow behaviour 
        



    }
}
