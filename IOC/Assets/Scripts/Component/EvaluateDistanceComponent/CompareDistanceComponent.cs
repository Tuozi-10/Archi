using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    public class CompareDistanceComponent : Component
    {
        private Transform _firstPosition;
        private Transform _secondPosition;
        private float ValueToCompare;
        private event Func<float, bool> _compareFunction;
        public  void Init(Entity entity, CompareDistanceComponentData distanceData, Transform firstPosition, Transform secondPosition)
        {
            Init(entity);
            var data = distanceData;
            ValueToCompare = data.Distance;
            switch (data.TypeComparaison)
            {
                case CompareDistanceEnum.EQUALDISTANCE:
                {
                    _compareFunction = CheckEqualThanDistance;
                    break;
                }
                case CompareDistanceEnum.LONGERTHANDISTANCE:
                {
                    _compareFunction = CheckLongerThanDistance;
                    break;
                }
                case CompareDistanceEnum.SHORTERTHANTDISTANCE:
                {
                    _compareFunction = CheckShorterThanDistance;
                    break;
                }
            }

            _firstPosition = firstPosition;
            _secondPosition = secondPosition;
        }

        public float GetDistance()
        {
            return Vector3.Distance(_firstPosition.position, _secondPosition.position);
        }

        public bool CheckDistance()
        {
            var distance = GetDistance();
            return _compareFunction.Invoke(distance);
        }

        public bool CheckShorterThanDistance(float distance)
        {
            if (distance <= ValueToCompare)
            {
                return true;
            }

            return false;
        }

        public bool CheckLongerThanDistance(float distance)
        {
            if (distance >= ValueToCompare)
            {
                return true;
            }

            return false;
        }

        public bool CheckEqualThanDistance(float distance)
        {
            if (Math.Abs(distance - ValueToCompare) < 0.01f)
            {
                return true;
            }

            return false;
        }
    }
}