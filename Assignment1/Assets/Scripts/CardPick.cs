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

    //For card place
    public GameObject Card;
    public GameObject PlayerArea;

    bool setTwo = false;


    AI_Player AI;

    int total = 0,//sum up number
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

    private void Update()
    {
        if(total>21)
        {

            Debug.Log("Triger");
        }
    }

    public void ButStay()
    {
        Reset();
    }

    public int RandomNumber(int max)
    {
        int pick = Random.Range(1, max + 1);
        return pick;
    }

    //restart value
    private void Reset()
    {
        ListText.text = "0";
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
                numberText = RandomNumber(12);
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
            if (total < 21)
            {
                numberText = RandomNumber(12);
                total = total + numberText;
                show2(numberText);
            }
        }
        

        //Do place 2 card

        numText.text = total.ToString();

    }

    public void show2(int num)
    {  
        GameObject PlaceCard = Instantiate(Card, new Vector2(0, 0), Quaternion.identity);
        PlaceCard.transform.SetParent(PlayerArea.transform, false);
        //GetComponent<Card>().Number.text = num.ToString();
    }
}
