using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryBoard : MonoBehaviour
{
    [SerializeField]
    private GameObject accessoryPrefab;

    [SerializeField]
    private List<AccessorySO> items = new List<AccessorySO>();

    private List<GameObject> accessorys = new List<GameObject>();

    private void Start()
    {
        foreach (AccessorySO accessorySO in items)
        {
            var instance = Instantiate(accessoryPrefab);
            instance.transform.SetParent(this.transform);
            instance.GetComponent<AccessoryItem>().LoadAccessorySOData(accessorySO);
            instance.GetComponent<AccessoryItem>().SetAccessoryBoard(this);
            instance.GetComponent<RectTransform>().localScale = new Vector3(2f, 2f, 2f);
            accessorys.Add(instance);
        }
    }

    public void RemoveAccessory(GameObject accessory)
    {
        accessorys.Remove(accessory);
        Destroy(accessory);
    }
}
