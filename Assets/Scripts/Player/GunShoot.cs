using System.Collections;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
        RaycastHit hit;

        if (!Physics.Raycast(_camera.ScreenPointToRay(point), out hit))
            return;

        EnemySolder target = hit.transform.gameObject.GetComponent<EnemySolder>();

        if (target != null)
        {
            StartCoroutine(target.ReactToHit(hit.point, gameObject));
        }
    }
}
