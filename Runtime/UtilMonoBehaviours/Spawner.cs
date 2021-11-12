using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Security;
using System.Linq;

namespace U.Gears
{
    public class Spawner : MonoBehaviour
    {

        #region Main

        // ENUM
        public SpawnMode spawnMode = SpawnMode.Infinite;
        public int maxSpawns = 10;
        public int minSpawns = 0;
        public SortMode sortBetwenPoints = SortMode.Random;
        public SortMode sortBetwenObjects = SortMode.Random;
        public Transform setAsChildOf;
        public List<Vector3> spawnPoints;
        public List<Transform> spawnTransforms;
        public List<GameObject> objectsList;
        public GameObject spawnInChildsOf;
        public UnityEvent<GameObject> onSpawn;



        private int totalSpawns = 10;
        private List<PositionKeeper> spawnsPositionsList = new List<PositionKeeper>();
        private Queue<PositionKeeper> spawnsPositionsQueue = new Queue<PositionKeeper>();
        private Queue<GameObject> objectsToSpawnQueue = new Queue<GameObject>();
        private int spawned = 0;
        private int spawnedInScene = 0;




        private void Start()
        {
            
            // Create the ppositions list to spawn
            var spawnPointsList = new List<PositionKeeper>();
            var spawnTransformsList = new List<PositionKeeper>();
            var spawnInChildsOfList = new List<PositionKeeper>();

            

            if (spawnPoints != null) spawnPointsList = spawnPoints.Where(s => s != null).Select(s => new PositionKeeper(s)).ToList();
            if (spawnTransforms != null) spawnTransformsList = spawnTransforms.Where(t => t != null).Select(t => new PositionKeeper(t)).ToList();
            if (spawnInChildsOf != null) spawnInChildsOfList = spawnInChildsOf.GetChildsTransforms().Select(t => new PositionKeeper(t)).ToList();

            spawnsPositionsList = spawnPointsList.Union(spawnTransformsList).Union(spawnInChildsOfList).ToList();

            // Create the max spawns
            if (spawnMode == SpawnMode.RandomCount || spawnMode == SpawnMode.RandomTrack)
                totalSpawns = Umath.RandomInt(minSpawns, maxSpawns);
            else if(spawnMode == SpawnMode.Count || spawnMode == SpawnMode.Track)
                totalSpawns = maxSpawns;

        }

        public void Restart()
        {
            Start();

            spawnsPositionsQueue.Clear();
            objectsToSpawnQueue.Clear();

            spawned = 0;
            spawnedInScene = 0;
        }



        private Vector3 SelectSpawnPoint()
        {
            if (spawnsPositionsList.Count < 1)
                throw new ArgumentNullException("Spawner: No available positions to spawn");

            if (sortBetwenPoints == SortMode.Random)
            {
                if (spawnsPositionsList == null || spawnsPositionsList.Count() < 1)
                    return Vector3.zero;

                var position = Umath.RandomInt(0, spawnsPositionsList.Count() - 1);
                return spawnsPositionsList[position].Position;

            }
            else if (sortBetwenPoints == SortMode.Order)
            {
                if (spawnsPositionsList == null || spawnsPositionsList.Count() < 1)
                    return Vector3.zero;

                // Check if exist some point in queue or renew the queue
                if (spawnsPositionsQueue.Count() < 1)
                {
                    foreach (var point in spawnsPositionsList)
                    {
                        spawnsPositionsQueue.Enqueue(point);
                    }
                }

                // Get the next oint
                return spawnsPositionsQueue.Dequeue().Position;

            }
            else if (sortBetwenPoints == SortMode.InverseOrder)
            {
                if (spawnsPositionsList == null || spawnsPositionsList.Count() < 1)
                    return Vector3.zero;

                // Check if exist some point in queue or renew the queue
                if (spawnsPositionsQueue.Count() < 1)
                {
                    // Create the reversed list
                    var reversedList = new List<PositionKeeper>(spawnsPositionsList);
                    reversedList.Reverse();
                    foreach (var point in reversedList)
                    {
                        spawnsPositionsQueue.Enqueue(point);
                    }
                }

                // Get the next point
                return spawnsPositionsQueue.Dequeue().Position;

            }
            else if (sortBetwenPoints == SortMode.RandomDontRepeat)
            {
                if (spawnsPositionsList == null || spawnsPositionsList.Count() < 1)
                    return Vector3.zero;

                // Check if exist some point in queue or renew the queue
                if (spawnsPositionsQueue.Count() < 1)
                {
                    // Create the randomList list
                    var randomList = new List<PositionKeeper>(spawnsPositionsList).Shuffle();
                    foreach (var point in randomList)
                    {
                        spawnsPositionsQueue.Enqueue(point);
                    }
                }

                // Get the next point
                return spawnsPositionsQueue.Dequeue().Position;

            }

            return Vector3.zero;
        }

        private GameObject SelectSpawnObject()
        {
            if (sortBetwenObjects == SortMode.Random)
            {
                if (objectsList == null || objectsList.Count() < 1)
                    return null;

                var obj = Umath.RandomInt(0, objectsList.Count() - 1);
                return objectsList[obj];

            }
            else if (sortBetwenObjects == SortMode.Order)
            {
                if (objectsList == null || objectsList.Count() < 1)
                    return null;

                // Check if exist some point in queue or renew the queue
                if (objectsToSpawnQueue.Count() < 1)
                {
                    foreach (var obj in objectsList)
                    {
                        objectsToSpawnQueue.Enqueue(obj);
                    }
                }

                // Get the next oint
                return objectsToSpawnQueue.Dequeue();

            }
            else if (sortBetwenObjects == SortMode.InverseOrder)
            {
                if (objectsList == null || objectsList.Count() < 1)
                    return null;

                // Check if exist some point in queue or renew the queue
                if (objectsToSpawnQueue.Count() < 1)
                {
                    // Create the reversed list
                    var reversedList = new List<GameObject>(objectsList);
                    reversedList.Reverse();
                    foreach (var obj in reversedList)
                    {
                        objectsToSpawnQueue.Enqueue(obj);
                    }
                }

                // Get the next point
                return objectsToSpawnQueue.Dequeue();

            }
            else if (sortBetwenObjects == SortMode.RandomDontRepeat)
            {
                if (objectsList == null || objectsList.Count() < 1)
                    return null;

                // Check if exist some point in queue or renew the queue
                if (objectsToSpawnQueue.Count() < 1)
                {
                    // Create the randomList list
                    var randomList = new List<GameObject>(objectsList).Shuffle();
                    foreach (var obj in randomList)
                    {
                        objectsToSpawnQueue.Enqueue(obj);
                    }
                }

                // Get the next point
                return objectsToSpawnQueue.Dequeue();

            }

            return null;
        }


        // Original Spawn Function
        public GameObject SpawnAndSelect(Vector3 position)
        {

            var obj = SelectSpawnObject();

            if (obj == null)
                throw new System.ArgumentNullException("Spawner: Cant find a Gameobject prefab to spawn");



            // Revisa si puede hacer el spawn o no puede
            GameObject clone = null;

            if (spawnMode == SpawnMode.Infinite)
            {
                //Debug.Log("Spawn by Infinite");
                clone = Instantiate(obj, position, Quaternion.identity);
            }
            else if ((spawnMode == SpawnMode.Count || spawnMode == SpawnMode.RandomCount) && spawned < totalSpawns)
            {
                //Debug.Log("Spawn by Count, current: " + spawned + " max: " + totalSpawns);
                clone = Instantiate(obj, position, Quaternion.identity);
            }
            else if ((spawnMode == SpawnMode.Track || spawnMode == SpawnMode.RandomTrack) && spawnedInScene < totalSpawns)
            {
                //Debug.Log("Spawn by Track, current: " + spawnedInScene + " max: " + totalSpawns);
                clone = Instantiate(obj, position, Quaternion.identity);
            }


            if (clone == null)
                return null;


            spawned++;
            spawnedInScene++;

            var tracker = ActionOnDestroy.AddComponent(clone, new ActionOnDestroy.Properties
            {
                onDestroy = () => spawnedInScene = Umath.Min(spawnedInScene - 1, 0)
            });

            // Revisa si debe ser hijo de alguno
            if (setAsChildOf != null)
                clone.transform.SetParent(setAsChildOf);

            // Ejecuta los delegates en el objeto
            try
            {
                onSpawn?.Invoke(clone);
            }
            catch (Exception e)
            {
                Debug.LogError("Spawner: Error in delegate applied to objects, " + e);
            }

            return clone;

        }

        // Spawn function with autoselect position
        public GameObject SpawnAndSelect()
        {
            return SpawnAndSelect(SelectSpawnPoint());
        }


        // Other funcions to spawn

        public void Spawn()
        {
            SpawnAndSelect();
        }
        public void Spawn(Vector3 position)
        {
            SpawnAndSelect(position);
        }
        public void Spawn(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Spawn();
            }
        }
        public void Spawn(Vector3 position, int num)
        {
            for (int i = 0; i < num; i++)
            {
                Spawn(position);
            }
        }
        public void Spawn(int min, int max)
        {
            Spawn(Umath.RandomInt(min, max));
        }  // Random spawn
        public void Spawn(Vector3 position, int min, int max)
        {
            Spawn(position, Umath.RandomInt(min, max));
        }  // Random spawn

        public GameObject[] SpawnAndSelect(Vector3 position, int num)
        {
            var list = new List<GameObject>();
            for (int i = 0; i < num; i++)
            {
                var obj = SpawnAndSelect(position);
                if (obj != null)
                    list.Add(obj);
            }
            return list.ToArray();
        }
        public GameObject[] SpawnAndSelect(int num)
        {
            var list = new List<GameObject>();
            for (int i = 0; i < num; i++)
            {
                var obj = SpawnAndSelect();
                if (obj != null)
                    list.Add(obj);
            }
            return list.ToArray();
        }
        public GameObject[] SpawnAndSelect(Vector3 position, int min, int max)
        {
            return SpawnAndSelect(position, Umath.RandomInt(min, max));
        }  // Random Spawn
        public GameObject[] SpawnAndSelect(int min, int max)
        {
            return SpawnAndSelect(Umath.RandomInt(min, max));
        }  // Random Spawn

        #endregion




        #region ENUMS

        private class PositionKeeper
        {
            public Vector3 Position
            {
                get
                {
                    if (t == null)
                        return v;
                    else
                        return t.position;
                }
            }

            private Transform t = null;
            private Vector3 v = Vector3.zero;

            public PositionKeeper(Transform t)
            {
                this.t = t;
            }

            public PositionKeeper(Vector3 v)
            {
                this.v = v;
            }

        }

        public enum SpawnMode
        {
            Infinite,  // Dont count the spawns
            Count,  // Count the spawned objects
            RandomCount,
            Track, // Count the existent objects in scene to decide if spawn or not
            RandomTrack,
        }

        public enum SortMode
        {
            Random,  // Spawn in random points
            Order,  // Spawns ordered in the points
            InverseOrder,  // Spawn in inverse order
            RandomDontRepeat,  // Spawn random but dont repeat the points
        }


        #endregion


        #region GIZMOS

#if UNITY_EDITOR
        void OnDrawGizmosSelected()
        {
            if(spawnPoints != null)
            {
                foreach (var p in spawnPoints)
                {
                    if (p == null)
                        continue;

                    // ICONOS de -- https://unitylist.com/p/5c3/Unity-editor-icons
                    Gizmos.DrawIcon(p, "d_winbtn_mac_max", true);
                }
            }

            if (spawnTransforms != null)
            {
                foreach (var p in spawnTransforms)
                {
                    if (p == null)
                        continue;

                    // ICONOS de -- https://unitylist.com/p/5c3/Unity-editor-icons
                    Gizmos.DrawIcon(p.position, "d_winbtn_mac_min", true);
                }
            }
                
        }

#endif

        #endregion




        #region Factory

        public class Properties
        {
            public SpawnMode spawnMode = SpawnMode.Infinite;
            public int maxSpawns = 10;
            public int minSpawns = 5;
            public SortMode sortBetwenPoints = SortMode.Random;
            public SortMode sortBetwenObjects = SortMode.Random;
            public List<Vector3> spawnPoints;
            public List<Transform> spawnTransforms;
            public List<GameObject> objectsList;
            public Action<GameObject> OnSpawn;
        }

        public static Spawner AddComponent(GameObject gameObject, Properties p)
        {
            if (gameObject == null)
                throw new ArgumentException("GameObject cant be null");

            if (p.maxSpawns < p.minSpawns || p.minSpawns < 0)
                throw new ArgumentException("ActionList cant be null");

            if ((p.spawnMode == SpawnMode.RandomCount || p.spawnMode == SpawnMode.RandomTrack) && (p.maxSpawns < p.minSpawns || p.minSpawns < 0))
                throw new ArgumentException("ActionList cant be null");


            var c = gameObject.AddComponent<Spawner>();

            c.spawnMode = p.spawnMode;
            c.maxSpawns = p.maxSpawns;
            c.minSpawns = p.minSpawns;
            c.sortBetwenPoints = p.sortBetwenPoints;
            c.sortBetwenObjects = p.sortBetwenObjects;
            c.spawnPoints = p.spawnPoints;
            c.spawnTransforms = p.spawnTransforms;
            c.objectsList = p.objectsList;

            var ev = new UnityEvent<GameObject>();
            ev.AddListener(g => p.OnSpawn?.Invoke(g));
            c.onSpawn = ev;

            return c;
        }

        #endregion

    }

}