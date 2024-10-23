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
        public static T Instance { get; internal protected set; }

        protected internal virtual void Awake()
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
