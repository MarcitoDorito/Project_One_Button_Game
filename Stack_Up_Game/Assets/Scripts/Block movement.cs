using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockmovement : MonoBehaviour
{
    public KeyCode stop;

    public bool rayCheckRight;
    public bool rayCheckLeft;
    public LayerMask snapLayer;
    private Color rayColor = Color.red;
    //private Color rayColor2 = Color.red;

    //public MonoBehaviour scriptToDisable;
    //public MonoBehaviour scriptToAdd;

    public float blockSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(blockSpeed, 0) * Time.deltaTime);

        rayCheckRight = Physics2D.Raycast(transform.position + new Vector3(0.5f * transform.localScale.x, 0), Vector2.down, 0.9f, snapLayer);
       /* rayCheckLeft = Physics2D.Raycast(transform.position - new Vector3(0.5f * transform.localScale.x, 0), Vector2.down, 0.9f, snapLayer);*/
        Debug.DrawRay(transform.position + new Vector3(0.5f * transform.localScale.x, 0), Vector2.down, rayColor);
        //Debug.DrawRay(transform.position - new Vector3(0.5f * transform.localScale.x, 0), Vector2.down, rayColor2);

        if (rayCheckRight)
        {
            /*transform.position = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));*/
            rayColor = Color.green;
        }
        //else if (rayCheckLeft)
        //{
        //    rayColor2 = Color.green;
        //}
        else
        {
            rayColor = Color.red;
            //rayColor2 = Color.red;
        }

        if (!rayCheckRight)
        {
            rayColor = Color.red;
        }
        //else if (!rayCheckLeft)
        //{
        //    rayColor2 = Color.red;
        //}
        else
        {
            rayColor = Color.green;
            //rayColor2 = Color.green;
        }

        if (Input.GetKeyDown(stop) && rayCheckRight || Input.GetKeyDown(stop) && !rayCheckLeft)
        {
            blockSpeed = 0;
            snapToGrid();
            //// Disable the specified script
            //if (scriptToDisable != null)
            //{
            //    scriptToDisable.enabled = false;
            //}

            //// Add and enable the specified script
            //if (scriptToAdd != null && GetComponent(scriptToAdd.GetType()) == null)
            //{
            //    gameObject.AddComponent(scriptToAdd.GetType());
            //}
        }

        //if (rayCheckLeft)
        //{
        //    changeDirection();
        //}
        if (!rayCheckRight)
        {
            changeDirection();
        }
        //can you make the block snap to the grid when it stops moving?


    }

    private void snapToGrid()
    {
        float maxSnapRange = 0.1f;
        float snapValue = 0.1f;
        float newX = Mathf.Round(transform.position.x / snapValue) * snapValue;

        if(Mathf.Abs(transform.position.x - newX) <= maxSnapRange)
        {
            transform.position = new Vector2(newX,transform.position.y);
        }
    }


    private void changeDirection()
    {
        blockSpeed = blockSpeed * -1f;
    } 
}
