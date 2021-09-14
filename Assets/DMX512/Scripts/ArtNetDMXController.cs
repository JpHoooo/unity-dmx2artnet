using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
	
public class ArtNetDMXController : MonoBehaviour {

	UdpClient udpClient = new UdpClient();

	public string address = "192.168.1.100";
	public int port = 6454;
	public int universe = 0;
	public bool useEditor = false;
	public byte[] data = new byte[512];
	
	byte[] oldData = new byte[512];
	byte[] header = new byte[18];
	bool sent = false;

	public bool Sent{
		get{return sent;}
	}

	void Awake(){

		header[0] = (byte)'A';
		header[1] = (byte)'r';
		header[2] = (byte)'t';
		header[3] = (byte)'-';
		header[4] = (byte)'N';
		header[5] = (byte)'e';
		header[6] = (byte)'t';
		header[7] = 0;
		header[8] = 0;
		header[9] = 0x50;
		header[10] = 0;
		header[11] = 14;
		header[12] = 0;
		header[13] = 0;
		header[14] = (byte)(universe & 0xff);
		header[15] = (byte)((universe >> 8) & 0x7f);
		header[16] = 2;
		header[17] = 0;
	}

	void Update () {

		sent = data.SequenceEqual(oldData);
		SendEditor(data);
	}

	public void Send(byte[] sendData, int sendUniverse = 0){

		if(useEditor){
			Debug.LogWarning("Sending from the editor is valid.");	return;
		}
		if(sendData.Length != 512){
			Debug.LogWarning("Please pass data of 512 bytes.");	return;
		}
		byte[] dgram = new byte[512 + 18];

		header[14] = (byte)(sendUniverse & 0xff);
		header[15] = (byte)((sendUniverse >> 8) & 0x7f);
		
		Buffer.BlockCopy(header, 0, dgram, 0, 18);
		Buffer.BlockCopy(sendData, 0, dgram, 18, 512);
		Buffer.BlockCopy(sendData, 0, data, 0, 512);

		if (!sent) {
			udpClient.Send(dgram, dgram.Length, address, port);
			Buffer.BlockCopy(data, 0, oldData, 0, 512);
		}
	}

	void SendEditor (byte[] sendData) {

		byte[] dgram = new byte[512 + 18];

		header[14] = (byte)(universe & 0xff);
		header[15] = (byte)((universe >> 8) & 0x7f);
		
		Buffer.BlockCopy(header, 0, dgram, 0, 18);
		Buffer.BlockCopy(sendData, 0, dgram, 18, 512);
		Buffer.BlockCopy(sendData, 0, data, 0, 512);
	
		if (!sent) {
			udpClient.Send(dgram, dgram.Length, address, port);
			Buffer.BlockCopy(data, 0, oldData, 0, 512);
		}
	}
}
