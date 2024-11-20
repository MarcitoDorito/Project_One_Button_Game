using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutBlockScript : MonoBehaviour
{
    public TowerScript towerScript;
    public BlockMovement blockMovement;
    public GameObject rubblePrefab;
    public BlockColorManager blockColorManager;

    private Color blockColor;



    public float newDirection = 0f;
    // Start is called before the first frame update

    void Start()
    {
        rubblePrefab.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (blockMovement.newCurrentPosition < 0)
        {
            newDirection = -1f;
        }
        else if (blockMovement.newCurrentPosition > 0)
        {
            newDirection = 1f;
        }
    }

    public void setBlockColor(Color color)
    {
        blockColor = color;
    }

    public void CutBlock(Vector2 pos, Vector2 scale)
    {
            /*float direction = Mathf.Sign(blockMovement.blockSpeed);*/ /*= Random.Range(0, 2) == 0 ? -1f : 1f;*/
        Vector2 force = new Vector2(300f * newDirection, 0f);
        if (rubblePrefab != null)
        {
            GameObject rubble = Instantiate(rubblePrefab, pos, Quaternion.identity);
            rubble.transform.localScale = scale;
            rubble.GetComponent<Rigidbody2D>().AddForce(new Vector2(force.x, Random.Range(-200, 200)));
            if (rubble.gameObject)
            {
                Destroy(rubble.gameObject, 2f);
            }
            SpriteRenderer spriteRenderer = rubble.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                blockColorManager.ChangeBlockColor(spriteRenderer, blockColor);
            }
            else
            {
                Debug.LogError("SpriteRenderer is null");
            }

        }
        else
        {
            Debug.LogError("Rubble!!!");
        }
    }
}
