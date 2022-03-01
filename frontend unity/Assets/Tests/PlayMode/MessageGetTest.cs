using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;
public class MessageGetTest
{
    public string result = "";
    public int testCounter = 0;
    public bool CreatedAccount = false;
    public LoginUsers.OverUserModel contentUser = null;
    
    [UnityTest]
    public IEnumerator GetMessagesRight(){
        var getMessages = false;
        yield return CrudMessages.ReadMessagesI();
        if (CrudMessages.testMessagesGet.StartsWith("[{\"id\":")){ getMessages = true; }
        Debug.Log("Test con los valores correctos");
        Debug.Log(CrudMessages.testMessagesGet);
        Assert.IsTrue(getMessages, "No se obtuvieron los mensajes");
    }

    [UnityTest]
    public IEnumerator GetMessagesFail(){
        var getMessages = false;
        yield return CrudMessages.ReadMessagesI();
        if (!CrudMessages.testMessagesGet.StartsWith("[{\"id\":")){ getMessages = true; }
        Debug.Log("Test esperando un error");
        Debug.Log(CrudMessages.testMessagesGet);
        Assert.IsFalse(getMessages, "Se obtuvieron los mensajes de alguna forma");
    }
}
