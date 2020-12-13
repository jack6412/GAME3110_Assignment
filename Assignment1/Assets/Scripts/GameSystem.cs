using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random; //do random number pick
public enum GameState {START, PLAYERTURN, ENEMYTURN, WON, LOST, STAY}

public class GameSystem : MonoBehaviour
{
    public GameState state;

    public GameObject hitBtn;
    public Text numText;
    public Text AInumText;
    public Text ListText;
    public Text AIListText;
    List<int> num1 = new List<int>();
    List<int> num2 = new List<int>(); 
    int max = 1;//do for check number max of list
    int max2 = 1; // ai's max list
    int numberText;
    PlayerUI playerUI;

    bool Result;
    bool didPlayerTakeDamage = false;

    void Start()
    {
        ListText.text = "0";
        numText.text = "0";
        AIListText.text = "0";
        AInumText.text = "0";
        playerUI = (PlayerUI)FindObjectOfType(typeof(PlayerUI));
        state = GameState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        hitBtn.SetActive(false);
        //Debug.Log("SETUP");
        yield return new WaitForSeconds(1f);
        state = GameState.PLAYERTURN;
        PlayerTurn();
    } 

void PlayerTurn()
{
    // During player turn, display UI
    hitBtn.SetActive(true);
}
    IEnumerator PlayerAttack()
    {
               //Do place 2 card
        if(max==1)
        {
            for(int i =0;i<2;i++)
            {
                //stor random number
                num1.Add(RandomNumber(12));
                //stroe the max number
                max++;
            }
        }
        else //already have 2 card
            //stor random number
            num1.Add(RandomNumber(12));

        //show information
        show(num1);

        //stroe the max number
        max++;
        hitBtn.SetActive(false);
        Debug.Log("PLAYERATTACK");
        bool Winner = false;
        yield return new WaitForSeconds(1f);

        if(Winner)
        {
            state = GameState.WON;
            //if player wins the round
            // do something
        }
        else
        {
            state = GameState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

    }

    private int RandomNumber(int max)
    {
        int pick = Random.Range(1, max + 1);
        return pick;
    }

    public void ButStay()
    {

    }

    private void show(List<int> num)
    {
        //clear the test to empty
        ListText.text = "";

        //show the list of stroe number
        foreach (var x in num)
            ListText.text += x.ToString() + " ";

        //show the sum up number
        numText.text = num.Take(max).Sum().ToString();//add total number
    }

        private void PlayerShow(List<int> num)
    {
        //clear the test to empty
        AIListText.text = "";

        //show the list of stroe number
        foreach (var x in num)
        AIListText.text += x.ToString() + " ";

        //show the sum up number
        AInumText.text = num.Take(max).Sum().ToString();//add total number
    }

     IEnumerator TakeDamage()
    {
        playerUI.playerPlayerHealth -= 1;
        didPlayerTakeDamage = true;
        yield return null;
    }

    void CheckPlayerPlayerHealth()
    {
        // Convert string to int
        Result = int.TryParse(numText.text, out numberText);
        //numberText = int.Parse(numText.text);

        if (numberText >= 21 && didPlayerTakeDamage == false)
        {
            num1.Clear();
            StartCoroutine(TakeDamage());
        }

        //didPlayerTakeDamage = false;
    }
    void Update()
    {
        //CheckPlayerPlayerHealth();
    }
    IEnumerator EnemyTurn()
    {
        Debug.Log("ENEMY's TURN");
        //stor random number
        num2.Add(RandomNumber(12));

        //show information
        PlayerShow(num2);

        //stroe the max number
        max2++;
        bool Winner = false;

        if(Winner)
        {
            state = GameState.LOST;
            // if enemy wins the round
            // do something
        }
        else
        {
            state = GameState.PLAYERTURN;
            PlayerTurn();
        }
        yield return null;
    }

    public void OnClickButton()
    {
        if (state != GameState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerAttack());

    }

}
