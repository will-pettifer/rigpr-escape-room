using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private List<Camera> cameras;
    [SerializeField] private RawImage textureView;
    [SerializeField] private TMP_Text camNumberText;

    private List<RenderTexture> renderTextures;
    private int currentCamera = -1;

    void Start()
    {
        renderTextures = new List<RenderTexture>();
        for (int i = 0; i < cameras.Count; i++)
        {
            RenderTexture tex = new RenderTexture(1280, 720, 0);
            renderTextures.Add(tex);
            
            cameras[i].targetTexture = tex;
        }

        textureView.gameObject.SetActive(true);
        ChangeCamera();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeCamera();
        }
    }

    private void ChangeCamera()
    {
        currentCamera++;
        if (currentCamera == cameras.Count){
            currentCamera = 0;
        }

        textureView.texture = renderTextures[currentCamera];
        camNumberText.text = "Camera " + (currentCamera + 1).ToString();
    }

}