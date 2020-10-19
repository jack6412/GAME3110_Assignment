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
        total = 0,//sum up number
        HP = 3;
    int numberText;

    void Start()
    {
        //set text to 0
        ListText.text = "0";
        numText.text = total.ToString();
        Health.text = HP.ToString();

        AI = (AI_Player)FindObjectOfType(typeof(AI_Player));
    }
    public void ButHit()
    {
        //for AI term
        //AI.AI_Term();
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

            total = num1.Take(max).Sum();//add total number
        if(total<21)
        {

            //show information
            show(num1);
            //stroe the max number
            max++;
        }
        else
        {
            //get damage
            HP--;

            //show information
            show(num1);
            //show which side win

            //reset value
            //Reset();
        }

    }

    public void ButStay()
    {
        Reset();
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

        //show the sum up number
        numText.text = total.ToString();

        Health.text = HP.ToString();
    }

    //restart value
    private void Reset()
    {
        ListText.text = "0";
        numText.text = "0";
        total = 0;
        num1.Clear();
        max = 1;
    }
}
