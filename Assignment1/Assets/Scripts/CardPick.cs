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
    public GameObject[] Health;

    //For card place
    public GameObject[] Card;
    public GameObject PlayerArea;
    GameObject PlaceCard;

    bool setTwo = false;

    AI_Player AI;

    int total = 0,//sum up number
        HP = 3;
    int numberText;

    void Start()
    {
        //set text to 0
        numText.text = total.ToString();

        AI = (AI_Player)FindObjectOfType(typeof(AI_Player));
    }

    private void Update()
    {
        //check health losing
        if (HP == 2)
            Health[2].gameObject.SetActive(false);
        else if(HP == 1)
            Health[1].gameObject.SetActive(false);
        else if(HP==0)
            Health[0].gameObject.SetActive(false);
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
            HP -= 1;
        }

        Reset();
    }

    //do random number
    public int RandomNumber()
    {
        int pick = Random.Range(1, 13);
        return pick;
    }

    //restart value
    private void Reset()
    {
        clearCard();
        numText.text = "0";
        total = 0;
        setTwo = false;
    }

    public void ButHit2()
    {

        if (setTwo == false)// for place two Card
        {
            for (int i = 0; i < 2; i++)
            {
                numberText = RandomNumber();
                total = total + numberText;
                show2(numberText);
            }

            //Check if get 21 at begining
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
            //do place number
            numberText = RandomNumber();
            total = total + numberText;
            show2(numberText);
        }

        
        numText.text = total.ToString();

    }

    //Card and place them
    private void show2(int num)
    {  
        PlaceCard = Instantiate(Card[num-1], new Vector2(0, 0), Quaternion.identity);
        PlaceCard.transform.SetParent(PlayerArea.transform, false);

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
    }
}
