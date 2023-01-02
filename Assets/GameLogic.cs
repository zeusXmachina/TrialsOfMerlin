using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameLogic : MonoBehaviour
{

    public GameDataManager.GameStateTypes GameState;

    public Transform Player;

    public Transform menuPos;
    public Transform startPos;

    public GameObject MoveProvider;
    public GameObject TurnProvider;

    public AudioSource[] audioSources;


    // Start is called before the first frame update
    void Start()
    {
        GameState = GameDataManager.GameStateTypes.MainMenu;

        Player.position = menuPos.position;

        SetPlayerLocoMotion(false);

    }

    // Update is called once per frame
    void Update()
    {


        


    }


    public void StartGame() {
        GameState = GameDataManager.GameStateTypes.IsPlaying;
        SetPlayerPosition();
        SetPlayerLocoMotion(true);

        audioSources[0].Stop();
    
    }


    private void SetPlayerLocoMotion( bool value) { 
        MoveProvider.SetActive(value);
        TurnProvider.SetActive(value);
    }

    private void SetPlayerPosition() {
        Player.position = startPos.position; 
    }


}
