#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
public static class ScenesList
{
    [MenuItem("Scenes/DialogExample")]
    public static void Assets_GameMain_Example_DialogExample_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Example/DialogExample.unity"); }
    [MenuItem("Scenes/SceneA")]
    public static void Assets_GameMain_Example_SceneExample_SceneA_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Example/SceneExample/SceneA.unity"); }
    [MenuItem("Scenes/SceneB")]
    public static void Assets_GameMain_Example_SceneExample_SceneB_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Example/SceneExample/SceneB.unity"); }
    [MenuItem("Scenes/SceneC")]
    public static void Assets_GameMain_Example_SceneExample_SceneC_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Example/SceneExample/SceneC.unity"); }
    [MenuItem("Scenes/GameMain")]
    public static void Assets_GameMain_Scenes_GameMain_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/GameMain.unity"); }
}
#endif
