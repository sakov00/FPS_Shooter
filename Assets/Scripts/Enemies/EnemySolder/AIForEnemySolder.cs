using Assets.Scripts;
using System;
using System.Collections;
using System.Threading;
using UnityEngine;

public class AIForEnemySolder : EnemySolder
{
    private float speed = 5.0f;
    public float obstacleRange = 1.0f;
    private int _count = 360;
    bool hidfromplayer = false;
    Vector3 direction = Vector3.zero;

    private void Start()
    {
        InvokeRepeating("MoveEnemySolder", 0, 3);
    }

    private void Update()
    {
        //if (hidfromplayer)
        //transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void MoveEnemySolder()
    {
        float angleStep = 360 / _count;
        float need_radian = 1000f;
        double min_distance = 1000;
        for (int i = 0; i < _count; i++)
        {
            float angle = i * angleStep;
            float radian = angle * Mathf.Deg2Rad;
            RaycastHit hit;
            direction.x = Mathf.Cos(radian) * 200;
            direction.z = Mathf.Sin(radian) * 200;
            Physics.Raycast(transform.position, transform.position + direction, out hit);
            var distance = GeneralFunctions.Distance_Between_Vectors_Horizontal(hit.point, transform.position);
            Player find_player = hit.transform?.gameObject?.GetComponent<Player>();
            if (distance < min_distance && distance != 0)
            {
                min_distance = distance;
                need_radian = radian;
            }
            if (find_player != null)
            {
                hidfromplayer = true;
                AttackToPlayer();
                need_radian = radian;
                break;
            }
            else
            {
                hidfromplayer = false;
            }
        }
        transform.Rotate(0, need_radian / Mathf.Deg2Rad, 0);
    }
}
