using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using Company.Project.Environment;

namespace Company.Project.Core.Commands
{
    public sealed class MoveRobbotToCommand : BaseCommand
    {
        [SerializeField] private Robbot _robbot;
        [SerializeField] private Vector3 _destination;

        public override async Task Execute(CancellationToken cancellationToken)
        {
            var translateVector = _destination - _robbot.Transform.position;

            var t = 0.0f;
            while (t < _executionDuration)
            {
                if (cancellationToken.IsCancellationRequested)
                    return;

                _robbot.Transform.Translate(translateVector * Time.deltaTime / _executionDuration, Space.World);
                t += Time.deltaTime;

                await Task.Yield();
            }

            _robbot.Transform.position = _destination;
        }
    }
}
