using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using Company.Project.Environment;

namespace Company.Project.Core.Commands
{
    public sealed class PlayHappyRobbotCommand : BaseCommand
    {
        [SerializeField] private Robbot _robbot;
        [SerializeField] private Texture2D _noiseTexture;

        public override async Task Execute(CancellationToken cancellationToken)
        {
            var newMaterial = new Material(Shader.Find("Unlit/HappyRobbotShader"));
            newMaterial.SetTexture("_NoiseTex", _noiseTexture);
            var color = Random.ColorHSV();
            newMaterial.SetColor("NoiseColor", color);

            var initialMaterial = _robbot.Renderer.sharedMaterial;
            _robbot.Renderer.material = newMaterial;

            var t = 0f;
            while (t < _executionDuration)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                var normalMultiplier = Mathf.Sin(t);
                newMaterial.SetFloat("NormalMultiplier", normalMultiplier);
                
                t += Time.deltaTime;
                await Task.Yield();
            }

            DestroyImmediate(newMaterial);
            _robbot.Renderer.material = initialMaterial;
        }
    }
}
