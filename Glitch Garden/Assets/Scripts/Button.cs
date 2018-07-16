using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public static Defender selectedDefender;
    public Defender defender;
    private SpriteRenderer spriteRenderer;
    private Button[] buttonArray;
    private Text costText;
	// Use this for initialization
	void Start ()
    {
        buttonArray = GameObject.FindObjectsOfType<Button>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        SetButtonCost();

    }

    private void SetButtonCost()
    {
        int cost = defender.GetCost();
        costText = GetComponentInChildren<Text>();
        if (!costText) { Debug.Log(costText.name); }
        this.costText.text = cost.ToString();
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    private void OnMouseDown()
    {
        //return sprite to normal colour
        foreach(Button button in buttonArray)
        {
            button.spriteRenderer.color = Color.black;
        }
        spriteRenderer.color = Color.white;
        selectedDefender = defender;
        
    }
}
