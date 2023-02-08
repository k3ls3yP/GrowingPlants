using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toolsFunctionality : drag
{
    public int flowerType;
    public override void OnDropThis(drop droppedOn)
    {
        pot potObject = droppedOn as pot;
        if (potObject != null)
        {
            switch (this.tag)
            {
                case "dirt":
                    //Debug.Log($"{this.name} is dropped on {potObject}");
                    potObject.SetHasDirt(true);
                    break;
                case "water":
                    //Debug.Log($"{this.name} is dropped on {potObject}");
                    potObject.SetHasWater(true);
                    break;
                case "seed":
                    //Debug.Log($"{this.name} is dropped on {potObject}");
                    potObject.SetHasSeed(true, flowerType);
                    break;

            }
            potObject.ShouldGrow();
        }
    }


}
