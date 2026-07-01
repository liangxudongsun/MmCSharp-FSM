namespace MiMieFSM.Unity
{
    using System;
    using MiMieFSM.UpdateFsm;
    using UnityEngine;

    /// <summary>
    /// MonoBehaviour Tick 调度器
    /// </summary>
    public class FsmTickRunner : MonoBehaviour, IFsmTickScheduler
    {
        /// <summary>
        /// Update 事件
        /// </summary>
        private Action updateEvent;

        /// <summary>
        /// LateUpdate 事件
        /// </summary>
        private Action lateUpdateEvent;

        /// <summary>
        /// FixedUpdate 事件
        /// </summary>
        private Action fixedUpdateEvent;

        /// <summary>
        /// 注册 Update
        /// </summary>
        public void AddUpdateListener(Action action)
        {
            updateEvent += action;
        }

        /// <summary>
        /// 移除 Update
        /// </summary>
        public void RemoveUpdateListener(Action action)
        {
            updateEvent -= action;
        }

        /// <summary>
        /// 注册 LateUpdate
        /// </summary>
        public void AddLateUpdateListener(Action action)
        {
            lateUpdateEvent += action;
        }

        /// <summary>
        /// 移除 LateUpdate
        /// </summary>
        public void RemoveLateUpdateListener(Action action)
        {
            lateUpdateEvent -= action;
        }

        /// <summary>
        /// 注册 FixedUpdate
        /// </summary>
        public void AddFixedUpdateListener(Action action)
        {
            fixedUpdateEvent += action;
        }

        /// <summary>
        /// 移除 FixedUpdate
        /// </summary>
        public void RemoveFixedUpdateListener(Action action)
        {
            fixedUpdateEvent -= action;
        }

        private void Update()
        {
            updateEvent?.Invoke();
        }

        private void LateUpdate()
        {
            lateUpdateEvent?.Invoke();
        }

        private void FixedUpdate()
        {
            fixedUpdateEvent?.Invoke();
        }
    }
}
