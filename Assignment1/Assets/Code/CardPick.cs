using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random; //do random number pick

public class CardPick : MonoBehaviour
{
    public Text numText;
    //Random num = new Random();
    // Start is called before the first frame update
    public void ButHit()
    {
        RandomNumber(12);
    }

    // Update is called once per frame
    private void RandomNumber(int max)
    {
        int num = Random.Range(1, max+1);
        numText.text = num.ToString();
    }
}
