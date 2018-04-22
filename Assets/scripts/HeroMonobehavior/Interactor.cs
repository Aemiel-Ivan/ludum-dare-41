using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour {
    
    private List<GameObject> interactableTargets;

    public void Awake ()
    {
        interactableTargets = new List<GameObject>();
    }
	
	public void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            foreach (GameObject interactableTarget in interactableTargets)
            {
                Interactable interactable = interactableTarget.GetComponent<Interactable>();
                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }
	}

    private void OnTriggerEnter2D (Collider2D collider)
    {
        Interactable interactable = collider.gameObject.GetComponent<Interactable>();
        if (interactable != null)
        {
            interactableTargets.Add(interactable.gameObject);
        }
    }

    private void OnTriggerExit2D (Collider2D collider)
    {
        Interactable interactable = collider.gameObject.GetComponent<Interactable>();
        if (interactable != null)
        {
            interactableTargets.Remove(interactable.gameObject);
        }
    }
}
