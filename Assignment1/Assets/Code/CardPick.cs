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

    List<int> num1 = new List<int>();
    int max = 1;//do for check number max of list
    // Start is called before the first frame update
    public void ButHit()
    {
        //stor random number
        num1.Add(RandomNumber(12));
        
        //show information
        show(num1);
        
        //stroe the max number
        max++;
    }

    // Update is called once per frame
    private int RandomNumber(int max)
    {
        int pick = Random.Range(1, max+1);
        return pick;
    }

    private void show(List<int> num)
    {
        //clear the test to empty
        ListText.text = "";

        //show the list of stroe number
        foreach(var x in num)
            ListText.text += x.ToString() + " ";

        //show the sum up number
        numText.text = num.Take(max).Sum().ToString();//add total number
    }
}
