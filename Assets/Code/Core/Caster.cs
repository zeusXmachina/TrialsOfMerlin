using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TOM.Core.SpiritualEssence;

public class Caster : MonoBehaviour
{
    public enum CastStates {Start,Fail, End};
    public enum SpellTypes {Red, Green, Blue, Pink, Purple};
    public GameObject[] spellOrbs;
    public int spellIndex;
    public GameObject spellOrb;
    public bool isCasting;

    //Trigger controller vars 
    public bool isTriggered;
    public bool hasTriggered;

    //addition of toggle clamp similar to hand presence 
    public bool isToggled;
    public bool toggleClamp;



    public Transform Direction;
    public Transform Rotation;

    public float forceAmount;

    public Cast currentCast;

    //helps to control incrementing the type enum 
    public int maxSpellTypes = 5;
    public Image spellTypeUI;
    public SpellTypes spellType;

    
    

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        currentCast = null;
        if (spellOrbs.Length > 0) {
            spellIndex = 0;
            spellOrb = spellOrbs[spellIndex];
        
        }

        toggleClamp = false;

        spellType = SpellTypes.Red;

    }


    private void Update()
    {
        if (isTriggered && !isCasting && currentCast == null) {

            if (!hasTriggered)
            {
                //this could be accuracy fault
                Instantiate(spellOrb, Direction.position, Direction.rotation).GetComponent<Rigidbody>().AddForce(Direction.forward * forceAmount,ForceMode.Acceleration);
                // GameObject cast = Instantiate(spellOrb, Direction.position,Direction.rotation).GetComponent<Rigidbody>().AddForce(Direction.forward));
                // currentCast = cast.GetComponent<Cast>();
                //cast.transform.SetParent(null);
                //setup cast object
                // currentCast.timeToCast = 5f;
                // currentCast.speed = 10f;
                // currentCast.lifeTime = 1f;

                //this could be accuracy fault
                // currentCast.isCast = true;

                //  currentCast = null;

                //here goes the code for spell costing
                SpirtualEssenceManager.instance.SubtractEssence(2000);


                hasTriggered = true;

                Debug.Log("spell created");
            }


        } else if (isTriggered && isCasting && currentCast != null ) {
            currentCast.isCast = true;
            currentCast = null;
        }




        if (isToggled && !toggleClamp)
        {
            toggleClamp = true;



            if (spellType > SpellTypes.Purple)
            {
                spellType = SpellTypes.Red;

            }
            else {
                spellType++;
            }
          
           
            
            
            //spell starts at zero
            //toggle +1 
            //2 spell orbs.length = 2
            if (spellIndex < spellOrbs.Length - 1)
            {
                spellIndex++;
                spellOrb = spellOrbs[spellIndex];
                spellTypeUI.color = Color.red;
            }
            else if (spellIndex == spellOrbs.Length - 1)
            {
                spellIndex = 0;
                spellOrb = spellOrbs[spellIndex];
                spellTypeUI.color = Color.green;



            }


        }




    }

    /*
    // Update is called once per frame
    void Update()
    {

        
        //ctreae a new spell
        if (isCasting && currentCast == null)
        {
            GameObject cast = Instantiate(spellOrb, this.transform);
            currentCast = cast.GetComponent<Cast>();

            //setup cast object
            currentCast.timeToCast = 5f;
            currentCast.speed = 1f;
            currentCast.lifeTime = 5f;





            Debug.Log("spell created");
            //if we stop cast and have an active spell
        } else if (!isCasting && currentCast) {


            currentCast.isCast = false;

            Destroy(currentCast.gameObject);
            currentCast = null;
            

            Debug.Log("spell failed");


        }
        else if (currentCast) {
            currentCast.timeToCast -= Time.deltaTime;

            if (!isCasting) {
                if (currentCast.isCast)
                {
                    //do nothing
                }
                else {
                    Destroy(currentCast.gameObject);
                    currentCast = null;
                    isCasting = false;

                    Debug.Log("spell failed");
                }


            }
            /*
            if (currentCast.timeToCast < 0f || !isCasting || isToggled) {
                //fail cast

                

                Destroy(currentCast.gameObject);
                currentCast = null;
                isCasting = false;

                Debug.Log("spell failed");

            }
        */
    /*
        }

        if (isToggled){
            if (spellIndex < spellOrbs.Length)
            {
                spellIndex++;
                spellOrb = spellOrbs[spellIndex];
            }
            else if (spellIndex == spellOrbs.Length) { 
                spellIndex = 0;
                spellOrb = spellOrbs[spellIndex];
            }
            
        
        }

        if (isTriggered && currentCast) {
            currentCast.isCast = true;
            currentCast = null;
        
        }




    }

   */



}
