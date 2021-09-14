using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.EditorTools;
using UnityEngine;

public class ArtNetTest : MonoBehaviour{

    ArtNetDMXController artnet;
	byte[] data = new byte[512];

    [Range(0, 255),Header("X轴旋转(水平扫描540度)")] public byte xRotate;
    [Range(0, 255), Header("Y轴旋转(垂直扫描270度)")] public byte yRotate;
    [Range(0, 255), Header("X/Y轴旋转速度(由快到慢)")] public byte xyRotateSpeed;
    [Range(0, 255), Header("闪频")] public byte strobe;
    [Range(0, 255), Header("调光")] public byte dimming;
    [Range(0, 255), Header("颜色盘")] public byte colorWheel;
    [Range(0, 255), Header("图案盘")] public byte gobo;
    [Range(0, 255), Header("调焦")] public byte focusing;
    [Range(0, 255), Header("棱镜")] public byte prism;
    [Range(0, 255), Header("棱镜旋转")] public byte prismRotate;
    [Range(0, 255), Header("雾化")] public byte atomization;
    [Range(0, 255), Header("X轴微调")] public byte xAxisFinetuning;
    [Range(0, 255), Header("Y轴微调")] public byte yAxisFinetuning;
    [Range(0, 255), Header("电子点泡")] public byte electronicBubble;
    [Range(0, 255), Header("灯具复位")] public byte LightReset;

    // Start is called before the first frame update
    void Start(){
     
        artnet = GetComponent<ArtNetDMXController>();

        for(int i = 0; i < data.Length; i++){
            data[i] = 0;
            //data[i] = (byte)(i /2);
        }
    }

    // Update is called once per frame
    void Update(){
        data[0] = xRotate;
        data[1] = yRotate;
        data[2] = xyRotateSpeed;
        data[3] = strobe;
        data[4] = dimming;
        data[5] = colorWheel;
        data[6] = gobo;
        data[7] = focusing;
        data[8] = prism;
        data[9] = prismRotate;
        data[11] = atomization;
        data[12] = xAxisFinetuning;
        data[13] = yAxisFinetuning;
        data[14] = electronicBubble;
        data[15] = LightReset;
        artnet.Send(data);      
       
    }
}
