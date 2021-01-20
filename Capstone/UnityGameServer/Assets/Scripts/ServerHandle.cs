using System.Collections;
using System.Collections.Generic;

using System.Net;
using System;
using System.Net.Sockets;
using UnityEngine;

public class ServerHandle 
{
    public static void WelcomeRecieved(int _fromClient, Packet _packet)
    {
        int _clientIdCheck = _packet.ReadInt();
        string _username = _packet.ReadString();

        Console.Write($"{Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {_fromClient}.");
        if (_fromClient != _clientIdCheck)
        {
            Console.Write($"Player \"{_username}\" (ID: {_fromClient}) has assumed the wrong client ID ({_clientIdCheck})!");
        }

        Server.clients[_fromClient].SendIntogame(_username);
    }

    public static void PlayerMovement(int _fromClient, Packet _packet)
    {
        bool[] _inputs = new bool[_packet.ReadInt()];
        for (int i = 0; i < _inputs.Length; i++)
        {
            _inputs[i] = _packet.ReadBool();
        }
        Quaternion _rotation = _packet.ReadQuaternion();

        Server.clients[_fromClient].player.SetInput(_inputs, _rotation);
    }


    public static void PlayerShoot(int _fromClient, Packet _packet)
    {
        Vector3 _shootDirection = _packet.ReadVector3();

        Server.clients[_fromClient].player.Shoot(_shootDirection);
    }

    public static void PlayerThrowItem(int _fromClient, Packet _packet)
    {
        Vector3 _throwDirection = _packet.ReadVector3();

        Server.clients[_fromClient].player.ThrowItem(_throwDirection);
    }

    public static void SendWorldChatUDP(int _fromClient, Packet _packet)
    {
        int _id = _packet.ReadInt();
        string _msg = _packet.ReadString();
        ServerSend.WorldChat(_id, _msg);
    }
}
