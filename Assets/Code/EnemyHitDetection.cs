using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TOM.AIEnemies
{
    public class EnemyHitDetection : MonoBehaviour
    {

        [SerializeField] private Enemy enemy;

        [SerializeField] private bool _isDetected;
        [SerializeField] private float detectionTimer;

        [SerializeField] private MeshRenderer _meshRenderer;


        // Start is called before the first frame update
        void Start()
        {
            detectionTimer = 2f;
            _meshRenderer = gameObject.GetComponent<MeshRenderer>();
            _isDetected = false;
           enemy =  gameObject.GetComponent<Enemy>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_isDetected) {
                detectionTimer -= Time.deltaTime;
                if (detectionTimer < 0f)
                {
                    _meshRenderer.material.color = Color.black;
                    _isDetected = false;
                }
                else { 
                //do nothing
                }

            
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Cast") {
                Debug.Log("Spell Hit Enemy" + gameObject.name);
                enemy.Damage(50f);
                Destroy(other.gameObject);

                _meshRenderer.material.color = Color.red;
                _isDetected = true;

                enemy.EnemyAIState = Enemy.EnemyAIStates.Aggressive;
                //set detection and change material 
                

            }


        }

    }
}

