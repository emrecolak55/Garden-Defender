using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    bool spawn = true;
    [SerializeField] Attacker[] attackerArray;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        if(attackerArray.Length == 0) { spawn = false; } ////////// Levellerde spawnerleri disable edebilmek için
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
  

    }
    public void StopSpawning()
    {
        spawn = false;
        //gameObject.SetActive(false); /////////// ! ! ! ! 
        
    }

    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform;

    }
    private void SpawnAttacker()
    {
        int attackerIndex = Random.Range(0, attackerArray.Length);
        Spawn(attackerArray[attackerIndex]);
    }
 
}
