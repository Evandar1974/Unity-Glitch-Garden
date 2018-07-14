using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Defender))]
public class Cactus : MonoBehaviour
{
    public Projectile projectile;
    public float rateOfFire = 1f;

    private Animator anim;
    private Defender defender;

   
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        defender = GetComponent<Defender>();
        anim.SetBool("isFiring", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetBool("isAttacking") == false)
        {
            anim.SetBool("isFiring", true);
        }
        if (anim.GetBool("isFiring") == true)
        {
            float probability = Time.deltaTime * rateOfFire;
            if(Random.value < probability)
            {
                Fire();
            }
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameObject obj = collision.gameObject;
        if (!obj.GetComponent<Attacker>())
        {
            return;
        }
        else
        {
            anim.SetBool("isFiring", false);
            anim.SetBool("isAttacking", true);
            defender.Attack(obj);
        }
    }

    private void Fire()
    {
        //add sound effect
        Instantiate<Projectile>(projectile, transform.position, Quaternion.identity);
    }
}
