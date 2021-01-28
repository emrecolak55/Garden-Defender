using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int attackerCount = 0;
    bool isTimerFinished = false;
    [SerializeField] GameObject winCanvas;
    [SerializeField] GameObject loseCanvas;
    [SerializeField] float delayTime = 3f;
    private void Start()
    {
        winCanvas.SetActive(false); // Turning off at first
        loseCanvas.SetActive(false);
    }
    public void AttackerSpawned()
    {
        attackerCount++;
    }
    public void AttackerDestroyed()
    {
        attackerCount--;
        if(attackerCount <=0 && isTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    private IEnumerator HandleWinCondition()
    {
        GetComponent<AudioSource>().Play();
        winCanvas.SetActive(true);

        yield return new WaitForSeconds(delayTime);
        FindObjectOfType<LevelLoader>().LoadNextScene();
        
        // load next scene
    }

    public void HandleLoseCondition()
    {
        loseCanvas.SetActive(true);
        Time.timeScale = 0;
    }
    // Update is called once per frame
    public void LevelTimerFinished()
    {
        isTimerFinished = true;
        StopSpawners();
    }
    private void StopSpawners()
    {
        AttackerSpawner[] attackerArray = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in attackerArray)
        {
            spawner.StopSpawning();
        }
    }
  
}
