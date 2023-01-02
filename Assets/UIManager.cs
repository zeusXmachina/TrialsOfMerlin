using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;





    //Gameobjects UI Related 
    [SerializeField] private GameObject newGameButton;
    [SerializeField] private GameObject loadGameButton;




    //get setters 
    public GameObject NewGameButton { get { return newGameButton; } }
    public GameObject LoadGameButton { get { return loadGameButton; } }



    //scrolling for credits vars 
    public ScrollRect scroller;

    public float scroll;
    public float speed;

    public bool isScrolling;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject);
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        NewGameButton.SetActive(false);
        LoadGameButton.SetActive(false);
        // scroller.verticalNormalizedPosition = 0;


        isScrolling = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (isScrolling) {
            scroller.velocity = Vector2.up * speed;
            Debug.Log(scroller.verticalNormalizedPosition);
           

        }
       
        //scroller.verticalNormalizedPosition -= 1f * Time.deltaTime;

        //if (scroll != 0)
       // {
        //    float contentHeight = scroller.content.sizeDelta.y;
        //    float contentShift = speed * scroll * Time.deltaTime;
         //   scroller.verticalNormalizedPosition += contentShift / contentHeight;
       // }
    }

    public void TogglePlayButtons() {
        //if Load button is Inactive
        if (!LoadGameButton.activeSelf)
        {
            if (GameDataManager.Instance.hasLoadData)
            {
                LoadGameButton.SetActive(true);

            }
        }
        else {

            LoadGameButton.SetActive(false);
        }

        if (!NewGameButton.activeSelf)
        {
            NewGameButton.SetActive(true);
        }
        else {

            NewGameButton.SetActive(false);
        }
       
    
    }

    public void NewGameSelected() {
        Debug.Log("New Game Selected");
    }

    public void LoadGameSelected() {
        Debug.Log("Load Game Selected");
    }



}
