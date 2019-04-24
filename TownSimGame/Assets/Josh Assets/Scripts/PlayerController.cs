using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    // Inventory
    public int[] Inventory;
    int CurrentInvent = 0;
    int MaxInvent = 20;

    int PlayerWood = 0;

    // Gold
    int PlayerGold = 0;

    // Interaction
    GameObject OtherObject;
    public string InteractObject;

    // UI
    public GameObject InventoryPanel;
    public Text[] InventorySlots = new Text[20];
    public Text Gold;
    public Text Wood;
    public GameObject PromptPanel;
    public Text Prompt;

	// Use this for initialization
	void Start ()
    {
        Inventory = new int[MaxInvent];



        InventoryPanel.SetActive(false);
        PromptPanel.SetActive(false);

    }
	
	// Update is called once per frame
	void Update ()
    {
        Interaction();

        SortInventory();
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
        if (CurrentInvent < MaxInvent)
        {
            Inventory[CurrentInvent] = Item;
            CurrentInvent++;
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

        int counter = 0;

        foreach (Text Slot in InventorySlots)
        {

            Slot.text = (counter + 1) + ". " + GetLootName(Inventory[counter]);
            counter++;
        }
    }

    string GetLootName(int LootID)
    {
        string Name = "";

        switch (LootID)
        {
            case 1:
                Name = "Wood";
                break;
            case 2:
                Name = "Fish";
                break;
            case 3:
                Name = "Monster Guts";
                break;
            case 4:
                Name = "Monster Flesh";
                break;
            case 5:
                Name = "Monster Brain";
                break;
        }

        return Name;
    }

    void SortInventory()
    {
        int counter = 0;

        while (counter <= 19)
        {
            if (counter != 0)
            {
                if (Inventory[counter - 1] == 0)
                {
                    Inventory[counter - 1] = Inventory[counter];
                    Inventory[counter] = 0;
                }
            }
            counter++;
        }
    }

    void AddToInventory(int LootID)
    {
        if (Inventory[19] != 0)
        {
            Inventory[19] = LootID;
        }
    }

}
