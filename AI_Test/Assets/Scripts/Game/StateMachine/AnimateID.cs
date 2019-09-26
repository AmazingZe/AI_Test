namespace GamePlay
{
    using UnityEngine;

    public static class AnimateStateID
    {
        public static int IdleStand = Animator.StringToHash("female_idle_breath");
        public static int IdleTired = Animator.StringToHash("female_idle_pant");
        public static int IdleAlarm = Animator.StringToHash("female_idle_strafing");
        public static int IdleRest = Animator.StringToHash("female_idle_meditate");
    }

    public static class AnimateParam
    {
        public static int IsTired = Animator.StringToHash("isTired");
        public static int IsRest = Animator.StringToHash("isRest");
        public static int IsAlarm = Animator.StringToHash("isAlarm");
        public static int SpeedV = Animator.StringToHash("speedV");
    }
}