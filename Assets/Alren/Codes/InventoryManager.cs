using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [SerializeField] private List<Item> _items;
    private GameObject[] _temps = new GameObject[10];
    private string[] _including = new string[10];
    public Transform ItemContent;
    public GameObject InventoryItem;
    private int index = 0;

    void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        _items.Add(item);
    }

    public void Remove(Item item)
    {
        _items.Remove(item);
    }

    public void ListItems()
    {


        foreach (var item in _items)
        {
            bool isAvailable = _including.FirstOrDefault(i => item.itemName == i) != null;

            //isAvailable = false;
            //foreach (var includes in Including)
            //{
            //    if (item.itemName == includes)
            //    {
            //        isAvailable = true;
            //    }
            //}

            if (!isAvailable)
            {
                GameObject obj = Instantiate(InventoryItem, ItemContent);
                _temps[index] = obj;
                var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
                var itemIcon = obj.transform.Find("Image").GetComponent<Image>();
                itemName.text = item.itemName;
                itemIcon.sprite = item.icon;
                _including[index] = itemName.text;
                index++;
            }
        }
    }

    public void UseItem(string str)
    {
        if (Input.GetKey(KeyCode.E))
        {

            foreach (var item in _items)
            {
                print(item.itemName + " Trigger");
                print(str);
                //if (item.ItemType == ItemType.Key || item.ItemType == ItemType.SilverKey)
                if (item.itemName + " Trigger" == str)
                {
                    Instance.Remove(item);
                    for (int i = 0; i < 10; i++)
                    {
                        if (_temps[i] != null)
                        {
                            // TODO @ 7.34pm: TMP'ye çevir!!!!!!!!
                            //var data = Temps[i].transform.Find("ItemName").GetComponent<TMP_Text>();
                            var data = _temps[i].transform.Find("ItemName").GetComponent<Text>();
                            //text = Temps[i].transform.Find("ItemName").GetComponent<Text>();
                            //str = text.text.ToString();
                            if (data.text + " Trigger" == str)
                            {
                                Destroy(_temps[i]);
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
