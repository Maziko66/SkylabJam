using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    
    [SerializeField] private List<Item> Items = new List<Item>();
    private GameObject[] Temps = new GameObject[10];
    private string[] Including = new string[10];
    public Transform ItemContent;
    public GameObject InventoryItem;
    private int j = 0;

    void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        bool isAvailable;
        foreach (var item in Items)
        {
            isAvailable = false;
            foreach (var includes in Including)
            {
                if (item.itemName == includes)
                {
                    isAvailable = true;
                }
            }
            if (!isAvailable)
            {
                GameObject obj = Instantiate(InventoryItem, ItemContent);
                Temps[j] = obj;
                var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
                var itemIcon = obj.transform.Find("Image").GetComponent<Image>();
                itemName.text = item.itemName;
                itemIcon.sprite = item.icon;
                Including[j] = itemName.text;
                j++;
            }
        }
    }

    private void Update()
    {
        Text text;
        string str;
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (var item in Items)
            {
                if (item.itemName == "Key" || item.itemName == "Silver Key")
                {
                    InventoryManager.Instance.Remove(item);
                    for(int i = 0; i < 10; i++)
                    {
                        if (Temps[i] != null)
                        {
                            text = Temps[i].transform.Find("ItemName").GetComponent<Text>();
                            str = text.text.ToString();
                            if (str == "Key" || str == "Silver Key")
                            {
                                Destroy(Temps[i]);
                                //Temps[i].SetActive(false);
                                break;
                            }
                        }
                    }
                    break;
                }
            }
        }
    }
}
