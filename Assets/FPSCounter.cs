using UnityEngine;
using System.Collections;

public class FPSCounter : MonoBehaviour
{
    public int frameRange = 60;
    public int AverageFPS { get; private set; }
    public int LowFPS { get; private set; }
    public int HighFPS { get; private set; }

    int[] fpsBuffer;
    int fpsBufferIdx;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (fpsBuffer == null || fpsBuffer.Length != frameRange)
        {
            InitBuffer();
        }

        if ((fpsBufferIdx + 1) > frameRange)
        {
            fpsBufferIdx = 0;
        }

        fpsBuffer[fpsBufferIdx++] = (int)(1f / Time.unscaledDeltaTime);

        int sum = 0;
        for (int i = 0; i < frameRange; i++)
        {
            sum += fpsBuffer[i];
        }

        AverageFPS = sum / frameRange;
        HighFPS = Mathf.Max(fpsBuffer);
        LowFPS = Mathf.Min(fpsBuffer);

    }

    void InitBuffer()
    {
        if (frameRange < 1)
        {
            frameRange = 1;
        }
        fpsBuffer = new int[frameRange];
        fpsBufferIdx = 0;
    }

}
