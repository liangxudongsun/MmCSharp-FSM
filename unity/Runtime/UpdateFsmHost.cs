namespace MiMieFSM.Unity
{
    using MiMieFSM.UpdateFsm;
    using UnityEngine;

    /// <summary>
    /// UpdateFSM 宿主组件
    /// </summary>
    public class UpdateFsmHost : MonoBehaviour
    {
        [SerializeField]
        private string debugLabel = "FSM";

        /// <summary>
        /// 状态机实例
        /// </summary>
        public StateMachine Machine { get; private set; }

        /// <summary>
        /// Tick 调度器
        /// </summary>
        private FsmTickRunner tickRunner;

        /// <summary>
        /// 调试键
        /// </summary>
        private string debugKey;

        private void Awake()
        {
            tickRunner = GetComponent<FsmTickRunner>();
            if (tickRunner == null)
                tickRunner = gameObject.AddComponent<FsmTickRunner>();

            Machine = new StateMachine();
            Machine.Init(tickRunner, new FsmBlackboard());
        }

        private void OnEnable()
        {
            debugKey = string.IsNullOrWhiteSpace(debugLabel) ? name : debugLabel;
            UpdateFsmDebugRegistry.Register(debugKey, () => Machine?.CurrentStateName ?? "None");
        }

        private void OnDisable()
        {
            if (!string.IsNullOrEmpty(debugKey))
                UpdateFsmDebugRegistry.Unregister(debugKey);
        }

        private void OnDestroy()
        {
            Machine?.Stop();
        }
    }
}
