#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
public static class ScenesList
{
    [MenuItem("Scenes/DialogExample")]
    public static void Assets_GameMain_Example_DialogExample_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Example/DialogExample.unity"); }
    [MenuItem("Scenes/GameMain")]
    public static void Assets_GameMain_Scenes_GameMain_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/GameMain.unity"); }
}
#endif
