using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Defender))]
public class Stone : MonoBehaviour
{
    private Animator anim;
    private Defender defender;
    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        defender = GetComponent<Defender>();

    }
	
	// Update is called once per frame
	void Update () {
		
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
}
