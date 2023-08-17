using UnityEngine;
using System.Threading;
using System;

namespace Company.Project.Core.Play
{
    public sealed class ScenarioPlayer : MonoBehaviour
    {
        [SerializeField] private Scenario.PlayType _playType;
        [SerializeField] private EditorScenarioProvider _editorScenario;

        private CancellationTokenSource _cts;

        private async void Start()
        {
            try
            {
                _cts = new CancellationTokenSource();
                var scenarioProvider = _editorScenario;
                var scenario = scenarioProvider.GetScenario();
                await scenario.Play(_cts.Token, _playType);
            }
            catch (Exception e)
            {
                Debug.LogError($"Player exception: {e.Message}");
            }
        }

        private void OnDestroy()
        {
            _cts.Cancel();
        }
    }
}
