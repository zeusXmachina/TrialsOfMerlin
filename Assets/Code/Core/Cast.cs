using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cast : MonoBehaviour
{
    //used on a spell whilst in cast mode 

    public float timeToCast;
    public float speed;
    public float lifeTime;
    public bool isCast;

    public Color color;


    public Transform initDirection;

    // Start is called before the first frame update
    void Start()
    {
       // isCast = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (isCast) {
            lifeTime -= Time.deltaTime;
            ProjectileMove();
        }


    }



    public void ProjectileMove() {

        if (lifeTime > 0f)
        {

           
            //this.transform.rotation = initDirection.rotation;
           //accuracy fault - this move obj forward when is cast is true destroys on lifespan
            //this.transform.Translate(transform.forward * speed * Time.deltaTime);
        }
        else {
            Destroy(gameObject);
        
        }


        
    
    
    }

    public void StreamMove()
    {



    }


}
