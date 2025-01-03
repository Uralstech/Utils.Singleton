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
    /// <remarks>
    /// Unlike <see cref="Singleton{T}"/>, this does not create a new instance of
    /// <typeparamref name="T"/> if there are no existing ones.
    /// </remarks>
    /// <typeparam name="T">The type to be made a singleton.</typeparam>
    public class DontCreateNewSingleton<T> : MonoBehaviour
        where T : Component
    {
        /// <summary>
        /// Is there an existing instance of type <typeparamref name="T"/>?
        /// </summary>
        public static bool HasInstance => Instance != null;

        /// <summary>
        /// The active instance of type <typeparamref name="T"/>.
        /// </summary>
        public static T Instance { get; protected set; }

        /// <remarks>
        /// Checks if <see cref="Instance"/> is <see langword="null"/>, and if yes, sets it to this instance.
        /// If no, destroys the current <see cref="GameObject"/>.
        /// </remarks>
        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = GetComponent<T>();
        }
    }
}
