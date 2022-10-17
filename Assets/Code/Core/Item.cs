using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item : MonoBehaviour
{
    //Item class object to hold all item associated vars and functions 
    public enum ItemTypes {Ingredient, Equipment, Resource };

    public ItemTypes itemType;


    public bool isStored;
    //null if not stored
    public int blockIndex; 


    //reference to items icons used in UI testing this concept 
   
    public Sprite IconSprite;
    public GameObject ItemPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DepositInventory(Item item, List<Item> inventory) 
    {
        //check the item 
        inventory.Add(item);

    
    
    }

    public void WithdrawInventory(Item item, List<Item> inventory)
    {
        inventory.Remove(item);

    }

}
