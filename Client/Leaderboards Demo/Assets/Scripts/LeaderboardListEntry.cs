using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardListEntry : MonoBehaviour
{
    public string Time { 
        set {
            transform.Find("Time").GetComponent<TextMeshProUGUI>().text = value;
        } 
    }

    public string Player { 
        set {
            transform.Find("Player").GetComponent<TextMeshProUGUI>().text = value;
        } 
    }

    public Card Card { 
        get {
            return transform.Find("Card").GetComponent<Card>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
