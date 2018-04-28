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
        bool zKeyDown = Input.GetKeyDown(KeyCode.Z);
        bool xKeyDown = Input.GetKeyDown(KeyCode.X);

        if (zKeyDown || xKeyDown)
        {
            for (int i = interactableTargets.Count - 1; i >= 0; i--)
            {
                if (this.gameObject == null)
                {
                    Debug.Log("LOL");
                    return;
                }
                Interactable[] interactables = interactableTargets[i].GetComponents<Interactable>();
                for (int j = interactables.Length - 1; j >= 0; j--)
                {
                    if (zKeyDown && !interactables[j].IsAlternate)
                    {
                        interactables[j].Interact();
                    }
                    if (xKeyDown && interactables[j].IsAlternate)
                    {
                        interactables[j].Interact();
                    }
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
