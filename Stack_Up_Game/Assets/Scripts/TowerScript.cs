using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerScript : MonoBehaviour
{
    public UI_Script uiScript;

    public BlockMovement blockMovement;

    public CutBlockScript cutBlockScript;

    public BlockColorManager blockColorManager;

    public const float BLOCK_SIZE = 7.0f;

    private const float TOWER_MOVE_SPEED = 5.0f;

    private const float ERROR_MARGIN = 0.1f;

    public GameObject[] theTower;
    private Vector2 towerBounds = new Vector2(BLOCK_SIZE,0);

    public int towerIndex;

    public int counter = 0;

    public int scoreCount = 0;

    private int comboCount = 0;

    public float secondaryPosition;

    private Vector2 towerPosition;

    private Vector3 lastBlockPlacement;

    public bool isGameOver = false;

    public KeyCode placeBlockKey = KeyCode.Space;

    public KeyCode Click = KeyCode.Mouse0;

    [SerializeField]
    private Color startColor = Color.white;

    // Start is called before the first frame update
    private void Start()
    {
        theTower = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            theTower[i] = transform.GetChild(i).gameObject;
        }
        towerIndex = transform.childCount -1;

        startColor = new Color(Random.Range(0.2f, 0.8f), Random.Range(0.2f, 0.8f), Random.Range(0.2f, 0.8f));

        ColorChange();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(placeBlockKey) || Input.GetKeyDown(Click))
        {
            if (PlaceBlock())
            {
                InstantiateBlock();
            counter++;   
            Debug.Log(counter);
            }
            else
            {
                EndGame();
            }
        }
            blockMovement.MoveBlock();


        transform.position = Vector3.Lerp(transform.position, towerPosition, TOWER_MOVE_SPEED * Time.deltaTime);
    }
    private void InstantiateBlock()
    {   
        lastBlockPlacement = theTower[towerIndex].transform.localPosition;
        towerIndex--;
        if (towerIndex < 0)
        {
            towerIndex = transform.childCount - 1;
        }
        towerPosition = Vector2.down * counter;
        theTower[towerIndex].transform.localPosition = new Vector2(0, counter);
        theTower[towerIndex].transform.localScale = new Vector3(towerBounds.x, 1, towerBounds.y);


        ColorChange();
/*        SpriteRenderer spriteRenderer = theTower[towerIndex].GetComponent<SpriteRenderer>();

        if(spriteRenderer != null)
        {
            Color randomColor = new Color(Random.value, Random.value, Random.value);
            blockColorManager.ChangeBlockColor(spriteRenderer, randomColor);
            cutBlockScript.setBlockColor(randomColor);
        }
        else
        {
            Debug.LogError("SpriteRenderer is null");
        }*/
    }


    private bool PlaceBlock()
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

            Vector2 cutPosition = new Vector3(t.position.x + (t.localScale.x / 2) * Mathf.Sign(deltaX), t.position.y);
            Vector2 cutScale = new Vector3(Mathf.Abs(deltaX), t.localScale.y);

            cutBlockScript.CutBlock(cutPosition, cutScale);

            t.localPosition = new Vector3(middle, counter, lastBlockPlacement.z);
            /*            t.localPosition = new Vector3(middle - (lastBlockPlacement.x/2),scoreCount, lastBlockPlacement.z);*/
            int decentStack = 1;
            uiScript.IncreaseScore(decentStack);
        }
        else
        {
            comboCount++;
            t.localPosition = new Vector3(lastBlockPlacement.x, counter, lastBlockPlacement.z);
            int perfectStack = 2;
            uiScript.IncreaseScore(perfectStack);
            
        }
        return true;
    }

    //can you wright a function that will change the color of the block


    /*   public void ChangeBlockColor(SpriteRenderer spriteRenderer, Color color)
        {
            spriteRenderer.color = color;
        }*/

    private void EndGame()
    {
        float waitTime = 2f;
        Debug.Log("Game Over");
        theTower[towerIndex].AddComponent<Rigidbody2D>();
        isGameOver = true;
        StartCoroutine(EndGame(waitTime));
        IEnumerator EndGame(float wait)
        {
            yield return new WaitForSeconds(wait);
            SceneManager.LoadScene(3);
        }
    }

    public void ColorChange()
    {
        SpriteRenderer spriteRenderer = theTower[towerIndex].GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            Color randomColor = new Color(startColor.r + Random.Range(-0.05f,0.05f), startColor.g + Random.Range(-0.05f, 0.05f), startColor.b + Random.Range(-0.05f, 0.05f));
            blockColorManager.ChangeBlockColor(spriteRenderer, randomColor);
            cutBlockScript.setBlockColor(randomColor);
        }
        else
        {
            Debug.LogError("SpriteRenderer is null");
        }
    }
}