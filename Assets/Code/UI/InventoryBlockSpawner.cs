using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBlockSpawner : MonoBehaviour
{

    //create an empty placeholder for the main UI grid, 
    //effect should be hghlightable 
    //build on top of this grid for items icons etc 

    //grid settings 
    public int cols;
    public int rows;

    public int totalBlocks;


    public GameObject blockPrefab;
    public Transform blockParent;

   

    // Start is called before the first frame update
    void Start()
    {
        totalBlocks = cols * rows;

        for (int i = 0; i < totalBlocks; i++)
        {

            GameObject obj =  Instantiate(blockPrefab,blockParent);
            InventoryBlock invBlock = obj.GetComponent<InventoryBlock>();
            invBlock.name = "Block " + i;
            invBlock.BlockId = i;
            invBlock.isEmpty = true;

           //  obj.GetComponent<Button>().onClick.AddListener(() => Inventory.instance.InventoryClickFunction(invBlock));
           // obj.GetComponent<Button>().onClick.AddListener(Inventory.instance.InventoryClickFunction(invBlock.BlockId));

            Inventory.instance.allBlocks.Add(invBlock);
        }




    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    

}
