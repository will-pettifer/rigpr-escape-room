using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageSpawner : MonoBehaviour
{
    ARTrackedImageManager m_ImageManager;

    void OnEnable()
    {
        m_ImageManager.trackablesChanged.AddListener(OnChanged);
        Debug.Lo
    } 

    void OnDisable() => m_ImageManager.trackablesChanged.RemoveListener(OnChanged);

    void OnChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            Debug.Log(newImage.size);
        }

        foreach (var updatedImage in eventArgs.updated)
        {
            // Handle updated event
        }

        foreach (var removed in eventArgs.removed)
        {
            // Handle removed event
            TrackableId removedImageTrackableId = removed.Key;
            ARTrackedImage removedImage = removed.Value;
        }
    }
}