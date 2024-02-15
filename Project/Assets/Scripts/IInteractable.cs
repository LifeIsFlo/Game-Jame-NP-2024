using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void Drop();
    public void Interact(Transform hand);
    public void Use();
    public string GetName();
    public string GetInteraction();
}
