using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random; //do random number pick

public class CardPick : MonoBehaviour
{
    //For UI
    public Text PlayerSum;
    public Text OpponentSum;
    public GameObject PlayerStayText;
    public GameObject OpponentStayText;
    public GameObject[] PlayerHealth;
    public GameObject[] OpponentHealth;
    public GameObject ButtonAction;
    public GameObject WinUI;
    public Text WhoWinText;

    //Message
    public GameObject Message;
    public Text Message_Text;

    //For card place
    public GameObject[] Card;
    public GameObject PlayerArea;
    public GameObject OpponentArea;
    GameObject Player_PlaceCard;
    GameObject Opponent_PlaceCard;

    //situation booling
    bool PlayerSetTwo = false,
        OpponentSettTwo = false,
        PlayerStay = false,
        OpponentStay = false,
        Hit = false,
        Winning = false;

    //Player
    int Playertotal = 0,
        PlayerHP = 3;
    //Opponent
    int Opponenttotal = 0,//sum up number
        OpponentHP = 3;

    int PlayerNum, OpponentNum;

    void Start()
    {
        //set text to 0
        PlayerSum.text = Playertotal.ToString();
        OpponentSum.text = Opponenttotal.ToString();

        //AI = (AI_Player)FindObjectOfType(typeof(AI_Player));
    }

    private void Update()
    {
        if (Hit)
        {
            OppontmentPlay();
            Message.gameObject.SetActive(false);
        }

        Hit = false;
        
        HealthLose(PlayerHP, OpponentHP);

        if (Winning == true && ButtonAction.activeSelf)
            ReviveHealth();
    }

    public void ButStay()
    {
        Hit = true;
        PlayerStay = true;
        PlayerStayText.gameObject.SetActive(true);
        if (PlayerStay == true && OpponentStay == true)
            Result();

        //Reset();
    }

    //do random number
    public int RandomNumber()
    {
        int pick = Random.Range(1, 13);
        return pick;
    }

    public void ButHit2()
    {
        Hit = true;
        if (PlayerSetTwo == false)// for place two Card
        {
            for (int i = 0; i < 2; i++)
            {
                PlayerNum = RandomNumber();
                Playertotal = Playertotal + PlayerNum;
                PlayerShow(PlayerNum);
            }

            //Check if get 21 at begining
            if (Playertotal == 21)
            {
                //instance
                Debug.Log("You win");
            }
            else
                PlayerSetTwo = true;
        }
        else
        {
            //do place number
            PlayerNum = RandomNumber();
            Playertotal = Playertotal + PlayerNum;
            PlayerShow(PlayerNum);
        }

        PlayerSum.text = Playertotal.ToString();

    }

    //Card and place them
    private void PlayerShow(int num)
    {
        Player_PlaceCard = Instantiate(Card[num-1], new Vector2(0, 0), Quaternion.identity);
        Player_PlaceCard.transform.SetParent(PlayerArea.transform, false);

        //Debug.Log(max);
    }

    //clear card on table
    private void clearCard()
    {
        var max = GameObject.FindGameObjectsWithTag("Card");

        foreach(var a in max)
        {
            Destroy(a);
        }

        PlayerSetTwo = false;
        OpponentSettTwo = false;

        Playertotal = 0;
        Opponenttotal = 0;
        PlayerSum.text = "0";
        OpponentSum.text = "0";

        Hit = false;
    }

    private void OpponentShow(int num)
    {
        Opponent_PlaceCard = Instantiate(Card[num - 1], new Vector2(0, 0), Quaternion.identity);
        Opponent_PlaceCard.transform.SetParent(OpponentArea.transform, false);
    }

    private void HealthLose(int P_HP, int O_HP)
    {
        //check PlayerHealth losing
        if (P_HP == 2)
            PlayerHealth[2].gameObject.SetActive(false);
        else if (P_HP == 1)
            PlayerHealth[1].gameObject.SetActive(false);
        else if (P_HP == 0)
            PlayerHealth[0].gameObject.SetActive(false);

        //check PlayerHealth losing
        if (O_HP == 2)
            OpponentHealth[2].gameObject.SetActive(false);
        else if (O_HP == 1)
            OpponentHealth[1].gameObject.SetActive(false);
        else if (O_HP == 0)
            OpponentHealth[0].gameObject.SetActive(false);
    }

    private void ReviveHealth()
    {
        for(int i = 0; i < 3; i++)
        {
            PlayerHealth[i].gameObject.SetActive(true);
            OpponentHealth[i].gameObject.SetActive(true);
        }

        OpponentHP = 3;
        PlayerHP = 3;

        Winning = false;
    }

    private void OppontmentPlay()
    {
        if (OpponentSettTwo == false)// for place two Card
        {
            for (int i = 0; i < 2; i++)
            {
                OpponentNum = RandomNumber();
                Opponenttotal = Opponenttotal + OpponentNum;
                OpponentShow(OpponentNum);
            }

            //Check if get 21 at begining
            if (Opponenttotal == 21)
            {
                //instance
                Debug.Log("You win");
            }
            else
                OpponentSettTwo = true;
        }
        else
        {
            if (Opponenttotal < 15)
            {
                //do place number
                OpponentNum = RandomNumber();
                Opponenttotal = Opponenttotal + OpponentNum;
                OpponentShow(OpponentNum);
            }
            else
            {
                OpponentStay = true;
                OpponentStayText.gameObject.SetActive(true);
            }
        }
        


        OpponentSum.text = Opponenttotal.ToString();
    }

    private void Result()
    {
        PlayerStay = false;
        OpponentStay = false;

        PlayerStayText.gameObject.SetActive(false);
        OpponentStayText.gameObject.SetActive(false);

        if (Playertotal == Opponenttotal || (Playertotal > 21 && Opponenttotal > 21))
        {
            Message.gameObject.SetActive(true);
            Message_Text.text = "Drol";
            Debug.Log("Drol");
        }
        else if ((Playertotal <= 21 && Playertotal > Opponenttotal) || Opponenttotal > 21)
        {
            Message.gameObject.SetActive(true);
            Message_Text.text = "You win";
            Debug.Log("You win");
            OpponentHP--;
        }
        else if (Playertotal > 21 || (Playertotal < Opponenttotal && Opponenttotal <= 21))
        {
            Message.gameObject.SetActive(true);
            Message_Text.text = "You lose";
            Debug.Log("You lose");
            PlayerHP--;
        }

        //anyone lose health
        if(OpponentHP == 0 || PlayerHP == 0)
        {
            Winning = true;
            WinUI.gameObject.SetActive(true);
            ButtonAction.gameObject.SetActive(false);

            if (PlayerHP == 0)
                WhoWinText.text = "Opponent Win!";
            else if(OpponentHP == 0)
                WhoWinText.text = "Player Win!";
        }

        clearCard();

    }
}
