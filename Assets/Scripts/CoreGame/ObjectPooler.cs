using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

namespace CoreGame {
    namespace ObjectPooler {
        public class ObjectPooler : MonoBehaviour {

            #region Singleton
            public static ObjectPooler Instance;
            private void Awake() {
                Instance = this;
            }
            #endregion

            [System.Serializable]
            public class Pool {
                public string tag;
                public GameObject prefab;
                public int size;
            }

            public List<Pool> pools;
            public Dictionary<string, Queue<GameObject>> poolDictionary;

            // Use this for initialization
            void Start() {
                poolDictionary = new Dictionary<string, Queue<GameObject>>();
                foreach (Pool pool in pools) {
                    Queue<GameObject> objectPool = new Queue<GameObject>();
                    for (int i = 0; i < pool.size; i++) {
                        GameObject obj = Instantiate(pool.prefab);
                        obj.transform.parent = transform;
                        obj.SetActive(false);
                        objectPool.Enqueue(obj);
                    }
                    poolDictionary.Add(pool.tag, objectPool);
                }
            }

            public void ReturnObjectToPool(string tag, GameObject obj) {
                if (!poolDictionary.ContainsKey(tag)) {
                    Debug.LogWarning("Pool with tag " + tag + " doesn't exit.");
                    return;
                }
                obj.SetActive(false);
                poolDictionary[tag].Enqueue(obj);
            }

            public void GetObjectFromPool(string tag, Vector3 position, Quaternion rotation, Transform parent) {
                if (!poolDictionary.ContainsKey(tag)) {
                    Debug.LogWarning("Pool with tag " + tag + " doesn't exit.");
                    return;
                }
                GameObject obj = null;
                if (poolDictionary[tag].Count > 0) {
                    obj = poolDictionary[tag].Dequeue();
                    obj.transform.position = position;
                    obj.transform.rotation = rotation;
                    if(parent != null) obj.transform.parent = parent;
                    obj.SetActive(true);
                }
                return;
            }
        }
    }
}
