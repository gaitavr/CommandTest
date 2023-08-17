using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Company.Project.Core.Commands
{
    public abstract class BaseCommand : MonoBehaviour
    {
        [SerializeField, Range(0.0f, 10.0f)] protected float _executionDuration;

        public abstract Task Execute(CancellationToken cancellationToken);
    }
}
