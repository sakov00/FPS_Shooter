using Assets.Scripts.Interfaces;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public abstract class Enemy : MonoBehaviour, IAttack, IReactionToHit
    {
        public int HPEnemy { get; set; }
        public int Speed { get; set; }

        public abstract void LongRangeAttack(RaycastHit hit, int damage);

        public abstract void MeleeAttack(RaycastHit hit, int damage);

        public abstract void SpecAttack(RaycastHit hit, int damage);

        public abstract void Move();

        public abstract void Jump();

        public abstract void ReactToHit(RaycastHit hit, int damage);

    }
}
