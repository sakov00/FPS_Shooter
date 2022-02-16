using Assets.Scripts.Interfaces;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public abstract class Enemy : MonoBehaviour, IAttack
    {
        public int HPEnemy { get; set; }
        public int Speed { get; set; }

        public abstract void LongRangeAttackToPlayer();

        public abstract void MeleeAttackToPlayer();

        public abstract void SpecAttackToPlayer();

        public abstract void Move();

        public abstract void Jump();

        public abstract IEnumerator ReactToHit(Vector3 pushFrom, GameObject player);

    }
}
