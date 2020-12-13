using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

    public Text PlayerHealthRemaining;
    public int playerPlayerHealth = 3;

    CardPick cardPick;

    void Start()
    {
        cardPick = (CardPick)FindObjectOfType(typeof(CardPick));
    }

    void Update()
    {
        PlayerHealthRemaining.text = "PlayerHealth: " + playerPlayerHealth;
        //cardPick.numText.text;
    }
}
