using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : PullObject
{
    [SerializeField] private Material[] materials;

    [SerializeField] private GameObject prefab;

    protected Vector3 _posParent;

    private Rigidbody _rb;

    private float _scaleCube;

    public List<GameObject> ObjectInPull { get; private set; } = new List<GameObject>();

    public Material[] Materials { get { return materials; } }

    private void Awake()
    {
        InitializeSpawner();
    }

    /// <summary>
    /// Инициализирование спавнера пула объектов
    /// </summary>
    public void InitializeSpawner()
    {
        _posParent = transform.position;
        if (prefab != null)
        {
            InitializeObjectPull();
        }
    }

    /// <summary>
    /// Инициализируем пул объектов
    /// </summary>
    private void InitializeObjectPull()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject newCube = Instantiate(prefab, _posParent, Quaternion.identity);
            newCube.SetActive(false);

            CubeActor newActor = newCube.GetComponent<CubeActor>();
            newActor.Initialize(materials);

            newCube.transform.parent = transform;
            ObjectInPull.Add(newCube);
        }
    }

    /// <summary>
    /// Активация куба
    /// </summary>
    /// <param name="go"></param>
    public override void ActivateCube(GameObject cube)
    {
        SettingCube(cube);
        cube.SetActive(true);
    }

    /// <summary>
    /// Настройка куба
    /// </summary>
    /// <param name="cube">куб</param>
    public virtual void SettingCube(GameObject cube)
    {
        cube.transform.position = new Vector3(
            Random.Range(-4f, 4f), .35f, Random.Range(-4f, 4f));

        _scaleCube = Random.Range(.5f, 1.1f);
        cube.transform.localScale = new Vector3(_scaleCube, _scaleCube, _scaleCube);

        cube.GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Length)];

        _rb = cube.GetComponent<Rigidbody>();
        _rb.mass = Random.Range(.5f, 5f);
    }

    /// <summary>
    /// Ищем выключенный объект
    /// </summary>
    /// <returns></returns>
    protected GameObject FindDisableGameObject()
    {
        foreach (var item in ObjectInPull)
        {
            if (!item.activeSelf)
            {
                return item;
            }
        }
        return null;
    }
}
