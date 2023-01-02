using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;


    //exposed Enums
    public enum GameStateTypes {MainMenu, IsPlaying, IsPaused, IsExiting };


    public bool hasLoadData;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
