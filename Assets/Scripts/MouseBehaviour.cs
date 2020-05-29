using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehaviour : MonoBehaviour
{
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (gameObject.CompareTag("Cube"))
            {
                gameObject.SetActive(false);
            }            
        }
    }
    // public override void DeactivateCube()
    // {
    //     gameObject.SetActive(false);
    //     //ActivateCube(gameObject);
    // }
    // public override void ActivateCube(GameObject go)
    // {
    //     foreach(var item in _pull)
    //     {
    //         if (item == null)
    //         {
    //             go.transform.position = new Vector3(
    //                 Random.Range(-4f, 4f), .35f, Random.Range(-4f, 4f));
                
    //         }
    //     }
        
    // }
}
