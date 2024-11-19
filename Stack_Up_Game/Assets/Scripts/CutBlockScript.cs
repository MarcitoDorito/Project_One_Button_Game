using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutBlockScript : MonoBehaviour
{
    public GameObject rubblePrefab;
    // Start is called before the first frame update
    void Start()
    {
        rubblePrefab.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void CutBlock(Vector3 pos, Vector3 scale)
    //{
    //    GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //    go.transform.localPosition = pos;
    //    transform.localScale = scale;
    //    go.AddComponent<Rigidbody>();
    //}

    public void CutBlock(Vector2 pos, Vector2 scale)
    {
        float direction = Random.Range(0, 2) == 0 ? -1f : 1f;
        Vector2 force = new Vector2(200f * direction, 0f);
        if (rubblePrefab != null)
        {
            GameObject rubble = Instantiate(rubblePrefab, pos, Quaternion.identity);
            rubble.transform.localScale = scale;
            //rubble.AddComponent<Rigidbody>();
            rubble.GetComponent<Rigidbody2D>().AddForce(new Vector2(force.x /*Random.Range(-200, 200)*/, Random.Range(100, 400)));
            if (rubble.gameObject)
            {
                Destroy(rubble.gameObject, 2f);
            }
        }
        else
        {
            Debug.LogError("Rubble!!!");
        }
    }
}
