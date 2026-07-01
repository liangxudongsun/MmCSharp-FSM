namespace MiMieFSM.Unity
{
    using MiMieFSM.UpdateFsm;
    using UnityEngine;

    /// <summary>
    /// UpdateFSM Game 视图调试绘制
    /// </summary>
    public class UpdateFsmDebugOverlay : MonoBehaviour
    {
        /// <summary>
        /// 单例实例
        /// </summary>
        private static UpdateFsmDebugOverlay instance;

        /// <summary>
        /// 运行时确保调试层存在
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void EnsureOverlay()
        {
            RefreshOverlay();
        }

        /// <summary>
        /// 刷新调试层
        /// </summary>
        public static void RefreshOverlay()
        {
            if (!UpdateFsmDebugSettings.Enabled)
            {
                if (instance != null)
                {
                    Destroy(instance.gameObject);
                    instance = null;
                }

                return;
            }

            if (instance != null)
                return;

            GameObject go = new GameObject("[MiMieFSM Debug Overlay]");
            DontDestroyOnLoad(go);
            instance = go.AddComponent<UpdateFsmDebugOverlay>();
        }

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void OnGUI()
        {
            if (!UpdateFsmDebugSettings.Enabled)
                return;

            GUIStyle style = new GUIStyle(GUI.skin.label)
            {
                fontSize = UpdateFsmDebugSettings.FontSize,
                fontStyle = FontStyle.Bold,
                normal = { textColor = UpdateFsmDebugSettings.TextColor }
            };

            Vector2 pos = UpdateFsmDebugSettings.ScreenPosition;
            float lineHeight = UpdateFsmDebugSettings.LineHeight;

            GUI.Label(new Rect(pos.x, pos.y, 800f, lineHeight), "UpdateFSM Debug", style);
            pos.y += lineHeight;

            foreach (UpdateFsmDebugRegistry.DebugEntry entry in UpdateFsmDebugRegistry.EntryList)
            {
                string stateText = entry.GetStateText != null ? entry.GetStateText.Invoke() : "None";
                GUI.Label(new Rect(pos.x, pos.y, 800f, lineHeight), $"{entry.Label}: {stateText}", style);
                pos.y += lineHeight;
            }
        }
    }
}
