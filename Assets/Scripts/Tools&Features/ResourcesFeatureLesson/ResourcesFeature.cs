using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Lessons
{
    public class ResourcesFeature
    {
        public readonly Dictionary<ResourceType, Resource> _resources;

        public event Action<ResourceType, int, int> ResourceChanged;

        public ResourcesFeature(Resource[] resources)
        {
            _resources = resources.ToDictionary(r => r.ResourseType);

            foreach(var res in resources) 
            {
                res.Changed += delegate (int oldValue, int newValue)
                {
                    ResourceChanged?.Invoke(res.ResourseType, oldValue, newValue);
                };
            }
        }

        public void AddResource(ResourceType type, int value)
        {
            var res = _resources[type];

            res.Amount += value;
        }
        public void SpendResource(ResourceType type, int value)
        {
            var res = _resources[type];

            res.Amount -= value;
        }
        public bool HasResource(ResourceType type, int value)
        {
            var res = _resources[type];

            return res.Amount >= value;
        }

        public string GetResourceString(ResourceType type)
        {
            return _resources[type].Amount.ToString();
        }


    }

}
