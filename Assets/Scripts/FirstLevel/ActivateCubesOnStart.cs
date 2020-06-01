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
    //загружаем префаб и если он не null, то создаем пул из 10 объектов
    public void LoadPrefab()
    {
        prefab = Resources.Load<GameObject>("Prefabs/FirstLvl/NormalCube");
        _posParent = transform.position;
        if (prefab != null)
        {
            Instance();
        }
    }
    //Создаем пул из 10 объектов
    void Instance()
    {
        for(int i = 0; i < 10; i++)
        {
            var instance = (GameObject)Instantiate(prefab, _posParent, Quaternion.identity);
            instance.SetActive(false);
            instance.transform.parent = transform;
            _pull.Add(instance);
        }
    }
    //активируем каждый куб с рандомным размером, массой, цветом, местоположением
    public override void ActivateCube(GameObject go)
    {
        go.transform.position = new Vector3(
            Random.Range(-4f, 4f), .35f, Random.Range(-4f, 4f));
        SpecificationsCube(go);
        go.SetActive(true);
    }
    //Характеристики куба
    public virtual void SpecificationsCube(GameObject go)
    {
        _scaleCube = Random.Range(.5f, 1.1f);
        go.transform.localScale = new Vector3(_scaleCube, _scaleCube, _scaleCube);
        go.GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Length)];
        _rb = go.GetComponent<Rigidbody>();
        _rb.mass = Random.Range(.5f, 5f);
    }
    //ищем нулевой объект
    protected GameObject FindNull()
    {
        foreach (var item in _pull)
        {
            if (!item.activeSelf)
            {
                return item;
            }
        }
        return null;
    }
}
