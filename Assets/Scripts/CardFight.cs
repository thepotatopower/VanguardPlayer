using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using VanguardEngine;

public class CardFight : MonoBehaviour
{
    // Start is called before the first frame update
    VanguardEngine.CardFight cardFight;
    public GameObject Field;
    public GameObject PlayerHand;
    public GameObject cardPrefab;
    public GameObject DeckZone;
    public GameObject HandCard;
    public CardBehavior cardBehavior;
    
    void Start()
    {
        GameObject newCard;
        GameObject selectedCard;
        GameObject rawImage;
        string fileName;
        InputManager inputManager = new InputManager();
        cardFight = new VanguardEngine.CardFight();
        Debug.Log(Application.dataPath + "/cards.db");
        cardFight.Initialize(Application.dataPath + "/testDeck.txt", Application.dataPath + "/testDeck.txt", inputManager, "Data Source=" + Application.dataPath + "/cards.db;Version=3;");
        List<Card> playerDeck = cardFight._player1._field.PlayerDeck;
        List<Card> enemyDeck = cardFight._player1._field.EnemyDeck;
        List<GameObject> gameCards = new List<GameObject>();
        //for (int i = 0; i < playerDeck.Count; i++)
        //{
        //    newCard = new CardBehavior.GameCard();
        //    newCard.card = GameObject.Instantiate(cardPrefab);
        //    fileName = FixFileName(playerDeck[i].id);
        //    fileName = fileName.ToLower();
        //    Texture2D LoadedImage = new Texture2D(350, 510);
        //    LoadedImage.LoadImage(File.ReadAllBytes(Application.dataPath + "/Resources/art/" + fileName));
        //    newCard.card.GetComponent<Renderer>().materials[0].mainTexture = LoadedImage;
        //    newCard.card.transform.parent = Field.transform;
        //    newCard.card.transform.Rotate(new Vector3(270, 90, 90));
        //    newCard.card.transform.localPosition = new Vector3(4.348f, (0.05f * (playerDeck.Count - i)), -2.43f);
        //}
        for (int i = 0; i < playerDeck.Count; i++)
        {
            newCard = GameObject.Instantiate(cardPrefab);
            newCard.GetComponent<CardBehavior>().PlayerHand = PlayerHand;
            newCard.GetComponent<CardBehavior>().HandCard = HandCard;
            newCard.name = playerDeck[i].tempID.ToString();
            newCard.transform.parent = DeckZone.transform;
            newCard.transform.localScale = new Vector3(1, 1, 1);
            newCard.transform.localRotation = Quaternion.Euler(0, 0, 0);
            newCard.transform.localPosition = new Vector3(0, 0, newCard.transform.localScale.z * (playerDeck.Count - i));
            gameCards.Add(newCard);
        }
        selectedCard = gameCards[0];
        gameCards.RemoveAt(0);
        gameCards[0].transform.SetParent(null);
        selectedCard.GetComponent<CardBehavior>().DrawCard(selectedCard.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string FixFileName(string input)
    {
        Debug.Log(input);
        int first = input.IndexOf('-');
        Debug.Log(first);
        string firstHalf = input.Substring(0, first);
        Debug.Log(firstHalf);
        string secondHalf = input.Substring(first + 1, input.Length - (first + 1));
        Debug.Log(secondHalf);
        int second = secondHalf.IndexOf('/');
        Debug.Log(second);
        return firstHalf + secondHalf.Substring(0, second) + "_" + secondHalf.Substring(second + 1, secondHalf.Length - (second + 1)) + ".png";
    }
}
