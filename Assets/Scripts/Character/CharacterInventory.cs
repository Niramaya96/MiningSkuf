using Lessons;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    private ResourcesFeature _resouses;

    private void Awake()
    {
        var wood = new Resource(ResourseType.Wood);
        var iron = new Resource(ResourseType.Iron);
        var stone = new Resource(ResourseType.Stone);

        var res = new[] {wood, iron, stone};

        _resouses = new ResourcesFeature(res);

        _resouses.ResourceChanged += OnResourceChanged;
    }
    public void AddResource(ResourseType resourceType,int value)
    {
        _resouses.AddResource(resourceType, value);
    }
    public void SpendResource(ResourseType resourseType,int value)
    {
        bool hasRes = _resouses.HasResource(resourseType, value);

        if (hasRes)
        {
            _resouses.SpendResource(resourseType, value);
        }
    }
    private void OnResourceChanged(ResourseType type,int oldValue,int newValue)
    {
        Debug.Log($"Resource amount changed: {type} - {oldValue} - {newValue}");
    }

    private void OnDestroy()
    {
        _resouses.ResourceChanged -= OnResourceChanged;
    }
}
