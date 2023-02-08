using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pot : drop
{
    public bool hasDirt = false;
    public bool hasSeed = false;
    public bool hasWater = false;
    public SpriteRenderer stemChildRenderer;
    public SpriteRenderer flowerChildRenderer1;
    public SpriteRenderer flowerChildRenderer2;
    public WaterFill waterBar;
    public bool canBloom;
    public bool hasBloomed;
    public int flowerTypeGrown;

    private void Start()
    {
        waterBar.SetMaxWater(1);
        waterBar.AddWater(0);
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
    public void SetHasSeed(bool addSeed, int flowerType)
    {
        if (!hasSeed)
        {
            hasSeed = addSeed;
            flowerTypeGrown = flowerType;
        }

    }
    public bool GetHasWater()
    {
        return hasWater;
    }
    public void SetHasWater(bool addWater)
    {
        hasWater = addWater;
        waterBar.AddWater(0.5f);
    }

    public void ShouldGrow()
    {
        
        if (hasDirt && hasSeed && hasWater && !canBloom)
        {
            Color stemSpriteColor = stemChildRenderer.material.color;
            Color newColor = new Color(stemSpriteColor.r, stemSpriteColor.g, stemSpriteColor.b, 1);
            stemChildRenderer.material.color = newColor;
            canBloom = true;
            
        }
        else if (canBloom && !hasBloomed && waterBar.GetTotalWater() == 1)
        {
            if (flowerTypeGrown == 1)
            {
                Color flowerSpriteColor = flowerChildRenderer1.material.color;
                Color newColor = new Color(flowerSpriteColor.r, flowerSpriteColor.g, flowerSpriteColor.b, 1);
                flowerChildRenderer1.material.color = newColor;
                hasBloomed = true;
            }
            else if (flowerTypeGrown ==2)
            {
                Color flowerSpriteColor = flowerChildRenderer2.material.color;
                Color newColor = new Color(flowerSpriteColor.r, flowerSpriteColor.g, flowerSpriteColor.b, 1);
                flowerChildRenderer2.material.color = newColor;
                hasBloomed = true;
            }

        }
    }
}
