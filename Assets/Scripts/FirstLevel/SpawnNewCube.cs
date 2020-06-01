using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewCube : ActivateCubesOnStart
{
    private GameObject _nullGameObject;
    //Загружаем на сцену пул объектов с загруженным заранее префабом
    void Awake()
    {
        base.LoadPrefab();
        foreach(var item in base._pull)
        {
            base.ActivateCube(item);
        }
    }

    //при нажатии на лкм ищем нулевой объект и спауним его
    void OnMouseDown()
    {
        _nullGameObject = base.FindNull();
        if (_nullGameObject != null)
        {
            ActivateCube(_nullGameObject);
        }
    }
    //активируем куб на позиции курсора
    public override void ActivateCube(GameObject go)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            go.transform.localPosition = new Vector3(hit.point.x, .35f, hit.point.z);
        }
        base.SpecificationsCube(go);
        go.SetActive(true);
    }
}
