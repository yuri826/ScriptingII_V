using UnityEngine;

public class NPCShop : NPCBase
{
    [SerializeField] private ShopData shopData;
    
    public override void OnInteract()
    {
        GamemodeBase.Instance.GetUiManager().OpenShopMenu(shopData);
    }
}
