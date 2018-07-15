using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Defender))]
public class Shooter : MonoBehaviour {

    public Projectile projectile;
   
    public GameObject gun;
    public float rateOfFire = 1f;

    private GameObject projectileParent;
    private Animator anim;
    private Defender defender;
    private Spawner myLaneSpawner;
    private Spawner[] spawners;
    // Use this for initialization
    void Start()
    {
        spawners = FindObjectsOfType<Spawner>();
        SetMyLaneSpawner();
        projectileParent = GameObject.Find("Projectiles");
        if(!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }
        anim = GetComponent<Animator>();
        defender = GetComponent<Defender>();
        anim.SetBool("isFiring", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAttackerAheadInLane())
        {
            anim.SetBool("isFiring", true);
        }
        else
        {
            anim.SetBool("isFiring", false);
        }
        if (anim.GetBool("isFiring") == true)
        {
            float probability = Time.deltaTime * rateOfFire;
            if (Random.value < probability)
            {
                Fire();
            }
        }
    }

    void SetMyLaneSpawner()
    {
       
        foreach(Spawner spawner in spawners)
        {
            if(spawner.transform.position.y == this.transform.position.y)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    bool IsAttackerAheadInLane()
    {
        if(myLaneSpawner.transform.childCount <=0)
        {
            return false;
        }
        foreach(Transform attacker in myLaneSpawner.transform)
        {
            if(attacker.transform.position.x > this.transform.position.x)
            {
                return true;
            }
        }
        return false;
        
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
            anim.SetBool("isAttacking", true);
            defender.Attack(obj);
        }        
    }

    private void Fire()
    {
        //add sound effect
        
        Projectile myProjectile = Instantiate<Projectile>(projectile, gun.transform.position, Quaternion.identity);
        myProjectile.transform.parent = projectileParent.transform;
    }
}

