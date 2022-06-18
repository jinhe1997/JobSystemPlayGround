using UnityEngine;
using UnityEngine.Jobs;
using Unity.Jobs;
namespace PeterLab
{
    public class GameManager : MonoBehaviour
    {
        TransformAccessArray transforms;
        [SerializeField] Transform[] moveTargets;
        MovementJob movementJob;
        JobHandle movementJobHandle;
        [SerializeField] float Speed;
        [SerializeField] float TopBound;
        [SerializeField] float BottomBound;
        void Start()
        {
            transforms = new TransformAccessArray(moveTargets);
        }

        void Update()
        {
            movementJob = new MovementJob()
            {
                moveSpeed = Speed,
                topBound = TopBound,
                bottomBound = BottomBound,
                deltaTime = Time.deltaTime
            };
            movementJobHandle = movementJob.Schedule(transforms);
            JobHandle.ScheduleBatchedJobs();
        }

        private void OnDestroy()
        {
            transforms.Dispose();
        }

    }
}