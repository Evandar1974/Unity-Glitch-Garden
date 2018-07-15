using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Defender : MonoBehaviour
{
    public int starCost = 100;
    private Animator anim;
    private float currentSpeed;
    private GameObject currentTarget;
    private StarDisplay starDisplay;
    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!currentTarget)
        {
            anim.SetBool("isAttacking", false);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     
    }

    private void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.TakeDamage(damage);
            }
        }
    }

    public void Attack(GameObject obj)
    {
        Debug.Log(obj);
        currentTarget = obj;
    }

    public void AddStars(int stars)
    {
        starDisplay.AddStars(stars);
    }

    public int GetCost()
    {
        return starCost;
    }
}
