using UnityEngine;

public class AIForEnemySolder : MonoBehaviour
{
    private float meleeRange = 4.0f;
    private int _count = 360;
    private bool hidfromplayer = false;

    private Transform m_transform;
    private EnemySolder enemy_solder;

    private void Start()
    {
        InvokeRepeating("AIMovement", 0, 0.2f);
        m_transform = GetComponent<Transform>();
        enemy_solder = GetComponent<EnemySolder>();
    }

    private void Update()
    {
        if (hidfromplayer)
        {
            m_transform.Translate(0, 0, enemy_solder.Speed * Time.deltaTime);
        }
    }

    private void AIMovement()
    {
        int angleStep = 1;
        float min_distance = 1000;
        float need_radian = 0;
        var first_ray_corner_tan = Mathf.Atan2(Mathf.Clamp(m_transform.forward.x, -1, 1), Mathf.Clamp(m_transform.forward.z, -1, 1));
        for (int i = 0; i < _count; i++)
        {
            int angle = (i * angleStep);
            float radian = angle * Mathf.Deg2Rad;
            Vector3 direction = new Vector3(Mathf.Sin(first_ray_corner_tan + radian), 0, Mathf.Cos(first_ray_corner_tan + radian));
            RaycastHit hit;
            Physics.Raycast(m_transform.position, direction, out hit, 1000);
            GeneralPlayer find_player = hit.transform?.gameObject?.GetComponent<GeneralPlayer>();
            if (hit.distance < min_distance && hit.distance != 0)
            {
                min_distance = hit.distance;
                need_radian = radian;
            }
            if (find_player != null)
            {
                hidfromplayer = true;
                enemy_solder.MeleeAttackToPlayer();
                need_radian = radian;
                break;
            }
            else
            {
                hidfromplayer = false;
            }
        }
        m_transform.Rotate(0, need_radian / Mathf.Deg2Rad, 0);
    }
}
