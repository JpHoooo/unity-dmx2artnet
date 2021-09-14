# DMX to ArtNet
### 预览
![xyrotateGif](https://jp-github.oss-cn-shenzhen.aliyuncs.com/unity-dmx2artnet/gif/xyrotategif.gif)  ![colorchangeGif](https://jp-github.oss-cn-shenzhen.aliyuncs.com/unity-dmx2artnet/gif/colorchangegif.gif)

### 所需硬件
* [ART-NET双向1024控制器](https://item.taobao.com/item.htm?spm=a230r.1.14.15.4d6b13ccmO65or&id=38833901181&ns=1&abbucket=7#detail)  
* [数控摇头灯](https://detail.tmall.com/item.htm?spm=a1z10.5-b.w4011-22220939836.52.73e02c8apSTSwU&id=612721773943&rn=885e290328daf296d433f5d70f432ecf&abbucket=10) （非广告）
  
### 运行环境
64-bit destop platforms(Windows,macOS)

### 在Unity Editor上运行
Unity 2019.3.0f6或更新版本

### 硬件连接方式
![WiringDiagram](https://jp-github.oss-cn-shenzhen.aliyuncs.com/unity-dmx2artnet/pic/Wiring%20diagram.png)

### 如何使用
* 拿到DMX控制器的默认IP和子网掩码，分别是`192.168.1.100`和`255.255.255.0`  

![ip&mask](https://jp-github.oss-cn-shenzhen.aliyuncs.com/unity-dmx2artnet/pic/ipNsubnetMask.jpg)
* 手动设置本机Ip地址（要求:`192.168.1.xxx`,不能与控制器的ip地址相同,我这里设置为192.168.1.88）和子网掩码（要求与控制器的子网掩码相同，我这里设置为255.255.255.0）  

![ip&Mask](https://jp-github.oss-cn-shenzhen.aliyuncs.com/unity-dmx2artnet/pic/ipAndMask.png)
* 打开目录`Assets/DMX2ArtNet/Scenes/Test.unity` ,选中摄像机 ，在`ArtNetDMXController`控件上把`IPAdress`换成DMX控制器的IP地址`(192.168.1.100) ` 

![component](https://jp-github.oss-cn-shenzhen.aliyuncs.com/unity-dmx2artnet/pic/component.png)
* Play，然后控制`ArtNetTest`的参数

### 建议
建议先尝试了解一下DMX的工作原理，再结合Unity去做控制DMX
***
## 感谢，如发现错误欢迎指正


