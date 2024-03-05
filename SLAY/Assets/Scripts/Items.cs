using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public struct ItemType
{
    public string itemName;
    public string description;
    public int maxStack; //最大堆叠数量
    public Sprite icon; //物品图标
    public List<string> tags; //物品标签

    //public static string defaultPath = "Items";

    public bool stackable
    {
        get
        {
            return maxStack > 1;
        }
    }

    public ItemType(string name, string desc = "", int stack = 1, string iconPath = "", int spriteIndex = 0)
    {
        this.itemName = name;
        this.description = desc;
        this.maxStack = stack;
        //if (iconPath == "")
        //{
        //    iconPath = Path.Combine(defaultPath, name);
        //}
        //this.icon = Resources.Load<Sprite>(iconPath);
        Sprite[] icons = Resources.LoadAll<Sprite>(iconPath);
        this.icon = icons[spriteIndex];
        this.tags = new List<string>();
    }
}

public static class ItemTypes
{
    public static Dictionary<string, ItemType> itemTypes;
    private static string ITEM_PATH = "Untitled Artwork";

    public static void Init()
    {

        itemTypes = new Dictionary<string, ItemType>();
        itemTypes.Add("木头", new ItemType("木头", "", 1, ITEM_PATH, 2));
        itemTypes.Add("石头", new ItemType("石头", "", 1, ITEM_PATH, 1));
    }
}

[Serializable]
public class Item
{
    public string name;
    public string data;
    public int quantity;

    public ItemType type
    {
        get
        {
            return ItemTypes.itemTypes[name];
        }
    }

    // 设置物品为空
    public void SetEmpty()
    {
        this.name = "";
        this.data = "";
        this.quantity = 0;
    }

    public bool isEmpty
    {
        get
        {
            return string.IsNullOrEmpty(name) && (quantity <= 0);
        }
    }

    public Item(string name = "", string data = "", int quantity = 1)
    {
        this.name = name;
        this.data = data;
        this.quantity = quantity;
    }
}

[Serializable]
public class Slot
{
    public Item item;

    public Slot(Item item)
    {
        this.item = item;

        //this.item = new Item(name, data, quantity);
    }

    // 获得格子的剩余空间
    public int GetRemainSpace(string name = "")
    {
        if (name == "")
        {
            name = item.name;
        }

        if (item.isEmpty)
        {
            return ItemTypes.itemTypes[name].maxStack;
        }
        else
        {
            if (name == item.name)
            {
                return item.type.maxStack - item.quantity;
            }
            else
            {
                return 0;
            }
        }
    }

    public void AddToStack(int amount)
    {
        item.quantity += amount;
        if (item.quantity > item.type.maxStack)
        {
            Debug.LogWarning(string.Format("错误：添加物品后，物品数量{0}超过最大堆叠数量{1}！", item.quantity, item.type.maxStack));
        }  
    }

    public void RemoveFromStack(int amount)
    {
        item.quantity -= amount;
        if (item.quantity < 0)
        {
            Debug.LogWarning(string.Format("错误：移除物品后，物品数量{0}为负！", item.quantity));
        }

        if (item.quantity <= 0)
        {
            item.SetEmpty();
        }
    }
}

[Serializable]
public class Storage
{
    public List<Slot> itemList;

    public Storage()
    {
        itemList = new List<Slot>();
    }

    public void AddItem(Item item)
    {
        //slot = Slot(item);

        //itemList.Add(item);

            //if (itemList.Contains(item))
            //{
            //    quantityList[itemList.IndexOf(item)] = quantityList[itemList.IndexOf(item)] + quantityAdded;
            //}
            //else
            //{

            //    if (itemList.Count < slotList.Count)
            //    {
            //        itemList.Add(item);
            //        quantityList.Add(quantityAdded);
            //    }
            //    else { }

            //}

        //每次添加物品时更新库存UI
        //UpdateInventoryUI();
    }

    public void RemoveItem(Item item)
    {
        //itemList.Remove(item);
    }

    //public string DebugDisplayItems()
    //{
    //    StringBuilder stringBuilder = new StringBuilder();
    //    foreach (var item in itemList)
    //    {
    //        stringBuilder.AppendLine($"Name: {item.name}, Data: {item.data}, Quantity: {item.quantity}");
    //    }
    //    return stringBuilder.ToString();
    //}

    public Item GetItemByIndex(int index)
    {
    //    if (index >= 0 && index < itemList.Count)
    //    {
    //        return itemList[index];
    //    }
    //    else
    //    {
            return null;
    //    }
    }
}
