using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class CubeActor : MonoBehaviour
{
    private Rigidbody _rb;

    private MeshRenderer cubeRenderer;

    private Material[] Materials { get; set; }


    public void Initialize(Material[] materials)
    {
        Materials = materials;
        _rb = GetComponent<Rigidbody>();
        SettingCube();
    }

    /// <summary>
    /// При нажатой ПКМ - отключаем объект под мышью
    /// </summary>
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (gameObject.GetComponent<CubeActor>())
            {
                gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// При ззажатой лкм - куб передвигается за мышью
    /// </summary>
    private void OnMouseDrag()
    {
        RaycastHit _hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hit))
        {
            Vector3 _newPos = _hit.point;
            _rb.MovePosition(new Vector3(_newPos.x, .4f, _newPos.z));
        }
    }

    /// <summary>
    /// Настройка кубов
    /// </summary>
    public void SettingCube()
    {
        Debug.Log("material: " + Materials[Random.Range(0, Materials.Length)]);

        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        cubeRenderer = meshRenderer;

        ChangeColor();

        gameObject.SetActive(true);
    }

    /// <summary>
    /// Смена цвета у куба
    /// </summary>
    public void ChangeColor()
    {
        cubeRenderer.material = Materials[Random.Range(0, Materials.Length)];
    }

    /// <summary>
    /// При столкновении кубов - меняем цвета у обоих
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out CubeActor cubeActor))
        {
            ChangeColor();
            cubeActor.ChangeColor();
        }
    }
}
