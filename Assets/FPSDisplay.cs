using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(FPSCounter))]
public class FPSDisplay : MonoBehaviour
{

    [System.Serializable]
    private struct FPSColor
    {
        public Color color;
        public int minFPS;
    }

    [SerializeField]
    private FPSColor[] coloring;

    public Text fpsAverage, fpsHigh, fpsLow;
    FPSCounter fpsCounter;

    private void Awake()
    {
        fpsCounter = GetComponent<FPSCounter>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Display(fpsAverage, fpsCounter.AverageFPS);
        Display(fpsHigh, fpsCounter.HighFPS);
        Display(fpsLow, fpsCounter.LowFPS);
    }

    void Display(Text label, int fps)
    {
        label.text = Mathf.Clamp(fps, 0, 99).ToString();
        //for (int i = 0; i < coloring.Length; i++)
        //{
        //    if (fps >= coloring[i].minFPS)
        //    {
        //        label.color = coloring[i].color;
        //        break;
        //    }
        //}
    }
}
