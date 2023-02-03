using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pot : drop
{
    public bool hasDirt = false;
    public bool hasSeed = false;
    public bool hasWater = false;
    public SpriteRenderer stemChildRenderer;
    public WaterFill waterBar;

    private void Start()
    {
        waterBar.SetMaxWater(1);
        waterBar.SetWater(0);
    }

    public bool GetHasDirt()
    {
        return hasDirt;
    }
    public void SetHasDirt(bool addDirt)
    {
        hasDirt = addDirt;
    }
    public bool GetHasSeed()
    {
        return hasDirt;
    }
    public void SetHasSeed(bool addSeed)
    {
        hasSeed = addSeed;
    }
    public bool GetHasWater()
    {
        return hasWater;
    }
    public void SetHasWater(bool addWater)
    {
        hasWater = addWater;
        waterBar.SetWater(1);
    }

    public void ShouldGrow()
    {
        
        if(hasDirt && hasSeed && hasWater)
        {
            Color stemSpriteColor = stemChildRenderer.material.color;
            Color newColor = new Color(stemSpriteColor.r, stemSpriteColor.g, stemSpriteColor.b, 1 );
            stemChildRenderer.material.color = newColor;
            
        }
    }
}
