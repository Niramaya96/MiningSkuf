using System;
using UnityEngine;

public class ResourceV2 : MonoBehaviour
{
    [SerializeField] private string Name;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Добыто {Name}");

    }
}
