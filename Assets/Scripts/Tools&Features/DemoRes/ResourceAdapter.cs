using Lessons;
using System;
using UnityEngine;

public class ResourceAdapter : MonoBehaviour
{
    [SerializeField] private ResourseType _type;
    [SerializeField] private int _amount;

    private Resource Resource;

    public ResourseType Type => _type;

    private void Awake()
    {
        Resource = new Resource(_type,_amount);
    }

    public int Gather()
    {
        int gatherAmount = UnityEngine.Random.Range(0, 5);
        
        if(Resource.Amount <= gatherAmount) 
        {
            int allLeft = Resource.Amount;
            Resource.Amount = 0;
            Destroy(gameObject);
            return allLeft;
        }

        Resource.Amount -= gatherAmount;
        return gatherAmount;
    }
}
