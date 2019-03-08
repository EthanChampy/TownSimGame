using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    // Inventory
    int MaxInvent = 20;
    int PlayerWood = 0;

    // Gold
    int PlayerGold = 0;

    // Interaction
    GameObject OtherObject;
    public string InteractObject;

    // UI
    public GameObject InventoryPanel;
    public Text Gold;
    public Text Wood;
    public GameObject PromptPanel;
    public Text Prompt;

	// Use this for initialization
	void Start ()
    {
        InventoryPanel.SetActive(false);
        PromptPanel.SetActive(false);

    }
	
	// Update is called once per frame
	void Update ()
    {
        Interaction();
        DisplayInvent();
        Gold.text = "Gold: " + PlayerGold;


	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tree")
        {
            OtherObject = other.gameObject;
            InteractObject = "Tree";
            Prompt.text = "Press E to chop tree.";
            PromptPanel.SetActive(true);
        }
        else if (other.name == "Lumber Yard")
        {
            InteractObject = other.name;
            Prompt.text = "Press E to sell wood.";
            PromptPanel.SetActive(true);
            InventoryPanel.SetActive(true);
        }
        else
        {
            InteractObject = other.name;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Tree")
        {
            OtherObject = null;
            InteractObject = null;
            PromptPanel.SetActive(false);
        }
        else
        {
            PromptPanel.SetActive(false);
            InventoryPanel.SetActive(false);
        }
    }

    void Interaction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (InteractObject == "Tree")
            {
                OtherObject.GetComponent<TreeController>().TreeValue--;
                Debug.Log("Hit tree.");

                if (PlayerWood < MaxInvent)
                {
                    AddItemToInventory(0);
                }

                if (OtherObject.GetComponent<TreeController>().TreeValue <= 0)
                {
                    InteractObject = null;
                    PromptPanel.SetActive(false);
                }
            }
            else if (InteractObject == "Lumber Yard")
            {
                if (PlayerWood > 0)
                {
                    PlayerWood--;
                    PlayerGold = PlayerGold + 5;
                }
            }
        }
    }

    void AddItemToInventory(int Item)
    {
        if (Item == 0)
        {
            PlayerWood++;
        }
    }

    void DisplayInvent()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            InventoryPanel.SetActive(true);
        }
        else
        {
            InventoryPanel.SetActive(false);
        }

        Wood.text = "Wood: " + PlayerWood;
    }

}
