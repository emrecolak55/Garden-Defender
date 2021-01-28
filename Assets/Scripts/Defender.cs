using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;

    public void AddStars(int starsToAdd)
    {
        FindObjectOfType<StarDisplay>().AddStars(starsToAdd);
    }
    public int GetStarCost()
    {
        return starCost;
    }
}
