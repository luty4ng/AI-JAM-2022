using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using DG.Tweening;
namespace GameKit
{
    public enum SceneSwitchType
    {
        Swipe,
        Fade,
        Immediately
    }
    public delegate void SceneAction();
    [DisallowMultipleComponent]
    [AddComponentMenu("GameKit/GameKit Scheduler")]
    public class Scheduler : MonoSingletonBase<Scheduler>
    {
        public SceneSwitchType defaultSwitchType = SceneSwitchType.Swipe;
        public string StartScene = "GameKit_Main";
        private Switcher switcher;
        public string CurrentScene
        {
            get;
            private set;
        }

        protected override void OnAwake()
        {
            if (SceneManager.sceneCount > 1)
                CurrentScene = SceneManager.GetSceneAt(1).name;
            else
                LoadSceneAsyn(StartScene, callback: () => { CurrentScene = StartScene; });
            switcher = GetComponentInChildren<Switcher>();
        }
        public void SwitchSceneByDefault(string name, UnityAction callback = null)
        {
            if (defaultSwitchType == SceneSwitchType.Swipe)
                SwitchSceneBySwipe(name, callback);
            else if (defaultSwitchType == SceneSwitchType.Fade)
                SwitchSceneByFade(name, callback);
            else if (defaultSwitchType == SceneSwitchType.Immediately)
                SwitchScene(name, callback);
        }

        public void SwitchSceneBySwipe(string name, UnityAction callback = null)
        {
            switcher.swiper.gameObject.SetActive(true);
            switcher.swiper.DOLocalMoveX(0, 0.5f).OnComplete(() =>
            {
                UnloadSceneAsyn(CurrentScene, () =>
                {
                    LoadSceneAsyn(name, () =>
                    {
                        CurrentScene = name;
                        switcher.swiper.DOLocalMoveX(-2420f, 0.5f).OnComplete(() =>
                        {
                            switcher.swiper.localPosition = new Vector3(2420f, switcher.swiper.localPosition.y, switcher.swiper.localPosition.z);
                            switcher.swiper.gameObject.SetActive(false);
                            callback?.Invoke();
                        });
                    });
                });
            });
        }

        public void SwitchSceneByFade(string name, UnityAction callback = null)
        {
            switcher.gradienter.gameObject.SetActive(true);
            switcher.gradienter.DOFade(1, 0.5f).OnComplete(() =>
            {
                UnloadSceneAsyn(CurrentScene, () =>
                {
                    LoadSceneAsyn(name, () =>
                    {
                        CurrentScene = name;
                        switcher.gradienter.DOFade(0f, 0.5f).OnComplete(() =>
                        {
                            switcher.gradienter.gameObject.SetActive(false);
                            callback?.Invoke();
                        });
                    });
                });
            });
        }

        public void SwitchScene(string name, UnityAction callback = null)
        {
            UnloadSceneAsyn(CurrentScene, () =>
            {
                LoadSceneAsyn(name, () =>
                {
                    CurrentScene = name;
                    callback?.Invoke();
                });
            });
        }

        public void ReloadCurrentSceneSwipe()
        {
            switcher.swiper.gameObject.SetActive(true);
            switcher.swiper.DOLocalMoveX(0, 0.5f).OnComplete(() =>
            {
                UnloadSceneAsyn(CurrentScene, () =>
                {
                    LoadSceneAsyn(CurrentScene, () =>
                    {
                        switcher.swiper.DOLocalMoveX(-2420f, 0.5f).OnComplete(() =>
                        {
                            switcher.swiper.localPosition = new Vector3(2420f, switcher.swiper.localPosition.y, switcher.swiper.localPosition.z);
                            switcher.swiper.gameObject.SetActive(false);
                        });
                    });
                });
            });
        }

        private void LoadSceneAsyn(string name, UnityAction callback = null)
        {
            ScenesManager.instance.LoadSceneAsynAdd(name, callback);
        }
        private void LoadSceneAsynSingle(string name, UnityAction callback = null)
        {
            ScenesManager.instance.LoadSceneAsyn(name, callback);
        }
        private void UnloadSceneAsyn(string name, UnityAction callback = null)
        {
            ScenesManager.instance.UnloadSceneAsyn(name, callback);
        }

        public int GetActiveSceneNumber()
        {
            if (SceneManager.sceneCount > 1)
            {
                int order = 0;
                string[] levelSplit = SceneManager.GetSceneAt(1).name.Split('_');
                if (levelSplit.Length <= 1)
                    return 0;
                System.Int32.TryParse(levelSplit[1], out order);
                return order;
            }
            Debug.LogWarning("No Active Level in Scene");
            return 0;
        }
    }
}