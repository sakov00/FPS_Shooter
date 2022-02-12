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
    }

    // Update is called once per frame
    private void Update()
    {
    }

    internal override IEnumerator ReactToHit(Vector3 pushFrom, GameObject player)
    {
        HPEnemy -= 20;
        if (HPEnemy <= 0)
        {
            var pushDirection = Vector3.Normalize(pushFrom - player.transform.position);
            _rBody.AddForce(pushDirection * 500);
            yield return new WaitForSeconds(10);
            if(this != null)
                Destroy(gameObject);
        }
    }

    internal override void AttackToPlayer()
    {
        Debug.Log("shoot to player");
    }

    internal override void SpecAttackToPlayer()
    {
        throw new System.NotImplementedException();
    }

    internal override void Move()
    {
        throw new System.NotImplementedException();
    }

    internal override void Jump()
    {
        throw new System.NotImplementedException();
    }
}
