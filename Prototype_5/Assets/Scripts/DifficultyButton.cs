using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class DifficultyButton : MonoBehaviour
{

    private Button menuButton;
    private GameManager gameManager;

    // variable to hold difficulty level
    public int difficultyLevel; 
    // Start is called before the first frame update
    void Start()
    {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(SetDifficulty);

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");
        gameManager.StartGame(difficultyLevel);
    }
}
