using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInfo : MonoBehaviour
{
    public string input;
    public Text number;

    // Start is called before the first frame update
    void Start()
    {
        number.text = input;
    }


}
