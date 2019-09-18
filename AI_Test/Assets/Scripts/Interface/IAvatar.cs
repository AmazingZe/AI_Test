namespace GameInterface
{
    using UnityEngine;

    public interface IAvatar : IPoolable
    {
        Animator animator { get; set; }
        Transform transform { get; set; }
        Vector3 position { get; set; }

        void SetParamBool(int paramId, bool value);
        void SetParamFloat(int paramId, float value);
    }
}