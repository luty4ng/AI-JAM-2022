#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
public static class ScenesList
{
    [MenuItem("Scenes/DialogExample")]
    public static void Assets_GameMain_Example_DialogExample_DialogExample_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Example/DialogExample/DialogExample.unity"); }
    [MenuItem("Scenes/SceneA")]
    public static void Assets_GameMain_Example_SceneExample_SceneA_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Example/SceneExample/SceneA.unity"); }
    [MenuItem("Scenes/SceneB")]
    public static void Assets_GameMain_Example_SceneExample_SceneB_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Example/SceneExample/SceneB.unity"); }
    [MenuItem("Scenes/SceneC")]
    public static void Assets_GameMain_Example_SceneExample_SceneC_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Example/SceneExample/SceneC.unity"); }
    [MenuItem("Scenes/GameMenu")]
    public static void Assets_GameMain_Scenes_GameMenu_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/GameMenu.unity"); }
    [MenuItem("Scenes/SceneID_ 0")]
    public static void Assets_GameMain_Scenes_SceneID__0_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/SceneID_ 0.unity"); }
    [MenuItem("Scenes/SceneID_ 1")]
    public static void Assets_GameMain_Scenes_SceneID__1_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/SceneID_ 1.unity"); }
    [MenuItem("Scenes/SceneID_ 2")]
    public static void Assets_GameMain_Scenes_SceneID__2_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/SceneID_ 2.unity"); }
    [MenuItem("Scenes/SceneID_ 3")]
    public static void Assets_GameMain_Scenes_SceneID__3_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/SceneID_ 3.unity"); }
    [MenuItem("Scenes/SceneID_ 4")]
    public static void Assets_GameMain_Scenes_SceneID__4_unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/SceneID_ 4.unity"); }
    [MenuItem("Scenes/SceneID_")]
    public static void Assets_GameMain_Scenes_SceneID__unity() { ScenesUpdate.OpenScene("Assets/GameMain/Scenes/SceneID_.unity"); }
}
#endif
