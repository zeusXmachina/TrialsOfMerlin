using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory instance;

    public List<Item> inventoryStore;

    public List<InventoryBlock> allBlocks;

    public Item[] randomItems;


    //inventory settings
    [SerializeField] private bool isStackingActive;
    [SerializeField] private int inventoryMaxSpace;
    [SerializeField] private int _currencyValue;

    [SerializeField] private Item randomItem;

    //additional UI interaction settings 
    [SerializeField] private bool _isInteracting;
    [SerializeField] private Transform interactionSpawnLocation;


    public int CurrencyValue { 
        get { return _currencyValue; }
        set { _currencyValue = value; }
    }

    public bool IsInteracting { get { return _isInteracting; }set { _isInteracting = value; } }

    public void AddCurrency(int value) { CurrencyValue += value; }
    public void RemoveCurrency( int value) { CurrencyValue -= value; }

    private bool TrySpendCurrency(int cost) {
        if (cost < CurrencyValue)
        {
            return true;
        }
        else {
            Debug.Log("Insufficient fund available ");
            return false;
        }
    
    }

    public void AddItemInventory(Item item) {
        inventoryStore.Add(item);
    }

    public void RemoveItemInventory(
        Item item) {
        inventoryStore.Remove(item);
    }

    public Item FindItemInInventory(Item value)
    {
        return null;
       // foreach (Item item in inventoryStore) { 
        //find item via a key

      //  }
        
    }

    public void ValidatePurchase(int cost) {
        if (TrySpendCurrency(cost))
        {
            RemoveCurrency(cost);
            Debug.Log("Spent " + cost +" gold");
        }
        else { 
         
        }
    }



    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
            instance = this;
    }

    void Start()
    {
        inventoryStore = new List<Item>();
        IsInteracting = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("AddRandomItem")]
    public void AddRandomItem() {
      

        foreach (InventoryBlock invBlock in allBlocks) {
            if (invBlock.isEmpty) {
                /*
                invBlock.ItemStore = randomItem;
                invBlock._blockImage.sprite = randomItem.IconSprite;
                invBlock.isEmpty = false;
                AddItemInventory(randomItem);
                */
                //use instantiate from ramdom items 
                //select an item at random 
                int index = Random.Range(0, randomItems.Length - 1);
                invBlock.ItemStore = randomItems[index];
                invBlock._blockImage.sprite = randomItems[index].IconSprite;
                invBlock.isEmpty = false;
                AddItemInventory(randomItems[index]);


                break;
            }
            
        }
    
    }



    [ContextMenu("AddRandomItemWithStacking")]
    public void AddRandomItemWithStacking()
    {

        //if stack is active 
        //we need to know the item first 
        //then search invetory for this item 

        //if exists in the grid 
        //add to this item stack 
        //change icon numerals and block inventory quantity 
        //if doesnt exist add to first empty sqaure 

        int index = Random.Range(0, randomItems.Length - 1);
        // invBlock.ItemStore = randomItems[index];
        if (inventoryStore.Contains(randomItems[index]))
        {
            int storeindex = inventoryStore.IndexOf(randomItems[index]);
            Item item = inventoryStore[storeindex];

            allBlocks[item.blockIndex].StoreQuantity = allBlocks[item.blockIndex].StoreQuantity + 1;



        }
        else {
            //doesnt contain this item

            foreach (InventoryBlock invBlock in allBlocks)
            {
                if (invBlock.isEmpty)
                {

                    //use instantiate from ramdom items 
                    //select an item at random 
                    Item itemToStore = randomItems[index];
                    itemToStore.blockIndex = invBlock.BlockId;

                    invBlock.ItemStore = itemToStore;
                    invBlock._blockImage.sprite = itemToStore.IconSprite;
                    invBlock.isEmpty = false;
                    invBlock.StoreQuantity = invBlock.StoreQuantity + 1;

                    AddItemInventory(randomItems[index]);


                    break;
                }


            }

        }

        



    }

    public void InventoryClickFunction(InventoryBlock invBlock) {
        Debug.Log("Inventory Block Clicked");

        //if trigger is greater than zero
        ////trigger damp 
     

            //obj
           // var obj = allBlocks[invBlock.BlockId].GetComponent<Item>().ItemPrefab;


          //  Instantiate(obj, interactionSpawnLocation.position, interactionSpawnLocation.rotation);
           
            

       

        
    }


}
