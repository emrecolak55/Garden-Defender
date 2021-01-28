using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] float baseLives = 3;
    float lives;
    [SerializeField] int damage = 1;
    Text livesText;
    // Start is called before the first frame update
    void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        livesText = GetComponent<Text>();
        UpdateText();
    }

    private void UpdateText()
    {
        livesText.text = lives.ToString();
    }
    // Update is called once per frame
    public void DecreaseLife()
    {
       
            lives -= damage;
            UpdateText();
            if( lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }

    }
}
