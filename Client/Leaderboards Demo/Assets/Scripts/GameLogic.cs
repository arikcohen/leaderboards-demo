using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.CloudScriptModels;
using PlayFab.LeaderboardsModels;
using PlayFab.ProfilesModels;

using System;
using PlayFab.ClientModels;
using System.Threading.Tasks;
using EntityProfileBody = PlayFab.ProfilesModels.EntityProfileBody;
using TMPro;

public class GameLogic : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer = 0.0f;


    [SerializeField]
    public GameObject leaderboardList;

    [SerializeField]
    public List<Sprite> images;


    [SerializeField]
    public GameObject playerListLocation;
    public PlayerListEntry prefabPlayerListEntry;
    [SerializeField]
    public GameObject cardLocation;
    [SerializeField]
    public Card prefabCard;

    public GameObject GamePanel;
    public GameObject LeaderboardPanel;

    private List<Card> cardsInPlay = new List<Card>();
    private Card selectedCard;

    private string currentPlayer;
    private string currentBucket;
    private EntityTokenResponse currentEntityToken;
    private string bucket;

    const int maxCards = 9;

    private bool gameRunning = false;

    void Start()
    {
        PlayFabSettings.TitleId = "52B0";
        PlayFabAuthService.OnLoginSuccess += InitialLogin;
        PlayFabAuthService.Instance.Authenticate();
        ReloadLeaderboardData();
    }

    private void InitialLogin(LoginResult success)
    {
        SetStatus("Loading players...");
        RefreshPlayerList();
        

    }

    private void SetupBoard()
    {
        GamePanel.transform.Find("Status").GetComponent<TextMeshProUGUI>().text = "";
        // clear existing board
        foreach (Card c in cardsInPlay)
        {
            c.transform.parent = null;
            UnityEngine.Object.DestroyImmediate(c);
        }
        cardsInPlay.Clear();

        int duplicateCard = UnityEngine.Random.Range(0, images.Count);

        int randomLocation1 = UnityEngine.Random.Range(0, maxCards);
        int randomLocation2 = UnityEngine.Random.Range(0, maxCards);

        if (randomLocation2 == randomLocation1)
        {
            randomLocation2 = (randomLocation2 + 1) % maxCards;
        }

        for (int i = 0; i < maxCards; i++)
        {
            int card;
            if (i == randomLocation1 || i == randomLocation2)
                card = duplicateCard;
            else
            {
                card = getAvailableCard(duplicateCard, cardsInPlay);
            }

            Card c = Instantiate(prefabCard, cardLocation.transform);
            c.Id = card;
            c.cardImage = images[card];
            c.onClick += OnCardClicked;
            cardsInPlay.Add(c);
        }
        timer = 0f;
        gameRunning = true;
    }
    
    private void OnCardClicked(object sender, EventArgs e)
    {
        Card clicked = (Card)sender;
        if (selectedCard == null)
        {
            selectedCard = clicked;
        }
        else
        {
            if (selectedCard.Id == clicked.Id && clicked.isSelected)
            {
                MatchMade(selectedCard.Id);
            }
            else
            {
                clicked.isSelected = false;
                selectedCard.isSelected = false;
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
            if (card != duplicateCard)
            {
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


    private async void OnPlayerLoggedIn(LoginResult success)
    {


        /* PlayFabCloudScriptAPI.ExecuteFunction(new ExecuteFunctionRequest()
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
        (result) =>
        {
            bucketText.text = result.FunctionResult.ToString();
            RefreshPlayerList();
            SetupBoard();
            ReloadLeaderboardData();
        }
        , PlayFabErrorHandler
        ); */

        currentEntityToken = success.EntityToken;
        gameRunning = false;
        if (success.NewlyCreated)
        {
            await SetDisplayName(currentPlayer);
            currentBucket = await AssignBucket(currentEntityToken, currentPlayer);
            AddPlayerToList(currentPlayer, currentBucket);
            
        }
        HighlightCurrentPlayer();
        SetupBoard();
        ReloadLeaderboardData();
    }

    private void HighlightCurrentPlayer()
    {
        var players = playerListLocation.GetComponentsInChildren<PlayerListEntry>();
        foreach (PlayerListEntry entry in players)
        {
            entry.IsSelected = (entry.Name == currentPlayer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameRunning)
            timer += Time.deltaTime;
        GamePanel.transform.Find("Time").GetComponent<TextMeshProUGUI>().text = timer.ToString("0.0") + "s";
    }



    public void AddNewPlayer()
    {
        System.Random rnd = new System.Random();
        List<string> nameList = new List<string> { "Noah", "Jacob", "Mason", "Liam", "William", "Ethan", "Michael", "Alexander", "James", "Daniel", "Emma", "Sophia", "Olivia", "Isabella", "Ava", "Mia", "Emily", "Abigail", "Madison", "Elizabeth" };
        currentPlayer = nameList[rnd.Next(nameList.Count)] + " " + rnd.Next(100).ToString();
        currentBucket = "";
        PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest()
        {
            CustomId = currentPlayer,
            CreateAccount = true,
        },
            OnPlayerLoggedIn,
            PlayFabErrorHandler
        );


    }

    private void PlayerSelected(object sender, EventArgs e)
    {
        currentPlayer = ((PlayerListEntry)sender).Name;
        currentBucket = ((PlayerListEntry)sender).Bucket;
        PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest()
        {
            CustomId = currentPlayer
        },
            OnPlayerLoggedIn,
            PlayFabErrorHandler
        );
    }

    private void PlayFabErrorHandler(PlayFabError obj)
    {
        Debug.LogError(obj.GenerateErrorReport());
    }

    public async void MatchMade(int matchedCardId)
    {
        gameRunning = false;
        var result = new MatchResult()
        {
            cardIndex = matchedCardId,
            matchTime = (int)Math.Round(timer * 1000),
        };
        SetStatus("Submitting Time...");
        /*         PlayFabCloudScriptAPI.ExecuteFunction(new ExecuteFunctionRequest()
                {
                    Entity = new PlayFab.CloudScriptModels.EntityKey()
                    {
                        Type = PlayFabAuthService.Entity.Type,
                        Id = PlayFabAuthService.Entity.Id
                    },
                    FunctionName = "ReportMatchResult",
                    FunctionParameter = new MatchResult()
                    {
                        cardIndex = matchedCardId,
                        matchTime = (int)Math.Round(timer * 1000),
                    },
                    GeneratePlayStreamEvent = true
                },
                (result) => ReloadLeaderboardData(),
                (error) => Debug.LogError(error.GenerateErrorReport())
                ); */



        await ReportMatchResult(result);
        await Task.Delay(1000);
        ReloadLeaderboardData();
        SetupBoard();

    }




    private void SetStatus(string message)
    {
        GamePanel.transform.Find("Status").GetComponent<TextMeshProUGUI>().text = message;
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
            foreach (Transform playerEntry in playerListLocation.transform)
            {
                playerEntry.parent = null;
                GameObject.DestroyImmediate(playerEntry.gameObject);
            }

            if (result.Rankings != null)
            {
                foreach (EntityLeaderboardEntry ranking in result.Rankings)
                {
                    AddPlayerToList(ranking.DisplayName, ranking.Metadata);
                }
            }
            SetStatus("");
        },
        (error) =>
        {
            Debug.LogError(error.GenerateErrorReport());
        }
         );
    }

    private void AddPlayerToList(string displayName, string bucket)
    {
        Debug.Log($"Added {displayName}");
        PlayerListEntry player = Instantiate(prefabPlayerListEntry, playerListLocation.transform);
        player.transform.SetAsFirstSibling();
        player.Name = displayName;
        player.Bucket = bucket == "" ? "?" : bucket;
        player.onClick += PlayerSelected;
        player.IsSelected = player.Name == currentPlayer;
    }

    public void ReloadLeaderboardData()
    {

        for (int i = 1; i <= 5; i++)
        {
            LeaderboardListEntry le = leaderboardList.transform.Find($"Entry{i}").GetComponent<LeaderboardListEntry>();
            le.Player = "";
            le.Time = "";
            le.Card.gameObject.SetActive(false);
            le.Card.allowsSelection = false;
        }

        if (string.IsNullOrEmpty(currentBucket))
        {
            LeaderboardPanel.transform.Find("Header/Title").GetComponent<TextMeshProUGUI>().text = "Leaderboard: Bucket Unknown";
            return;
        }
        else
        {
            LeaderboardPanel.transform.Find("Header/Title").GetComponent<TextMeshProUGUI>().text = $"Leaderboard: Bucket {currentBucket}";
        }


        PlayFabLeaderboardsAPI.GetLeaderboard(
            new GetEntityLeaderboardRequest()
            {
                EntityType = "title_player_account",
                StatisticName = "TimeToFindPair",
                ChildName = currentBucket,
                MaxResults = 5
            },
        (result) =>
        {




            if (result.Rankings != null)
            {
                foreach (EntityLeaderboardEntry ranking in result.Rankings)
                {

                    LeaderboardListEntry entry = leaderboardList.transform.Find($"Entry{ranking.Rank}").GetComponent<LeaderboardListEntry>();

                    entry.Player = ranking.DisplayName;
                    float time = ranking.Score / 1000f;
                    entry.Time = $"{time.ToString("0.0")}s";
                    //entry.Card.Id = int.Parse(ranking.Metadata.Substring(ranking.Metadata.IndexOf(':') + 1));
                    entry.Card.Id = int.Parse(ranking.Metadata);
                    entry.Card.cardImage = images[entry.Card.Id];
                    entry.Card.gameObject.SetActive(true);
                }
            }

        },
        (error) =>
        {
            Debug.LogError(error.GenerateErrorReport());
        }
         );
    }

    private async Task<EntityProfileBody> GetEntityProfileRequest()
    {
        var t = new TaskCompletionSource<EntityProfileBody>();
        PlayFabProfilesAPI.GetProfile(new GetEntityProfileRequest(),
        (response) =>
        {
            t.SetResult(response.Profile);
        },
        PlayFabErrorHandler

        );
        return t.Task.Result;
    }

    private async Task<string> AssignBucket(EntityTokenResponse entityToken, string player)
    {
        SetStatus($"Assigning bucket for {player}...");
        await SetBucket(entityToken, player);

        await Task.Delay(750);
        string bucket = await UpdateBucketMetadata(entityToken);

        return bucket;
    }

    private Task<bool> SetDisplayName(string name)
    {
        var t = new TaskCompletionSource<bool>();
        PlayFabProfilesAPI.SetDisplayName(new SetDisplayNameRequest()
        {
            DisplayName = name
        },
             (response) =>
             {
                 PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest()
                 {
                     DisplayName = name
                 },
                     (displayNameResponse) => { t.SetResult(true); },
                     PlayFabErrorHandler);
             },
            PlayFabErrorHandler
            );

        return t.Task;
    }

    private Task<bool> SetBucket(EntityTokenResponse entityToken, string metadata)
    {
        var t = new TaskCompletionSource<bool>();


        PlayFabLeaderboardsAPI.UpdateStatistics(new UpdateStatisticsRequest()
        {
            EntityLeaderboardMetadata = metadata,
            Statistics = new List<PlayFab.LeaderboardsModels.StatisticUpdate>() {
                new PlayFab.LeaderboardsModels.StatisticUpdate() {
                    Name = "Bucket",
                    Value = 1
                }
            }
        },
        (response) => t.SetResult(true),
        PlayFabErrorHandler);

        return t.Task;
    }

    private Task<string> UpdateBucketMetadata(EntityTokenResponse entityToken)
    {
        var t = new TaskCompletionSource<string>();

        PlayFabLeaderboardsAPI.GetLeaderboardAroundEntity(new GetLeaderboardAroundEntityRequest()
        {
            Entity = new PlayFab.LeaderboardsModels.EntityKey()
            {
                Type = entityToken.Entity.Type,
                Id = entityToken.Entity.Id
            },
            StatisticName = "Bucket",
            Offset = 0
        },
           (result) =>
           {
               int entityRank = result.Rankings[0].Rank;
               int bucket = (entityRank-1) / 5;
               PlayFabLeaderboardsAPI.UpdateStatistics(new UpdateStatisticsRequest()
               {
                   EntityLeaderboardMetadata = currentPlayer,
                   Statistics = new List<PlayFab.LeaderboardsModels.StatisticUpdate>() {
                    new PlayFab.LeaderboardsModels.StatisticUpdate() {
                        Name = "Bucket",
                        Value = 1,
                        Metadata = bucket.ToString()
                    }
                   }
               },
               (response) => t.SetResult(bucket.ToString()),
               PlayFabErrorHandler);
           },
           PlayFabErrorHandler
           );

        return t.Task;
    }

    private async Task ReportMatchResult(MatchResult result)
    {


        if (currentBucket == "")
        {
            currentBucket = await UpdateBucketMetadata(currentEntityToken);
        }

        PlayFabLeaderboardsAPI.UpdateStatistics(new UpdateStatisticsRequest()
        {
            Statistics = new System.Collections.Generic.List<PlayFab.LeaderboardsModels.StatisticUpdate>() {
                    new PlayFab.LeaderboardsModels.StatisticUpdate() {
                        Name="TimeToFindPair",
                        ChildName = currentBucket,
                        Value= result.matchTime,
                        Metadata = result.cardIndex.ToString()
                        //Metadata = $"{currentPlayer}:{result.cardIndex}"
                    }
                }
        },
        (response) =>
        {

        },
        (error) =>
        {

            PlayFabErrorHandler(error);
        }
        );

        return;
    }

}



public class MatchResult
{
    public int matchTime;
    public int cardIndex;

}