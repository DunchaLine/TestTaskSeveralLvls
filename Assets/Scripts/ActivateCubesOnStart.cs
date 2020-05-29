using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ActivateCubesOnStart : PullObject
{
    protected GameObject prefab;
    protected Vector3 _posParent;
    public Material[] materials;
    private Material _tmpMaterial;
    [HideInInspector]public List<GameObject> _pull = new List<GameObject>();
    private Rigidbody _rb;
    private float _scaleCube;
    private bool _firstTime = false;
    public void LoadPrefab()
    {
        prefab  = Resources.Load<GameObject>("Prefabs/NormalCube");
        _posParent = transform.position;
        if (prefab != null)
        {
            Debug.Log("prefab != null");
            Instance();
        }
    }

    void Instance()
    {
        for(int i = 0; i < 10; i++)
        {
            var instance = (GameObject)Instantiate(prefab, _posParent, Quaternion.identity);
            instance.SetActive(false);
            instance.transform.parent = transform;
            _pull.Add(instance);
        }
        // foreach(var item in _pull)
        // {
        //     ActivateCube(item);
        // }
    }
    public override void ActivateCube(GameObject go)
    {
        Debug.Log("asd");
        go.transform.position = new Vector3(
            Random.Range(-4f, 4f), .35f, Random.Range(-4f, 4f));
        SpecificationsCube(go);
        go.SetActive(true);
    }
    protected void SpecificationsCube(GameObject go)
    {
        _scaleCube = Random.Range(.5f, 1.1f);
        go.transform.localScale = new Vector3(_scaleCube, _scaleCube, _scaleCube);
        go.GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Length - 1)];
        _rb = go.GetComponent<Rigidbody>();
        _rb.mass = Random.Range(.5f, 5f);
    }
    protected GameObject FindNull()
    {
        Debug.Log("in findnull: " + _pull.Count);
        foreach (var item in _pull)
        {
            Debug.Log("in foreach: " + item.activeSelf);
            if (!item.activeSelf)
            {
                Debug.Log("here we go");
                return item;
            }
        }
        return null;
    }
}
