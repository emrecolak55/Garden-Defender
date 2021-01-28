using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";
    private void Start()
    {
        CreateDefenderParent();
    }
    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }
    private void OnMouseDown()
    {
        AttemptToPlaceDefender(GetSquareClicked());
    }

    public void SetSelectedDefender( Defender defenderFromMarket)
    {
        defender = defenderFromMarket;
    }

    private void AttemptToPlaceDefender( Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();
        if(starDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            starDisplay.SpendStars(defenderCost);
        }
    }
    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos); // worldpos olmazsa canvasa rastgele klonluyor
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos; 
    }
    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        Vector2 roundedWorldPos = new Vector2(newX, newY);
        return roundedWorldPos;
    }
    private void SpawnDefender(Vector2 roundedPos)
    {
        //Vector2 spawnPos = GetSquareClicked();
        Defender newDefender = Instantiate(defender, roundedPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }
}
