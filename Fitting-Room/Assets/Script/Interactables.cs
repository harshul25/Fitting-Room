
using UnityEngine;

public class Interactables : MonoBehaviour
{
    public bool isFocused = false;
    Transform player;
    public float radius = 3f;
    public bool hasInteracted = false;
    public Transform interactiontransform;

    public void onFocused(Transform playerTransform){
        isFocused = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused(){
        isFocused = false;
        player = null;
        hasInteracted = false; 
    }

    void Update() {
       if(isFocused && !hasInteracted){
           float distance = Vector3.Distance(player.position, interactiontransform.position);
           if (distance <= radius){
               //SetFocus(interactable);
               //Debug.Log("Interact");
               Interact();
               hasInteracted = true;
           }
       } 
    }

    public virtual void Interact(){
        // this method is meant to be overwritten
        Debug.Log("Interacting with "+transform.name);  
    }

    void OnDrawGizmosSelected() {

        if(interactiontransform == null)
           {
             interactiontransform = transform;  
           } 
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactiontransform.position, radius);
    }
}
