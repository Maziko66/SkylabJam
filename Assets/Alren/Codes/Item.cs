using UnityEngine;

public enum ItemType
{
    Key,
    SilverKey,
    GoldKey
}

[CreateAssetMenu(fileName = "New Item",menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public ItemType ItemType;
    public string itemName;
    public Sprite icon;
}
