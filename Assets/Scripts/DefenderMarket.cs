using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderMarket : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    private void Start()
    {
        LabelButtonsWithCost();
    }

    private void LabelButtonsWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if (!costText)
        {
           // Debug.LogError("There is no cost text on the market add the text"); // not necessary
        }
        else
        {
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
    }
    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderMarket>();
        foreach (DefenderMarket button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(63, 63, 63, 255);
        }
        GetComponent<SpriteRenderer>().color = new Color(256, 256, 256);
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
}