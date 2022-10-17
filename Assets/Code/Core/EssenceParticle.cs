using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TOM.Core.SpiritualEssence
{
    public class EssenceParticle : MonoBehaviour
    {
        /*Links to drop essence particle effects and AI associated with particles 
         partciles should travel towards the character 
        distance check
         character collect 
         essence manager updates 

         sound 

        optimise with object pooling later on 

         */


        [SerializeField]private Transform _target;
        public float speed;

        public float rotSpeed;
        //public AudioSource audioSource;

        // Start is called before the first frame update
        void Start()
        {
            //high cost call
            _target = GameObject.FindGameObjectWithTag("Player").transform;
            transform.LookAt(_target.position);
        }

        // Update is called once per frame
        void Update()
        {
            ParticleMove();

        }

        public void ParticleMove()
        {
            //move particle
            transform.LookAt(_target.position);
            
            transform.Translate(-transform.forward * speed * Time.deltaTime);

            //costly AI
            if (Vector3.Distance(transform.position, _target.position) < 3f) 
            {
                SpirtualEssenceManager.instance.AddEssence(200);

                Debug.Log("Particle Collected");
              // audioSource.Play();
               Destroy(gameObject, 2f);
            
            }


        }





    }
}




