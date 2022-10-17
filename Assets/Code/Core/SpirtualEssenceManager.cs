using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace TOM.Core.SpiritualEssence
{
    public class SpirtualEssenceManager : MonoBehaviour
    {
        //

        //singleton padding
        // public SpirtualEssenceManager Instance;
        private int _amount;
        public static SpirtualEssenceManager instance;
        // public int Amount = _amount;


        public GameObject essenceDropPrefab;

       public TextMeshProUGUI essenceValueText;

      
        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
                instance = this;
        }

        public void AddEssence(int value)
        {
            _amount += value;
            essenceValueText.text = _amount.ToString();

        }
        public void SubtractEssence(int value)
        {
             _amount -= value;
            essenceValueText.text = _amount.ToString();

        }

        public GameObject DropEssence(Transform spawnFromTransfrom) {

            GameObject obj = Instantiate(essenceDropPrefab, spawnFromTransfrom.position, spawnFromTransfrom.rotation );
                return obj;
        
        }

       


    }
}
