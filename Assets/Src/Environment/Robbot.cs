using UnityEngine;

namespace Company.Project.Environment
{
    public class Robbot : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Renderer _renderer;

        public Transform Transform => _transform;
        public Renderer Renderer => _renderer;
    }
}
