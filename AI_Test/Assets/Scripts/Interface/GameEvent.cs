namespace GameInterface
{
    using UnityEngine.Events;

    public class GameEvent : UnityEvent { }

    public class GameEvent<T> : UnityEvent<T> { }

    public class GameEvent<T1, T2> : UnityEvent<T1, T2> { }
}