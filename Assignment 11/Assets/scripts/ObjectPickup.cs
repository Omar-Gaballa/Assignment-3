using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    [SerializeField] Transform holdArea;
    private GameObject heldObject;
    private Rigidbody heldObjectRB;




    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;


    void Update(){
        if (Input.GetKeyDown (KeyCode.E)){

            if (heldObject==null){
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange)){
                    //pickup object
                    PickupObject(hit.transform.gameObject);
                }

            }else{
                //drop object
                DropObject();
            }

        }


        if(heldObject != null){
            //move object
            MoveObject();
        }
    }

    void MoveObject(){
        if (Vector3.Distance(heldObject.transform.position, holdArea.position)> 0.1f){
            Vector3 moveDirection = (holdArea.position - heldObject.transform.position);
            heldObjectRB.AddForce(moveDirection * pickupForce);
        }
    }


    void PickupObject(GameObject pickedObject){
        if ( pickedObject.GetComponent<Rigidbody>()){
            heldObjectRB = pickedObject.GetComponent<Rigidbody>();
            heldObjectRB.useGravity = false;
            heldObjectRB.drag= 10;
            heldObjectRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjectRB.transform.parent = holdArea;
            heldObject = pickedObject;
        }
    }

    void DropObject(){
        
        heldObjectRB.useGravity = true;
        heldObjectRB.drag= 1;
        heldObjectRB.constraints = RigidbodyConstraints.None;

        heldObjectRB.transform.parent = null;
        heldObject = null;
        
    }
}
