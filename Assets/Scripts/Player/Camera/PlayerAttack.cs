using Assets.Scripts.Enemies;
using Assets.Scripts.Interfaces;
using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IAttack
{
    private new Camera camera;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }
    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
            return;
        Vector3 point = new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2, 0);
        RaycastHit hit;
        if (!Physics.Raycast(camera.ScreenPointToRay(point), out hit))
            return;
        EnemySolder enemy_soldier = hit.transform.gameObject.GetComponent<EnemySolder>();
        LongRangeAttack(hit, 10);
        if (enemy_soldier == null)
            return;
        enemy_soldier.ReactToHit(hit, 10);
    }

    public void LongRangeAttack(RaycastHit hit, int damage)
    {
        var enemy = hit.transform?.gameObject?.GetComponent<Enemy>();
        if (enemy == null)
            return;
    }

    public void MeleeAttack(RaycastHit hit, int damage)
    {
        var enemy = hit.transform?.gameObject?.GetComponent<Enemy>();
        if (enemy == null)
            return;
    }

    public void SpecAttack(RaycastHit hit, int damage)
    {
        var enemy = hit.transform?.gameObject?.GetComponent<Enemy>();
        if (enemy == null)
            return;
    }
}
