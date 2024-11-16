using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public BlockMovement blockMovement;
    public const float BLOCK_SIZE = 7.0f;

    public GameObject[] theTower;

    public int towerIndex;

    public int scoreCount = 0;
    // Start is called before the first frame update
    private void Start()
    {
        theTower = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            theTower[i] = transform.GetChild(i).gameObject;
        }
        towerIndex = transform.childCount -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (placeBlock())
            {
            intatiateBlock();
            scoreCount++;   
            Debug.Log(scoreCount);
            }
            else
            {
                EndGame();
            }
            blockMovement.moveBlock();
        }
    }
    private void intatiateBlock()
    {
        towerIndex--;
        if (towerIndex < 0)
        {
            towerIndex = transform.childCount - 1;
        }
        theTower[towerIndex].transform.localPosition = new Vector2(0, scoreCount);
    }


    private bool placeBlock()
    {
        return false;
    }

    private void EndGame()
    {
        Debug.Log("Game Over");
    }
}
