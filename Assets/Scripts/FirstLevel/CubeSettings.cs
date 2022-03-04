using UnityEngine;

public class CubeSettings : CubeSpawner
{
    private GameObject _nullGameObject;

    //при нажатии на лкм ищем нулевой объект и спауним его
    void OnMouseDown()
    {
        _nullGameObject = base.FindDisableGameObject();
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
        base.SettingCube(go);
        go.SetActive(true);
    }
}
