using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    private bool isPickable;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPickable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPickable = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && isPickable)
        {
            InventoryManager.Instance.Add(item);
            print(item.itemName);
            InventoryManager.Instance.ListItems();
            Destroy(gameObject);
        }
    }
}
