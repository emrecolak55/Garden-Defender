﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] int damage = 100;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
    }
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        var health = otherObject.GetComponent<Health>();
        var attacker = otherObject.GetComponent<Attacker>();
        if ( attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
        
    }
}
