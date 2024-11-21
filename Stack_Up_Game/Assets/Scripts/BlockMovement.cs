using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    public TowerScript tower;
    private float blockTransition = 0.0f;

    public float blockSpeed = 2.0f;

    private float speedUp = 0.25f;

    public int speedUpCounter = 0;

    public float currentPosition;

    public float newCurrentPosition = 0.0f;

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
        currentPosition = Mathf.Sin(blockTransition) * TowerScript.BLOCK_SIZE;
        newCurrentPosition = currentPosition;
        blockTransition += Time.deltaTime * blockSpeed;
        if (tower.isGameOver)
        {
            return;
        }
        //if (isPlacedOnX)
        //{
        tower.theTower[tower.towerIndex].transform.localPosition = new Vector2(currentPosition, tower.counter);
    }
        //}
        //else
        //{
        //    tower.theTower[tower.towerIndex].transform.localPosition = new Vector3(0, Mathf.Sin(blockTransition) * TowerScript.BLOCK_SIZE, tower.secondaryPosition);
        //}
    
}
