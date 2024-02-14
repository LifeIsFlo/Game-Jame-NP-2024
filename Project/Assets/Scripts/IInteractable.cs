using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void Drop();
    public void PickUp();
    public void Use();
    public string GetName();
}
