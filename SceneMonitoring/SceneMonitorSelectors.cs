
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace U.Universal
{
    public sealed partial class SceneMonitor
    {

        
        // States
        private SelectorsConfig config;
        private bool isConfigFirstTime = true;



        public void SetConfig(SelectorsConfig newConfig)
        {
            this.config = newConfig;
            isConfigFirstTime = true;
            SceneManager.sceneLoaded -= OnSceneLoad;
            SceneManager.sceneUnloaded -= OnSceneUnload;
            SceneManager.activeSceneChanged -= OnActiveSceneChanged;

            // Check if enabled or not
            if (config == null)
            {
                return;
            }
            else
            {
                if (!config.enable)
                    return;
            }


            // Excecute on enable delegate
            ExecuteDelegate(config.onEnableSceneMonitor, "onEnableSceneMonitor");

            // Subscribe to the events
            if (config.selectors != null)
            {
                SceneManager.sceneLoaded += OnSceneLoad;
                SceneManager.sceneUnloaded += OnSceneUnload;
                SceneManager.activeSceneChanged += OnActiveSceneChanged;

                OnSceneLoad(SceneManager.GetActiveScene(), LoadSceneMode.Single);
                OnActiveSceneChanged(SceneManager.GetActiveScene(), SceneManager.GetActiveScene());
            }

        }


        private void OnSceneLoad(Scene scene, LoadSceneMode loadMode)
        {

            // Search for the scene in scenes def list
            var selectors = SearchScenePattern(scene.name, scene.buildIndex, scene.path, config);
            if (selectors == null)
                return;

            // Execute afterLoad delagate
            foreach (var usene in selectors)
            {
                if (usene == null)
                    continue;

                ExecuteDelegate(usene.onLoad, "onLoad of Scene: " + usene.pattern);

            }
            
        }

        private void OnSceneUnload(Scene scene)
        {
            
            // Search for the scene in scenes def list
            var selectors = SearchScenePattern(scene.name, scene.buildIndex, scene.path, config);
            if (selectors == null) 
                return;

            // Execute beforeUnload delagate
            foreach (var usene in selectors)
            {
                if (usene == null)
                    continue;

                ExecuteDelegate(usene.onUnload, "onUnload of Scene: " + usene.pattern);

            }

        }

        private void OnActiveSceneChanged(Scene currentScene, Scene nextScene)
        {
            
            // Search for the scene in scenes def list
            var selectorsNexts = SearchScenePattern(nextScene.name, nextScene.buildIndex, nextScene.path, config);
            Selector[] selectorsCurrents = null;
            if (!isConfigFirstTime)
                selectorsCurrents = SearchScenePattern(currentScene.name, currentScene.buildIndex, currentScene.path, config);
            else
                isConfigFirstTime = false;
            
            // Execute afterLoad delagate from the scene that will be inactivated, can be null if is the first scene
            if (selectorsCurrents != null)
                foreach (var usene in selectorsCurrents)
                {
                    if (usene == null)
                        continue;

                    ExecuteDelegate(usene.onSetInactive, "onSetAsInactive of Scene: " + usene.pattern);

                }

            // Execute afterLoad delagate from the scene, not from the route, becouse you are only unloading a scene without a route
            if (selectorsNexts != null)
                foreach (var usene in selectorsNexts)
                {
                    if (usene == null)
                        continue;

                    ExecuteDelegate(usene.onSetActive, "onSetAsActive of Scene: " + usene.pattern);

                }

        }





        private void ExecuteDelegate(Action action, string name)
        {
            try { action?.Invoke(); }
            catch (Exception e) { Debug.LogError("Uscenes: Error executing delegate " + name + ", " + e); }
        }

        public Selector[] SearchScenePattern(string name, int buildIndex, string path, SelectorsConfig config)
        {
            if (config == null)
                return null;

            if (config.selectors == null)
                return null;

            return config.selectors.Where(selector => 
            {

                try
                {
                    // Search by OR ||
                    if (selector.pattern.Where(c => c == '|').Count() > 0 && selector.pattern.Where(c => c == '&').Count() == 0)
                    {
                        foreach (var pattern in selector.pattern.Split('|'))
                        {
                            if (String.IsNullOrEmpty(pattern))
                                continue;

                            if (Search(pattern))
                                return true;
                        }

                        return false;
                    }
                    // Search by AND &&
                    else if (selector.pattern.Where(c => c == '&').Count() > 0 && selector.pattern.Where(c => c == '|').Count() == 0)
                    {
                        foreach (var pattern in selector.pattern.Split('&'))
                        {
                            if (String.IsNullOrEmpty(pattern))
                                continue;

                            if (!Search(pattern))
                                return false;
                        }

                        return true;
                    }
                    // Search Only one pattern
                    else
                    {
                        return Search(selector.pattern);
                    }
                }
                catch (Exception)
                {
                    return false;
                }


                


                bool Search(string pattern)
                {
                    // By index
                    if (pattern.StartsWith("#"))
                    {
                        var p1 = pattern.TrimStart('#');

                        if (p1.StartsWith(">="))
                        {

                            if (buildIndex >= Int32.Parse(p1.TrimStart('>', '=')))
                                return true;
                            else
                                return false;

                        }
                        else if (p1.StartsWith("<="))
                        {

                            if (buildIndex <= Int32.Parse(p1.TrimStart('<', '=')))
                                return true;
                            else
                                return false;

                        }
                        else if (p1.StartsWith(">"))
                        {

                            if (buildIndex > Int32.Parse(p1.TrimStart('>')))
                                return true;
                            else
                                return false;

                        }
                        else if (p1.StartsWith("<"))
                        {

                            if (buildIndex < Int32.Parse(p1.TrimStart('<')))
                                return true;
                            else
                                return false;

                        }
                        else
                        {

                            if (buildIndex == Int32.Parse(p1))
                                return true;
                            else
                                return false;
                        }
                    }

                    // By path
                    else if (pattern.StartsWith("."))
                    {
                        //Debug.Log("By Path");
                        var p1 = pattern.TrimStart('.');

                        if (p1.TrimEnd('*').Length == 0)
                        {
                            //Debug.Log("False .**");
                            return false;
                        }
                        else if (p1.EndsWith("*") && p1.TrimEnd('*').Length > 0)
                        {
                            //Debug.Log("By Path   path*");
                            if (path.StartsWith(p1.TrimEnd('*')))
                                return true;
                            else
                                return false;

                        }
                        else if (p1.StartsWith("*") && p1.TrimStart('*').Length > 0)
                        {
                            //Debug.Log("By Path   *path: " + selector.pattern + "  : " + path);
                            if (path.EndsWith(p1.TrimStart('*') + ".unity"))
                                return true;
                            else
                                return false;

                        }
                        else
                        {
                            //Debug.Log("By Path   path");
                            if (path == p1 + ".unity")
                                return true;
                            else
                                return false;

                        }
                    }

                    // By name
                    else
                    {
                        //Debug.Log("ByName");
                        var p1 = pattern;

                        if (p1.TrimEnd('*').Length == 0)
                        {
                            //Debug.Log("ByName *");
                            //Debug.Log("True");
                            return true;
                        }
                        else if (p1.StartsWith("*") && p1.EndsWith("*") && p1.Length > 2)
                        {
                            //Debug.Log("ByName *name*name*");
                            var pieces = p1.TrimStart('*').TrimEnd('*').Split('*');

                            foreach (var p in pieces)
                            {
                                if (!name.Contains(p) || p.Length < 1)
                                    return false;
                            }

                            return true;

                        }
                        else if (p1.StartsWith("*"))
                        {
                            //Debug.Log("ByName *name");
                            if (name.EndsWith(p1.TrimStart('*')) && p1.TrimStart('*').Length > 0)
                            {
                                //Debug.Log("True");
                                return true;
                            }
                            else
                            {
                                //Debug.Log("False");
                                return false;
                            }

                        }
                        else if (p1.EndsWith("*"))
                        {
                            //Debug.Log("ByName name*");
                            if (name.StartsWith(p1.TrimEnd('*')) && p1.TrimEnd('*').Length > 0)
                            {
                                //Debug.Log("True");
                                return true;
                            }
                            else
                            {
                                //Debug.Log("False");
                                return false;
                            }

                        }
                        else
                        {
                            //Debug.Log("ByName name");
                            if (name == p1)
                            {
                                //Debug.Log("True");
                                return true;
                            }
                            else
                            {
                                //Debug.Log("False");
                                return false;
                            }

                        }

                    }
                }


            }).ToArray();

        }


    }



    #region Configclasses


    public class Selector
    {

        public string pattern;
        public Action onUnload; // Will excecute before this scene is unloaded
        public Action onLoad; // Will excecute after this scene is loaded
        public Action onSetActive; // Will excecute after this scene is set as active
        public Action onSetInactive; // Will excecute after this scene is set to inactive

    }

    public class SelectorsConfig
    {
        public bool enable;
        public Action onEnableSceneMonitor;
        public Selector[] selectors;
    }


    #endregion Configclasses

}


