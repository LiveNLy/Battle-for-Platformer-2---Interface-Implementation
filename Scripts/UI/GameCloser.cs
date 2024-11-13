using UnityEngine;
using UnityEditor;

public class GameCloser : MonoBehaviour
{
    public void Close()
    {
        EditorApplication.isPlaying = false;
    }
}
