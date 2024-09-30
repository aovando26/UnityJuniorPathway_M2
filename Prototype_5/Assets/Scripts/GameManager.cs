using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    private float spawnRate = 3.0f; 

    // ui variables
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTargets());

        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnTargets()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int indexCount = Random.Range(0, targets.Count);
            Instantiate(targets[indexCount]);   /*, transform.position, targets[indexCount].transform.rotation);*/
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }
}