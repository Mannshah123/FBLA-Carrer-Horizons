using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private bool gameStarted = false;
    private bool npcFinished = false;

    private int roundNumber = 0;
    private int totalNpcTreated = 0;

    public RandomSymptoms randomSymptoms;

    public CraftingSorterScript craftingSorterScript;
    public GameObject winPanel;
    
    private bool isNPCtreated = false;

    public bool isAvailable = false;
    public bool gameEnded = false;

    private bool timerStarted = false;

    public TimerScript timerScript;
    void Start()
    {
        
    }

   
    void Update()
    {
        if(roundNumber < 3){
            if(gameStarted && npcFinished){
                NextRound();
                npcFinished = false;
                gameStarted = false;
            }else if(npcFinished && isAvailable){
                NextRound();
                npcFinished = false;
                isAvailable = false;
            }
        }
            if(gameEnded){
                Debug.Log("Game Ended 2");
                 timerScript.CompleteLevel();
            }
           
        

        if(isNPCtreated){
            craftingSorterScript.ClearInventory();
            isNPCtreated = false;
        }

        if(gameStarted && !timerStarted){
            timerScript.StartTimer();
            timerStarted = true;
        }
    }

    public void GameStarted(){
        gameStarted = true;
    }

    public void NPCFinished(){
        npcFinished = true;
        totalNpcTreated += 1;
    }

    public void NextRound(){
        randomSymptoms.CreateNPC();
        roundNumber += 1;
    }

    public int GetRoundNumber(){
        return roundNumber;
    }

    public int GetNPCTreated(){
        return totalNpcTreated;
    }

    public void NPCTreated(bool treated){
        isNPCtreated = treated;
    }

    public void isAvailableSet(bool available){
        isAvailable = available;
    }

    public void EndGame(){
        gameEnded = true;
    }
}
