using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomyComponent : BuildingComponent
{
    [SerializeField] private int money = 0; 
    public override void ApplyAction()
    {
        money++; 
    }

}
