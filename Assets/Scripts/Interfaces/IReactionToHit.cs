using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IReactionToHit
    {
        void ReactToHit(RaycastHit hit, int damage);
    }
}
