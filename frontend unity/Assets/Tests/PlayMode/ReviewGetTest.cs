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
public class ReviewGetTest
{
    public string result = "";
    public int testCounter = 0;
    public bool CreatedAccount = false;
    public LoginUsers.OverUserModel contentUser = null;
    
    [UnityTest]
    public IEnumerator GetReviewsRight(){
        var getReviews = false;
        yield return CrudComments.ReadCommentsI();
        if (CrudComments.testCommentsGet.StartsWith("[{\"id\":")){ getReviews = true; }
        Debug.Log("Test con los valores correctos");
        Debug.Log(CrudComments.testCommentsGet);
        Assert.IsTrue(getReviews, "No se obtuvieron los comentarios");
    }

    [UnityTest]
    public IEnumerator GetReviewsFail(){
        var getReviews = false;
        yield return CrudComments.ReadCommentsI();
        if (!CrudComments.testCommentsGet.StartsWith("[{\"id\":")){ getReviews = true; }
        Debug.Log("Test esperando un error");
        Debug.Log(CrudComments.testCommentsGet);
        Assert.IsFalse(getReviews, "Se obtuvieron los comentarios de alguna forma");
    }
}
