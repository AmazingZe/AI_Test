namespace GameInterface
{
    using UnityEngine;

    public interface IAvatar
    {
        Animator animator { get; }
        Transform transform { get; }
    }
}