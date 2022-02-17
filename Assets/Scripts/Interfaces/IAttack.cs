using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IAttack
    {

        void LongRangeAttack(RaycastHit hit, int damage);

        void MeleeAttack(RaycastHit hit, int damage);

        void SpecAttack(RaycastHit hit, int damage);
    }
}
