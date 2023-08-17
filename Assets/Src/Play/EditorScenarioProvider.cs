using UnityEngine;
using Company.Project.Core.Commands;
using System.Linq;

namespace Company.Project.Core.Play
{
    public sealed class EditorScenarioProvider : MonoBehaviour, IScenarioProvider
    {

        public Scenario GetScenario()
        {
            var commands = GetComponentsInChildren<BaseCommand>().ToList();
            var scenario = new Scenario(commands);
            return scenario;
        }
    }
}
