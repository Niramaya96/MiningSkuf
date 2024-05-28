using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourcesFeature 
{
    public readonly Dictionary<ResourseType, Resource> _resources;

    public event Action<ResourseType, int, int> ResourceChanged;

    public ResourcesFeature(Resource[] resources)
    {
        _resources = resources.ToDictionary(r => r.ResourseType);
    }

    public void AddResource(ResourseType type,int value)
    {
        var res = _resources[type];

        res.Amount += value;
    }
    public void SpendResource(ResourseType type, int value)
    {
        var res = _resources[type];

        res.Amount -= value;
    }
    public bool HasResource(ResourseType type, int value)
    {
        var res = _resources[type];

        return res.Amount >= value;
    }

    public string GetResourceString(ResourseType type)
    {
        return _resources[type].Amount.ToString();
    }


}
