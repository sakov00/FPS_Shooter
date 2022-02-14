using Assets.Scripts;
using System;
using System.Collections;
using System.Threading;
using UnityEngine;

public class AIForEnemySolder : EnemySolder
{
    private float meleeRange = 4.0f;
    private int _count = 360;
    private bool hidfromplayer = false;
    private Vector3 Where_Was_Player;

    private Transform m_transform;
    private Bounds bounds;

    private void Start()
    {
        InvokeRepeating("MoveEnemySolder", 0, 5);
        m_transform = GetComponent<Transform>();
        bounds = GetComponent<MeshFilter>().sharedMesh.bounds;
    }

    private void Update()
    {
        float angleStep = 360 / _count;
        float need_radian = 1000f;
        double min_distance = 1000;
        var first_ray_corner_tan = Mathf.Atan2(Mathf.Clamp(m_transform.forward.x, -1, 1), Mathf.Clamp(m_transform.forward.z, -1, 1));
        for (int i = 0; i < _count; i++)
        {
            float angle = (i * angleStep);
            float radian = angle * Mathf.Deg2Rad;
            Vector3 direction = new Vector3(Mathf.Sin(first_ray_corner_tan + radian), 0, Mathf.Cos(first_ray_corner_tan + radian));
            RaycastHit hit;
            Physics.Raycast(m_transform.position, direction, out hit, 1000);
            Player find_player = hit.transform?.gameObject?.GetComponent<Player>();
            if (hit.distance < min_distance && hit.distance != 0)
            {
                min_distance = hit.distance;
                need_radian = radian;
            }
            if (find_player != null && hit.distance < meleeRange)
            {
                hidfromplayer = true;
                MeleeAttackToPlayer();
                need_radian = radian;
                break;
            }
            else
            {
                hidfromplayer = false;
            }
        }
        if (hidfromplayer)
            m_transform.Translate(0, 0, Speed * Time.deltaTime);
        m_transform.Rotate(0, need_radian / Mathf.Deg2Rad, 0);
    }
}
