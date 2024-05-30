using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTextTMP;
    public TextMeshProUGUI liveTextTMP;

    private int score = 0;
    public int Score => score;

    private int live = 5;
    public int Live => live;
    // Start is called before the first frame update
    void Start()
    {
        scoreTextTMP.text = "Score: " + score.ToString();
        liveTextTMP.text = "Live: " + live.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void increaseScore(int amount)
    {
        score += amount;
        scoreTextTMP.text = "Score: " + score.ToString();

        // You can add UI update logic here if you have a UI element to display the score
    }

    public void changeLive(int amount)
    {
        live += amount;
        liveTextTMP.text = "Live: " + live.ToString();
    } 
}
