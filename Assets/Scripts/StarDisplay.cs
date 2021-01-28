using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text starText;
    void Start()
    {
        starText = GetComponent<Text>();
        UpdateText();
    }

    private void UpdateText()
    {
        starText.text = stars.ToString();
    }
    
    public bool HaveEnoughStars(int cost)
    {
        return stars >= cost;
    }
    public void AddStars(int added)
    {
        stars += added;
        UpdateText();
    }
    public void SpendStars(int spend)
    {
        if(stars >= spend)
        {
            stars -= spend;
            UpdateText();
        }
        
    }
}
