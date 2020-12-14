using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserProfile : MonoBehaviour
{

    public TMP_Text winsLabel;
    public TMP_Text lostLabel;
    public TMP_Text totalMatchesLabel;
    public TMP_Text XPLabel;
    public TMP_Text levelLabel;
    public TMP_Text winLossPercentage;

    public float wins;
    public float lost;
    public float playerXP;
    public float playerLevel = 1;
    public float totalMatches;
    public float winLoss;
    // Start is called before the first frame update
    void Start()
    {
        wins = GlobalControl.Instance.wins;
        lost = GlobalControl.Instance.lost;
        playerXP = GlobalControl.Instance.xp;
        playerLevel = GlobalControl.Instance.level;
    }

    // Update is called once per frame
    void Update()
    {
        UILabels();
        SaveUserProfile();
        calculatetotalMatches();
        calculateWinLoss();
    }

    void UILabels()
    {
        winsLabel.text = "Wins: " + wins;
        lostLabel.text = "Lost: " + lost;
        XPLabel.text = "XP: " + playerXP + "/5";
        totalMatchesLabel.text = "Total Matches: " + totalMatches;
        winLossPercentage.text = "Win/Lost " + winLoss + "%";
        levelLabel.text = "Level: " + playerLevel;
    }

    public void SaveUserProfile()
    {
        GlobalControl.Instance.wins = wins;
        GlobalControl.Instance.lost = lost;
        GlobalControl.Instance.xp = playerXP;
        GlobalControl.Instance.level = playerLevel;
    }

    void calculatetotalMatches()
    {
        totalMatches = wins + lost;
    }

    void calculateWinLoss()
    {
        winLoss = (Mathf.Round(wins / totalMatches * 100));
    }
}

