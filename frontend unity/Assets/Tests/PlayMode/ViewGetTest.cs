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
public class ViewGetTest
{
    public string result = "";
    public int testCounter = 0;
    public bool CreatedAccount = false;
    public LoginUsers.OverUserModel contentUser = null;
    
    [UnityTest]
    public IEnumerator GetViewsRight(){
        var getViews = false;
        yield return Crud.ReadViewsI();
        if (Crud.testViewGet.StartsWith("[{\"id\":")){ getViews = true; }
        Debug.Log("Test con los valores correctos");
        Debug.Log(Crud.testViewGet);
        Assert.IsTrue(getViews, "No se obtuvieron las visitas");
    }

    [UnityTest]
    public IEnumerator GetViewsFail(){
        var getViews = false;
        yield return Crud.ReadViewsI();
        if (!Crud.testViewGet.StartsWith("[{\"id\":")){ getViews = true; }
        Debug.Log("Test esperando un error");
        Debug.Log(Crud.testViewGet);
        Assert.IsFalse(getViews, "Se obtuvieron las visitas de alguna forma");
    }
}
