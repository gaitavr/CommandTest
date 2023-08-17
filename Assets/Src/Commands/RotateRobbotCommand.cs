using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using Company.Project.Environment;

namespace Company.Project.Core.Commands
{
    public sealed class RotateRobbotCommand : BaseCommand
    {
        [SerializeField] private Robbot _robbot;
        [SerializeField] private Vector3 _rotation;

        public override async Task Execute(CancellationToken cancellationToken)
        {
            var rotationDelta = _rotation - _robbot.Transform.rotation.eulerAngles;

            var t = 0.0f;
            while (t < _executionDuration)
            {
                if (cancellationToken.IsCancellationRequested)
                    return;

                _robbot.Transform.Rotate(rotationDelta * Time.deltaTime / _executionDuration, Space.World);
                t += Time.deltaTime;

                await Task.Yield();
            }

            _robbot.Transform.eulerAngles = _rotation;
        }
    }
}