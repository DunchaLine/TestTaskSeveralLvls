using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewCube : ActivateCubesOnStart
{
    private GameObject _nullGameObject;
    private Vector3 _mousePos;
    private float _scale;
    void Start()
    {
        base.LoadPrefab();
        foreach(var item in base._pull)
        {
            base.ActivateCube(item);
        }
    }

    void OnMouseDown()
    {
        _nullGameObject = base.FindNull();
        if (_nullGameObject != null)
        {
            ActivateCube(_nullGameObject);
        }
    }
    public override void ActivateCube(GameObject go)
    {
        _mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        go.transform.localPosition = new Vector3(_mousePos.x, .35f, _mousePos.z);
        base.SpecificationsCube(go);
        go.SetActive(true);
    }
}
