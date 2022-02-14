using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        public int HPEnemy { get; set; }
        public int Speed { get; set; }

        internal abstract void LongRangeAttackToPlayer();

        internal abstract void MeleeAttackToPlayer();

        internal abstract void SpecAttackToPlayer();

        internal abstract void Move();

        internal abstract void Jump();

        internal abstract IEnumerator ReactToHit(Vector3 pushFrom, GameObject player);

    }
}
