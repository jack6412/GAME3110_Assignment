using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random; //do random number pick



public class AI_Player : MonoBehaviour
{
    public Text numText;
    public Text ListText;
    public Text Health;

    List<int> num = new List<int>();
    int max = 1,
        total = 0,
        HP = 3;//do for check number max of list


    void Start()
    {
        //set text to 0
        ListText.text = "0";
        numText.text = "0";

        Health.text = HP.ToString();
    }

    public void AI_Term()
    {
        
        //Do place 2 card
        if (max == 1)
        {
            for (int i = 0; i < 2; i++)
            {
                //stor random number
                num.Add(RandomNumber(12));
                //stroe the max number
                max++;
            }
        }
        else //already have 2 card
            //stor random number
            num.Add(RandomNumber(12));

        //show information
        show(num);

        //check sum up number over 21
        if(total > 21)
        {
            //get damage
            HP--;

            //show which side win

            //reset value
            //Reset();
        }
        else 
        {
            //stroe the max number
            max++;
        }
        
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

    //restart value
    private void Reset()
    {
        ListText.text = "0";
        numText.text = "0";
        max = 1;
    }
}
