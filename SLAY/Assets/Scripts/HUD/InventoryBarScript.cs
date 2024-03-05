using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBarScript : MonoBehaviour
{
    public Storage inventory;
    public GameObject player;

    List<InventorySlotScript> slotList = new List<InventorySlotScript>(); // 存储背包槽的列表

    void Start()
    {
        PlayerScript playerScript = player.GetComponent<PlayerScript>();
        inventory = playerScript.inventory;

        // 将 Inventory 面板的槽添加到列表中
        int index = 0;
        foreach (InventorySlotScript child in gameObject.GetComponentsInChildren<InventorySlotScript>())
        {
            child.storage = inventory;
            child.slotIndex = index;
            index++;
            slotList.Add(child);
        }
    }

    void Update()
    {
        UpdateInventoryUI();
    }

    // Everytime an item is Added or Removed from the Inventory, the UpdateInventoryUI runs
    public void UpdateInventoryUI()
    {
        PlayerScript playerScript = player.GetComponent<PlayerScript>();

        // For each slot in the list it's attributed an Item from the itemList and the corresponding quantity
        foreach (InventorySlotScript slot in slotList)
        {
            // Calls the UpdateSlot() function on the respective slot and attributes the item and quantity of their unique index in the itemList
            slot.UpdateSlot();

        }
    }
}
