using Lessons;
using System;
using UnityEngine;

public class ResourceAdapter : MonoBehaviour
{
    [SerializeField] private ResourseType _type;
    [SerializeField] private int _amount;

    private IResource Resource;

    public ResourseType Type => _type;

    private void Awake()
    {
        Resource = new Resource(_type,_amount);
    }
}
