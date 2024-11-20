using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColorManager : MonoBehaviour
{
    public void ChangeBlockColor(SpriteRenderer spriteRenderer, Color color)
    {
        spriteRenderer.color = color;
    }
}
