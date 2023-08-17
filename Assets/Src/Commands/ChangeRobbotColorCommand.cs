using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using Company.Project.Environment;

namespace Company.Project.Core.Commands
{
    public sealed class ChangeRobbotColorCommand : BaseCommand
    {
        [SerializeField] private Robbot _robbot;
        [SerializeField] private Color _color;

        public override async Task Execute(CancellationToken cancellationToken)
        {
            var t = 0.0f;
            while (t < _executionDuration)
            {
                if (cancellationToken.IsCancellationRequested)
                    return;

                var initialColor = _robbot.Renderer.material.color;
                var currentColor = Color.Lerp(initialColor, _color, t / _executionDuration);
                _robbot.Renderer.material.color = currentColor;
                t += Time.deltaTime;

                await Task.Yield();
            }
            _robbot.Renderer.material.color = _color;
        }
    }
}

