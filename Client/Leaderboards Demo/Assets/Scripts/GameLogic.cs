using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.CloudScriptModels;
using PlayFab.LeaderboardsModels;

using System;
using PlayFab.ClientModels;

public class GameLogic : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer = 0.0f;
    
    [SerializeField]
    public LeaderboardEntryPrefab prefabEntry;
    
    
    [SerializeField]
    public GameObject leaderboardList;

    [SerializeField]
    public List<Sprite> images;


    [SerializeField]
    public TMPro.TMP_Dropdown playerSelection;

    [SerializeField]
    public TMPro.TMP_Text playerText;
    
    [SerializeField]
    public TMPro.TMP_Text bucketText;

    public GameObject cardLocation;
    public Card prefabCard;

    private List<Card> cardsInPlay = new List<Card>();    
    private Card selectedCard;

    private string currentPlayer;
    private string bucket;

    const int maxCards = 9;

    void Start()
    {
        PlayFabSettings.TitleId = "52B0";
        //RefreshPlayerList();  
    }

    private void SetupBoard()
    {
        // clear existing board
        foreach (Card c in cardsInPlay) {
            UnityEngine.Object.Destroy(c);
        }

        
        int duplicateCard = UnityEngine.Random.Range(0, images.Count);

        int randomLocation1 = UnityEngine.Random.Range(0, maxCards);
        int randomLocation2 = UnityEngine.Random.Range(0, maxCards);

        if (randomLocation2 == randomLocation1)
        {
            randomLocation2 = (randomLocation2 +1) % maxCards;
        }    

        for (int i=0; i<maxCards; i++)
        {
            int card;
            if (i == randomLocation1 || i == randomLocation2)
                card = duplicateCard;
            else {
                card = getAvailableCard(duplicateCard, cardsInPlay);                                
            }

            Card c = Instantiate(prefabCard, cardLocation.transform);
            c.Id = card;
            c.cardImage = images[card];
            c.onClick += OnCardClicked;
        }
    }

    private void OnCardClicked(object sender, EventArgs e)
    {
        Card clicked = (Card) sender;
        if (selectedCard == null) {
            selectedCard = clicked;
        }
        else {
            if (selectedCard.Id == clicked.Id)
            {
                MatchMade(selectedCard.Id);
            }
            else {
                clicked.isSelected = false;
                selectedCard.isSelected =false;
                selectedCard = null;
            }
        }
    }

    private int getAvailableCard(int duplicateCard, List<Card> cardsInPlay)
    {
        int card = -1;
        bool validatedCard = false;
        
        while (!validatedCard)
        {
            card = UnityEngine.Random.Range(0, images.Count);
            if (card != duplicateCard) {
                validatedCard = true;
                for (int i = 0; i < cardsInPlay.Count; i++)
                {
                    if (card == cardsInPlay[i].Id)
                        validatedCard = false;
                }
            }
        }
        
        return card;
    }

    private void PlayerLoggedIn(LoginResult success)
    {
        PlayFabCloudScriptAPI.ExecuteFunction(new ExecuteFunctionRequest()
        {
            Entity = new PlayFab.CloudScriptModels.EntityKey()
            {
                Type = success.EntityToken.Entity.Type,
                Id = success.EntityToken.Entity.Id
            },
            FunctionName = "AssignBucket", 
            FunctionParameter = playerText.text,
            GeneratePlayStreamEvent = true
        },
        (result) => {
            bucketText.text = result.FunctionResult.ToString();
            RefreshPlayerList();
            SetupBoard();
            ReloadLeaderboardData();    
        }
        ,PlayFabErrorHandler
        ); 
        
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
    
    
    public void LoginPlayer() {    
        
        if (playerSelection.value == 0) {         
            return;
        }

        System.Random rnd = new System.Random();
        if (playerSelection.value == 1) {         
            List<string> nameList = new List<string> {"Noah", "Jacob", "Mason", "Liam", "William", "Ethan", "Michael", "Alexander", "James", "Daniel", "Emma", "Sophia", "Olivia", "Isabella", "Ava", "Mia", "Emily", "Abigail", "Madison", "Elizabeth"};
            playerText.text = nameList[rnd.Next(nameList.Count)] + " " + rnd.Next(100).ToString();
            bucketText.text = "";
            PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest()
                {
                    CustomId = playerText.text,
                    CreateAccount = true,                                    
                },
                PlayerLoggedIn,
                PlayFabErrorHandler
            );
        }
        else {
            playerText.text = playerSelection.options[playerSelection.value].text;                    
            bucketText.text = "";

            PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest()
                {
                    CustomId = playerSelection.options[playerSelection.value].text                    
                },
                PlayerLoggedIn,
                PlayFabErrorHandler
            );
        }
    }

    private void PlayFabErrorHandler(PlayFabError obj)
    {
        Debug.LogError(obj.GenerateErrorReport());
    }

    public void MatchMade(int matchedCardId)
    {
        PlayFabCloudScriptAPI.ExecuteFunction(new ExecuteFunctionRequest()
        {
            Entity = new PlayFab.CloudScriptModels.EntityKey()
            {
                Type = PlayFabAuthService.Entity.Type,
                Id = PlayFabAuthService.Entity.Id
            },
            FunctionName = "MatchMade",
            FunctionParameter = new MatchResult()
            {
                cardIndex = matchedCardId,
                matchTime = timer,
            },
            GeneratePlayStreamEvent = true
        },
        (result) => ReloadLeaderboardData(),
        (error) => Debug.LogError(error.GenerateErrorReport())
        );


        

        timer = 0f;
    }

    public void RefreshPlayerList()
    {
        PlayFabLeaderboardsAPI.GetLeaderboard(
            new GetEntityLeaderboardRequest()
            {
                EntityType = "title_player_account",
                StatisticName = "Bucket",            
                MaxResults = 100
            },
        (result) =>
        {
            List<string> players = new List<string>();
            
            foreach(EntityLeaderboardEntry ranking in result.Rankings)
            {
                if (ranking.EntityLeaderboardMetadata != null)
                    players.Add(ranking.EntityLeaderboardMetadata);
            }

            players.Sort();
            playerSelection.options.Clear();
            playerSelection.options.Add(new TMPro.TMP_Dropdown.OptionData("Select a player..."));
            playerSelection.options.Add(new TMPro.TMP_Dropdown.OptionData("Add player..."));
            players.ForEach((name) => playerSelection.options.Add(new TMPro.TMP_Dropdown.OptionData(name)));            
        },
        (error) =>
        {
            Debug.LogError(error.GenerateErrorReport());
        }
         );
    }

    public void ReloadLeaderboardData()
    {
        PlayFabLeaderboardsAPI.GetLeaderboard(
            new GetEntityLeaderboardRequest()
            {
                EntityType = "title_player_account",
                StatisticName = "TimeToFindPair",
                ChildName = bucketText.text,
                MaxResults = 5
            },
        (result) =>
        {
            

            for(int i =0; i < leaderboardList.transform.childCount; i++ )
            {
                Destroy(leaderboardList.transform.GetChild(i).gameObject);                
            }


            foreach(EntityLeaderboardEntry ranking in result.Rankings)
            {
                LeaderboardEntryPrefab entry = Instantiate(prefabEntry,leaderboardList.transform );
                prefabEntry.Rank = ranking.Rank;
                prefabEntry.DisplayName = ranking.EntityLeaderboardMetadata;
                prefabEntry.Score = ranking.Score;
            }
            
        },
        (error) =>
        {
            Debug.LogError(error.GenerateErrorReport());
        }
         );
    }


}



public class MatchResult
{
    public float matchTime;
    public int cardIndex;

}