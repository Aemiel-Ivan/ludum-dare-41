using UnityEngine;

public class Interactable : MonoBehaviour {

    protected string flag;

    [SerializeField]
    protected bool isAlternate;
    public bool IsAlternate
    {
        get { return isAlternate; }
    }

    public virtual void Setup(string flag)
    {
        this.flag = flag;
    }

    public virtual void Interact()
    {
        
    }
}
