using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace U.Universal
{
    public static partial class UnityTask
    {

   
        public static async Task LoadSceneAsync(GameObject gameObject, int sceneBuildIndex, LoadSceneMode mode, Action<float> whileLoad = null)
        {

            IEnumerator Helper()
            {
                // Carga de forma aditiva la nueva escena y la guarda en una variable
                AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneBuildIndex, mode);

                // Mientras la escena se carga espera y ejecuta el delagate
                while (!loadOperation.isDone)
                {
                    try
                    {
                        whileLoad?.Invoke(Mathf.Clamp01(loadOperation.progress / .9f));
                    }
                    catch (Exception e)
                    {
                        Debug.LogError("Uroutine.LoadSceneAsync: Error in whileLoad delegate, scene will be loaded anyway, " + e);
                    }
                    yield return null;
                }
            }

            await Helper().WaitAsTask(gameObject);

        }

        public static async Task LoadSceneAsync(GameObject gameObject, string sceneName, LoadSceneMode mode, Action<float> whileLoad = null)
        {

            IEnumerator Helper()
            {
                // Carga de forma aditiva la nueva escena y la guarda en una variable
                AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName, mode);

                // Mientras la escena se carga espera y ejecuta el delagate
                while (!loadOperation.isDone)
                {
                    try
                    {
                        whileLoad?.Invoke(Mathf.Clamp01(loadOperation.progress / .9f));
                    }
                    catch (Exception e)
                    {
                        Debug.LogError("Uroutine.LoadSceneAsync: Error in whileLoad delegate, scene will be loaded anyway, " + e);
                    }
                    yield return null;
                }
            }

            await Helper().WaitAsTask(gameObject);

        }

        public static async Task UnloadSceneAsync(GameObject gameObject, int sceneBuildIndex, Action whileUnload = null)
        {

            IEnumerator Helper()
            {
                // Carga de forma aditiva la nueva escena y la guarda en una variable
                AsyncOperation loadOperation = SceneManager.UnloadSceneAsync(sceneBuildIndex);

                // Mientras la escena se carga espera y ejecuta el delagate
                while (!loadOperation.isDone)
                {
                    try
                    {
                        whileUnload?.Invoke();
                    }
                    catch (Exception e)
                    {
                        Debug.LogError("Uroutine.LoadSceneAsync: Error in whileLoad delegate, scene will be loaded anyway, " + e);
                    }
                    yield return null;
                }
            }

            await Helper().WaitAsTask(gameObject);

        }

        public static async Task UnloadSceneAsync(GameObject gameObject, string sceneName, Action whileUnload = null)
        {

            IEnumerator Helper()
            {
                // Carga de forma aditiva la nueva escena y la guarda en una variable
                AsyncOperation loadOperation = SceneManager.UnloadSceneAsync(sceneName);

                // Mientras la escena se carga espera y ejecuta el delagate
                while (!loadOperation.isDone)
                {
                    try
                    {
                        whileUnload?.Invoke();
                    }
                    catch (Exception e)
                    {
                        Debug.LogError("Uroutine.LoadSceneAsync: Error in whileLoad delegate, scene will be loaded anyway, " + e);
                    }
                    yield return null;
                }
            }

            await Helper().WaitAsTask(gameObject);

        }

    }
}
