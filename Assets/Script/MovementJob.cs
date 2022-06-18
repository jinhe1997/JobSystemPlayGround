using UnityEngine;
using UnityEngine.Jobs;
using Unity.Burst;
namespace PeterLab
{
    [BurstCompile]
    public struct MovementJob : IJobParallelForTransform
    {
        public float moveSpeed;
        public float topBound;
        public float bottomBound;
        public float deltaTime;
        public void Execute(int index, TransformAccess transform)
        {
            Vector3 position = transform.position;
            position += moveSpeed * deltaTime * new Vector3(0 , 0, 1);
            if (position.z > bottomBound) position.z = topBound;
            transform.position = position;
        }
    }
}
