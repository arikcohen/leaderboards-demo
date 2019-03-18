using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class LeaderboardEntryPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int _rank;
    public int Rank {
        get {
            return _rank;
        }
        set {
            _rank = value;
            transform.Find("Rank").GetComponent<TextMeshProUGUI>().text = _rank.ToString();
        }
    }

    private string _displayName;
    public string DisplayName
    {
        get { return _displayName;}
        set { _displayName = value;
            transform.Find("DisplayName").GetComponent<TextMeshProUGUI>().text = DisplayName;
        }
    }

    private int _score;
    public int Score {
        get { return _score; }
        set {
            _score = value;
            TimeSpan timeScore = TimeSpan.FromMilliseconds((double) Score);
            transform.Find("Score").GetComponent<TextMeshProUGUI>().text = string.Format("{0:N2}", timeScore.TotalSeconds);
        }
    }
    
}
