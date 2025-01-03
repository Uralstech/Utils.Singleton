// Copyright 2024 URAV ADVANCED LEARNING SYSTEMS PRIVATE LIMITED
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;

namespace Uralstech.Utils.Singleton
{
    /// <summary>
    /// Utility class to make inheriting types singletons.
    /// </summary>
    /// <typeparam name="T">The type to be made a singleton.</typeparam>
    public class Singleton<T> : MonoBehaviour
        where T : Component
    {
        private static T s_instance;

        /// <summary>
        /// Is there an existing instance of type <typeparamref name="T"/>?
        /// </summary>
        /// <remarks>
        /// If there is no set instance, this will try to find them. If more than one instance
        /// is found, the extra instances are deleted.
        /// </remarks>
        public static bool HasInstance => CheckForInstanceAndDeleteExtras();

        /// <summary>
        /// The active instance of type <typeparamref name="T"/>.
        /// </summary>
        /// <remarks>
        /// If there is no set instance, this will try to find them. If more than one instance
        /// is found, the extra instances are deleted. If none are found, a new instance is created.
        /// </remarks>
        public static T Instance => CheckForInstanceAndDeleteExtras()
                                        ? s_instance
                                        : s_instance = new GameObject(typeof(T).Name).AddComponent<T>();

        private static bool CheckForInstanceAndDeleteExtras()
        {
            if (s_instance != null)
                return true;

            T[] objects = FindObjectsByType<T>(FindObjectsSortMode.InstanceID);
            if (objects.Length == 0)
                return false;

            if (objects.Length > 1)
            {
                for (int i = 1; i < objects.Length; i++)
                    Destroy(objects[i]);
            }

            s_instance = objects[0];
            return true;
        }
    }
}
