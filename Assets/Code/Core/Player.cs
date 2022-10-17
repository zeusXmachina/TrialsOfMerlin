using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TOM.Core.SpiritualEssence;


namespace TOM.Core
{
   

    public class Player : MonoBehaviour
    {

        //player stats 
        public float health;
        public float essenceGenerated;

        //effects on stats generations
        public float essenceCost;
        public float generateMANA;

        public bool IsGeneratingEssence;

        public TextMeshProUGUI essenceTextValue;

        public float generateDelay = 10f;
        

        public void DamagePlayer(float value)
        {
            health =- value;

        }

        public void GenerateEssence(bool value) {

            if (value)
            {
                essenceGenerated += generateMANA * Time.deltaTime;
                //essenceTextValue.text = essenceGenerated.ToString();
                SpirtualEssenceManager.instance.AddEssence(Mathf.CeilToInt(essenceGenerated));
            }
            else { 
            
            }
        
        }


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            GenerateEssence(IsGeneratingEssence);
        }
    }
}

