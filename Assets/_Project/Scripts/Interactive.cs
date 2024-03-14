using UnityEngine;

public abstract class Interactive : MonoBehaviour
{
    public bool canInteract = false;

    public abstract void OnActive();
    public abstract void OnClick();
    public abstract void OnDrop();
    public abstract void OnHover();
}
