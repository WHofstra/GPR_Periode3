using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    private Inventory inventory;
    private Text text;

    private List<string> messages = new List<string>();
    private void Start()
    {
        text = GetComponent<Text>();
        inventory = FindObjectOfType<Inventory>();

        if (inventory != null)
        {
            inventory = inventory.GetComponent<Inventory>();
            inventory.AddedItem += AddItemToList;
        }

        //Empty Textbox
        text.text = "";
    }

    private void AddItemToList(GameObject item, List<GameObject> list)
    {
        messages.Add(("You have added " + item.name + "; slot capacity: " + list.Count).ToString());
        DisplayText(messages);
        StartCoroutine(NextText());
    }

    private void DisplayText(List<string> display)
    {
        text.text = "";

        foreach (string t in display)
        {
            text.text += t + "\n";
        }
    }

    private IEnumerator NextText()
    {
        yield return new WaitForSeconds(3.0f);
        messages.RemoveAt(0);
        DisplayText(messages);
    }
}
