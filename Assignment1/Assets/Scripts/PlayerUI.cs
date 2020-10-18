using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

    public Text healthRemaining;
    public int playerHealth = 3;

    CardPick cardPick;

    void Start()
    {
        cardPick = (CardPick)FindObjectOfType(typeof(CardPick));
    }

    void Update()
    {
        healthRemaining.text = "Health: " + playerHealth;
        //cardPick.numText.text;
    }
}
