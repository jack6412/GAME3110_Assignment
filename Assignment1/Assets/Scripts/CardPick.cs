using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random; //do random number pick

public class CardPick : MonoBehaviour
{
    public Text numText;
    public Text Health;

    //For card place
    public GameObject[] Card;
    public GameObject PlayerArea;

    bool setTwo = false;

    AI_Player AI;

    int total = 0,//sum up number
        HP = 3;
    int numberText;

    void Start()
    {
        //set text to 0
        numText.text = total.ToString();
        Health.text = HP.ToString();

        AI = (AI_Player)FindObjectOfType(typeof(AI_Player));
    }


    public void ButStay()
    {
        if (total <= 21)
        {
            Debug.Log("You win");
        }
        else if (total > 21)
        {
            Debug.Log("You lose");
        }

        Reset();
    }

    public int RandomNumber()
    {
        int pick = Random.Range(1, 13);
        return pick;
    }

    //restart value
    private void Reset()
    {
        numText.text = "0";
        total = 0;
        setTwo = false;
    }

    public void ButHit2()
    {
        if (setTwo == false)
        {
            for (int i = 0; i < 2; i++)
            {
                numberText = RandomNumber();
                total = total + numberText;
                show2(numberText);
            }

            if (total == 21)
            {
                //instance
                Debug.Log("You win");
            }
            else
                setTwo = true;
        }
        else
        {
            numberText = RandomNumber();
            total = total + numberText;
            show2(numberText);
        }


        //Do place 2 card
        numText.text = total.ToString();

    }

    private void show2(int num)
    {  
        GameObject PlaceCard = Instantiate(Card[num-1], new Vector2(0, 0), Quaternion.identity);
        PlaceCard.transform.SetParent(PlayerArea.transform, false);
        

    }

    private void clearCard()
    {

    }
}
