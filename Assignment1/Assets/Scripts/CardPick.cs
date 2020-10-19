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
    public Text ListText;
    public Text Health;

    AI_Player AI;

    List<int> num1 = new List<int>();
    int max = 1,//do for check number max of list
        total = 0;//sum up number
    int numberText;
    PlayerUI playerUI;

    bool Result;
    bool didPlayerTakeDamage = false;
    void Start()
    {
        //set text to 0
        ListText.text = "0";
        numText.text = "0";
        playerUI = (PlayerUI)FindObjectOfType(typeof(PlayerUI));
    }
    public void ButHit()
    {
        //for AI term
        AI.AI_Term();

        //Do place 2 card
        if (max==1)
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

        //check sum up number over 21
        if (total > 21)
        {
            //get damage


            //show which side win

            //reset value
            //Reset();
        }
        else
            //stroe the max number
            max++;
        

    }

    public void ButStay()
    {

    }

    private int RandomNumber(int max)
    {
        int pick = Random.Range(1, max + 1);
        return pick;
    }

    private void show(List<int> num)
    {
        //clear stxt
        ListText.text = "";
        //show the list of stroe number
        foreach (var x in num)
            ListText.text += x.ToString() + " ";

        total = num.Take(max).Sum();//add total number
        //show the sum up number
        numText.text = total.ToString();
    }

    IEnumerator TakeDamage()
    {
        playerUI.playerHealth -= 1;
        didPlayerTakeDamage = true;
        yield return null;
    }
    
    void CheckPlayerHealth()
    {
        // Convert string to int
        Result = int.TryParse(numText.text, out numberText);
        //numberText = int.Parse(numText.text);

        if (numberText > 21 && didPlayerTakeDamage == false)
        {
            num1.Clear();
            StartCoroutine(TakeDamage());
        }

        //didPlayerTakeDamage = false;
    }


    void Update()
    {
        CheckPlayerHealth();
    }

    //restart value
    private void Reset()
    {
        ListText.text = "0";
        numText.text = "0";
        max = 1;
    }
}
