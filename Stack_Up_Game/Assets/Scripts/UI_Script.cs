using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  TMPro;

public class UI_Script : MonoBehaviour
{
    public static UI_Script Instance;
    public TMP_Text scoreText;
    public int score = 0;
    public int endScore;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    public void IncreaseScore(int counting)
    {
        score += counting;

        endScore = score;
    }

}
