
using UnityEngine;

public interface IPickable 
{
    void SetPosition(Transform parent);
    Transform GetTransform();
    Collider GetCollider();
}
