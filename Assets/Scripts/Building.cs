using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private bool isvalid = false;
    private float timerValue = 0f;
    [SerializeField] private float timerCooldown = 3f;
    [SerializeField] private SpriteRenderer spriteRenderer = null;
    [SerializeField] private BuildingComponent buildingComponent = null; 

    public void ActivateBuilding()
    {
        isvalid = true;
        spriteRenderer.color = Color.white;
        
    }

    private void Start()
    {
        spriteRenderer.color = new Color(1f, 1f, 1f, .45f); 
    }
    private void Update()
    {
        if(isvalid)
        {
            timerValue += Time.deltaTime; 
            if(timerValue >= timerCooldown)
            {
                Debug.Log("Prout");
                buildingComponent.ApplyAction();
                timerValue = 0f;
            }
        }
    }
}
