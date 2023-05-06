using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            InventoryManager.Instance.Add(item);
            print(item.itemName);
            InventoryManager.Instance.ListItems();
            Destroy(gameObject);
        }
    }
}
