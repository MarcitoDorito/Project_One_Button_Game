using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColorManager : MonoBehaviour
{
    private float currentColor = 0.0f;
    [SerializeField] private float hueStep = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignColor(GameObject block)
    {

        Renderer renderer = block.GetComponent<Renderer>();
        if(renderer != null)
        {
            Color newColor = Color.HSVToRGB(currentColor, 1f, 1f);
            renderer.material.color = newColor;
        }

        currentColor += hueStep;

        if (currentColor > 1f)
        {
            currentColor -= 1f;
        }
    }
}
