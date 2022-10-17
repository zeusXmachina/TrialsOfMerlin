using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class OrbStatsUIToggle : MonoBehaviour
{
    [SerializeField] private GameObject _UIScreen;
    [SerializeField] private Orb orb;

    [SerializeField] private TextMeshPro text;


    public void ToggleStats(GameObject uiScreen, bool value) 
    {
        switch (value) {
            case true:
                uiScreen.SetActive(value);
                break;
            case false:
                uiScreen.SetActive(value);
                break;
        
        }
        
    }

   

   
 

    // Start is called before the first frame update
    void Start()
    {
       // _UIScreen.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
