namespace GameInterface
{
    using UnityEngine;

    using GameUtils;

    public interface IAvatar : IPoolable
    {
        Animator animator { get; set; }
        Transform transform { get; set; }
        Vector3 position { get; set; }
        Vector3 forward { get; set; }
    }
}