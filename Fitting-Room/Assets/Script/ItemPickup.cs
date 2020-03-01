using UnityEngine;

public class ItemPickup : Interactables
{
    public Item item;
    public override void Interact(){
        base.Interact();
        Pickup();
    }
    public void Pickup(){

        Debug.Log("Picking up " + item.name);
        //add to inventory 
        bool wasPickedUp;
        wasPickedUp = Inventory.instance.Add(item);
        if(wasPickedUp){
            Destroy(gameObject);
        }
    }
}
