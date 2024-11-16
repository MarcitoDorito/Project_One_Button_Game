using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    public TowerScript tower;
    private float blockTransition = 0.0f;
    private float blockSpeed = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void moveBlock()
    {
        blockTransition += Time.deltaTime * blockSpeed;
        tower.theTower[tower.towerIndex].transform.localPosition = new Vector3(0,Mathf.Sin(blockTransition) * TowerScript.BLOCK_SIZE,0);
    }
}
