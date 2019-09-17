namespace GameInterface
{
    using UnityEngine;

    public interface IAvatar
    {
        Animator animator { get; }
        Vector3 position { get; }

        void SetParamBool(int paramId, bool value);
        void SetParamFloat(int paramId, float value);
    }
}