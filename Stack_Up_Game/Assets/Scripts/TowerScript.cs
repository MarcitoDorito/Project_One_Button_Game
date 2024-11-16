using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public BlockMovement blockMovement;

    public const float BLOCK_SIZE = 7.0f;

    private const float TOWER_MOVE_SPEED = 5.0f;

    private const float ERROR_MARGIN = 0.1f;

    public GameObject[] theTower;
    private Vector2 towerBounds = new Vector2(BLOCK_SIZE,0);

    public int towerIndex;

    public int scoreCount = 0;

    private int comboCount = 0;

    public float secondaryPosition;

    private Vector2 towerPosition;

    private Vector3 lastBlockPlacement;

    public bool isGameOver = false;

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
            instatiateBlock();
            scoreCount++;   
            Debug.Log(scoreCount);
            }
            else
            {
                EndGame();
            }
        }
            blockMovement.moveBlock();

        transform.position = Vector3.Lerp(transform.position, towerPosition, TOWER_MOVE_SPEED * Time.deltaTime);
    }
    private void instatiateBlock()
    {
        lastBlockPlacement = theTower[towerIndex].transform.localPosition;
        towerIndex--;
        if (towerIndex < 0)
        {
            towerIndex = transform.childCount - 1;
        }
        towerPosition = Vector2.down * scoreCount;
        theTower[towerIndex].transform.localPosition = new Vector2(0, scoreCount);
        theTower[towerIndex].transform.localScale = new Vector3(towerBounds.x, 1, towerBounds.y);
    }


    private bool placeBlock()
    {
        Transform t = theTower[towerIndex].transform;
        blockMovement.speedUpCounter++;

        float deltaX = t.localPosition.x - lastBlockPlacement.x;
        if (Mathf.Abs(deltaX) > ERROR_MARGIN)
        {
            comboCount = 0;
            towerBounds.x -= Mathf.Abs(deltaX);
            if (towerBounds.x < 0)
            {
                return false;
            }
            float middle = (lastBlockPlacement.x + t.localPosition.x) /2;
            t.localScale = new Vector3(towerBounds.x, 1, towerBounds.y);
            t.localPosition = new Vector3(middle, scoreCount, lastBlockPlacement.z);
            /*            t.localPosition = new Vector3(middle - (lastBlockPlacement.x/2),scoreCount, lastBlockPlacement.z);*/
        }
        else
        {
            comboCount++;
            t.localPosition = new Vector3(lastBlockPlacement.x, scoreCount, lastBlockPlacement.z);
            
        }
        return true;
    }

    private void EndGame()
    {
        Debug.Log("Game Over");
        theTower[towerIndex].AddComponent<Rigidbody2D>();
        isGameOver = true;
    }
}