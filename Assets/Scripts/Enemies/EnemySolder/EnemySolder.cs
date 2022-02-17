using Assets.Scripts.Enemies;
using System.Collections;
using UnityEngine;

public class EnemySolder : Enemy
{
    private Rigidbody _rBody;

    private void Start()
    {
        _rBody = GetComponent<Rigidbody>();
        HPEnemy = 100;
        Speed = 5;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void Hide_Behind_Cover()
    {
        transform.localScale= Vector3.one;
    }

    public void Unhide_Behind_Cover()
    {
        transform.localScale = new Vector3(1,2,1);
    }

    public override void ReactToHit(RaycastHit hit, int damage)
    {
        HPEnemy -= damage;
        if (HPEnemy <= 0)
        {
            var pushDirection = Vector3.Normalize(hit.point - gameObject.transform.position);
            _rBody.AddForce(pushDirection * 500);
            if(gameObject != null)
                Destroy(gameObject);
        }
    }

    public override void LongRangeAttack(RaycastHit hit, int damage)
    {
        Debug.Log("shoot to player");
        GeneralPlayer player = hit.transform?.gameObject?.GetComponent<GeneralPlayer>();
        player.ReactToHit(hit, damage);
    }

    public override void MeleeAttack(RaycastHit hit, int damage)
    {
        Debug.Log("shoot to player");
    }

    public override void SpecAttack(RaycastHit hit, int damage)
    {
        throw new System.NotImplementedException();
    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

    public override void Jump()
    {
        throw new System.NotImplementedException();
    }
}
