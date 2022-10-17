using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TOM.Core.SpiritualEssence
{
    public class EssenceDrop : MonoBehaviour
    {
        /**
         
         Aim is to use this to act as a placeholder for drop effects and magnet mechanic for pickups 
         
         */

        [SerializeField] private GameObject _effects;
        [SerializeField] private GameObject _spawnObject;
        private Transform _spawnFromTransfrom;
        public Transform SpawnFromTransfrom {
            get { return _spawnFromTransfrom; }
            set {_spawnFromTransfrom = value; }
        }


        public float lifetime;


        //Trying addition of spawning effects 
        [SerializeField] private GameObject _spawnParticle;
        [SerializeField] private int _spawnParticleMax;
        
        [SerializeField] private float minX, maxX, minZ, maxZ;

        // Start is called before the first frame update
        void Start()
        {
            if (_effects != null) {
                Destroy(_effects, 3f);  
                



            }





            //spawn partciles 
            for (int i = 0; i < _spawnParticleMax; i++) {
                //costly instantiation
                Vector3 spawnPos = new Vector3(
                    transform.position.x + Random.Range(minX, maxX),
                   0.5f,
                    transform.position.x + Random.Range(minZ, maxZ)

                    );
                
                var obj = Instantiate(_spawnParticle,transform);
                obj.transform.localPosition = spawnPos;

                Debug.Log("partcile spawned from " + gameObject.name +" at" + spawnPos ) ;
            }

            
        }

        public void SetSpawnFromTransform(Transform value) {
            SpawnFromTransfrom = value;
        
        }

        // Update is called once per frame
        void Update()
        {
           


        }
    }
}