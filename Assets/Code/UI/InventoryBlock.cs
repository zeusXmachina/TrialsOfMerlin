using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBlock : MonoBehaviour
{
    /*
     This is a block that makes up the grid. 
    each block must have an id 
    is block empty?
    if empty can be assigned to
    
    change the block icon 
     */

    //Heavy load of resources 
    //costly?



    [SerializeField] private int _blockId;
    [SerializeField] private Item _ItemStored;
    [SerializeField] private int _storeQuantity;


    public bool isEmpty;
    public Image _blockImage;

    public int BlockId { get { return _blockId; } set { _blockId = value; } }
    public Item ItemStore { get { return _ItemStored; } set { _ItemStored = value; } }

    public int StoreQuantity { get { return _storeQuantity; } set { _storeQuantity = value;  } }


    public void BroadcastBlockID(int i) {
        Debug.Log("Broadcasting from " + BlockId);
    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
