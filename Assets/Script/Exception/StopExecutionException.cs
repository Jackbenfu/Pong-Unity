#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Pong.Exception
{
    /// <summary>
    /// A type of exception that stops the Editor execution when thrown.
    /// </summary>
    public class StopExecutionException : System.Exception
    {
        public StopExecutionException(string message)
            : base(message)
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            UnityEngine.Application.Quit();
#endif
        }
    }
}
