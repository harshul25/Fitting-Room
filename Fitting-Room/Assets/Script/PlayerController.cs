using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public Interactables focus;
    public LayerMask movementMask;
    PlayerMotor motor;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
       cam = Camera.main; 
       motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100, movementMask)){
                //Debug.Log("We hit "+ hit.collider.name + " " + hit.point );
                motor.MoveToPoint(hit.point);
                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(1)){
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100)){
                //Debug.Log("We hit "+ hit.collider.name + " " + hit.point );
                //motor.MoveToPoint(hit.point);
                Interactables interactable = hit.collider.GetComponent<Interactables>();
                if (interactable != null){
                    SetFocus(interactable);
                }
                //This if is for interactibles
            }
        }
        
    }

    void SetFocus(Interactables newFocus){
       
       if (newFocus != focus){
           if(focus != null)
                focus.OnDefocused();
           
           focus = newFocus;
            motor.FollowTarget(newFocus);
       }
       
        
       
        newFocus.onFocused(transform);
    } 

    void RemoveFocus(){
        
        if (focus != null)
            focus.OnDefocused();
        focus = null;
        motor.StopFollowTarget();
    }
}
