using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class GeneralFunctions
    {
        public static double Distance_Between_Vectors(Vector3 first_vector, Vector3 second_vector)
        {
            return Math.Pow(first_vector.x - second_vector.x, 2) + Math.Pow(first_vector.y - second_vector.y, 2) + Math.Pow(first_vector.z - second_vector.z, 2);
        }
    }
}
