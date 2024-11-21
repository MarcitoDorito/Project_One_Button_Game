using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EindSchermScript : MonoBehaviour
{
    public static EindSchermScript Instance;
    public TMP_Text eindScoreText;
    public int eindScore;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        eindScore = UI_Script.Instance.endScore;
        eindScoreText.text = "Score: " + eindScore;
    }
}
