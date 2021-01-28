using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range ( 0f , 5f)]
     float moveSpeed = 1f;
    GameObject currentTarget;
    // Start is called before the first frame update

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }
    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if(levelController != null)
        {
            levelController.AttackerDestroyed();
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        UpdateAnimationState();
    }
    public void SetMovementSpeed(float speed)
    {
        moveSpeed = speed;
    }
    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }
    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
    }
    
   public void StrikeCurrentTarget(float damage) {
        if (!currentTarget)
        {
            return;
        }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }

    }

}
