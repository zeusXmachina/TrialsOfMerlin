using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PropogateOrbs : MonoBehaviour
{
    public Orb[] orbs;

    public void OnValidate()
    {
        for (int i = 0; i < orbs.Length; i++)
        {
            float h = Random.Range(50f, 100f);
            float s = Random.Range(0.5f, 10f);
            SetupOrb(orbs[i], h, s);


        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //orbs = GameObject.FindObjectsOfType<Orb>();


        for (int i = 0; i< orbs.Length; i++) {
            float h = Random.Range(50f, 100f);
            float s = Random.Range(0.5f, 10f);
            SetupOrb(orbs[i],h,s );
        
        
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupOrb(Orb orb, float health, float strength) {
        orb.SetHealth(health);
        orb.SetStrength(strength);
        Debug.Log("Orb Updated " + "H:" + health + " S:" + strength);

        //setup orb UI 
        orb.HealthUI.text = Mathf.Round(orb.Health).ToString();
       

    
    }



}
