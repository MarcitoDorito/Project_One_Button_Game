using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    public TowerScript tower;
    private float blockTransition = 0.0f;

    private float blockSpeed = 2.0f;

    private float speedUp = 0.25f;

    public int speedUpCounter = 0;

    //public bool isPlacedOnX = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (speedUpCounter == 6) 
        {
            blockSpeed += speedUp;

            speedUpCounter = 0;

            Debug.Log(speedUpCounter);
        }

    }

    public void MoveBlock()
    {

        if (tower.isGameOver)
        {
            return;
        }
        blockTransition += Time.deltaTime * blockSpeed;
        //if (isPlacedOnX)
        //{
        tower.theTower[tower.towerIndex].transform.localPosition = new Vector2(Mathf.Sin(blockTransition) * TowerScript.BLOCK_SIZE, tower.scoreCount);
    }
        //}
        //else
        //{
        //    tower.theTower[tower.towerIndex].transform.localPosition = new Vector3(0, Mathf.Sin(blockTransition) * TowerScript.BLOCK_SIZE, tower.secondaryPosition);
        //}
    
}
