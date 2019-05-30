using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGame {
    namespace ObjectPooler {
        public class PooledObjectBehavior : MonoBehaviour {

            protected ObjectPooler objectPooler;

            [SerializeField, Range(0, 10)]
            protected float maxLifeTime;
            protected float lifeTime;
            [SerializeField]
            protected string poolTag;

            protected virtual void Awake() { }

            protected virtual void Start() {
                objectPooler = ObjectPooler.Instance;
                lifeTime = 0;
            }

            protected virtual void Update() {
                lifeTime += Time.deltaTime;
                if (lifeTime > maxLifeTime) {
                    ReturnObjectToPool();
                }
            }

            protected virtual void OnEnable() { }

            protected virtual void ReturnObjectToPool() {
                lifeTime = 0;
                objectPooler.ReturnObjectToPool(poolTag, gameObject);
            }
        }

    }
}