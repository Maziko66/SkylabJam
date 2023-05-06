using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryManager.Instance.Add(item);
            InventoryManager.Instance.ListItems();
            Destroy(gameObject);
        }
    }
}
