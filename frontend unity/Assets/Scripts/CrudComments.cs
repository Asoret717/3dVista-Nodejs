using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

public class CrudComments : MonoBehaviour
{

    public class ReviewModel
    {
        public int id { get; set; }
        public string content { get; set; }
        public string username { get; set; }
        public string target { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int? userId { get; set; }
    }

    public static string content;
    public static string testCommentsGet;
    public static List<ReviewModel> contentArray;
    public static string idUpdate;
    public static string idDelete;

    public static LoginUsers.OverUserModel contentUser = null;
    public static LoginUsers.OverUserModel getUser() { return contentUser; }
    public static void setUser(LoginUsers.OverUserModel user) { contentUser = user; }

    public static Boolean Dark = false;

    public GameObject itemParent, item, form_create, form_update, background, bkg_create, bkg_update, bkg_delete, txt_delete, txt_username;

    void Start()
    {
        txt_username.GetComponent<Text>().text = LoginUsers.getUsername();
        contentUser = LoginUsers.getUser();
        Dark = Crud.getDark();
        read();
    }
    public void read()
    {
        StartCoroutine(readI());
    }
    IEnumerator readI()
    {
        if (Dark)
        {
            background.GetComponent<Image>().color = new Color32(52, 52, 55, 255);
            bkg_create.GetComponent<Image>().color = new Color32(52, 52, 55, 255);
            bkg_update.GetComponent<Image>().color = new Color32(52, 52, 55, 255);
            bkg_delete.GetComponent<Image>().color = new Color32(52, 52, 55, 255);
            txt_delete.GetComponent<Text>().color = Color.white;

            for (int i = 0; i < itemParent.transform.childCount; i++)
            {
                Destroy(itemParent.transform.GetChild(i).gameObject);
            }
            yield return ReadCommentsI();
            contentArray = JsonConvert.DeserializeObject<List<ReviewModel>>(testCommentsGet);
            foreach (ReviewModel model in contentArray)
            {
                GameObject tmp_item = Instantiate(item, itemParent.transform);
                tmp_item.transform.GetChild(0).GetComponent<Text>().color = Color.white;
                tmp_item.transform.GetChild(0).GetComponent<Text>().text = model.id.ToString();
                tmp_item.transform.GetChild(1).GetComponent<Text>().color = Color.white;
                tmp_item.transform.GetChild(1).GetComponent<Text>().text = model.content;
                tmp_item.transform.GetChild(2).GetComponent<Text>().color = Color.white;
                tmp_item.transform.GetChild(2).GetComponent<Text>().text = model.username;
                tmp_item.transform.GetChild(3).GetComponent<Text>().color = Color.white;
                tmp_item.transform.GetChild(3).GetComponent<Text>().text = model.target;
            }
        }
        else
        {
            background.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            bkg_create.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            bkg_update.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            bkg_delete.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            txt_delete.GetComponent<Text>().color = Color.black;

            for (int i = 0; i < itemParent.transform.childCount; i++)
            {
                Destroy(itemParent.transform.GetChild(i).gameObject);
            }
            yield return ReadCommentsI();
            contentArray = JsonConvert.DeserializeObject<List<ReviewModel>>(testCommentsGet);
            foreach (ReviewModel model in contentArray)
            {
                GameObject tmp_item = Instantiate(item, itemParent.transform);
                tmp_item.transform.GetChild(0).GetComponent<Text>().color = Color.black;
                tmp_item.transform.GetChild(0).GetComponent<Text>().text = model.id.ToString();
                tmp_item.transform.GetChild(1).GetComponent<Text>().color = Color.black;
                tmp_item.transform.GetChild(1).GetComponent<Text>().text = model.content;
                tmp_item.transform.GetChild(2).GetComponent<Text>().color = Color.black;
                tmp_item.transform.GetChild(2).GetComponent<Text>().text = model.username;
                tmp_item.transform.GetChild(3).GetComponent<Text>().color = Color.black;
                tmp_item.transform.GetChild(3).GetComponent<Text>().text = model.target;
            }
        }
    }

    public static IEnumerator ReadCommentsI()
    {
        UnityWebRequest request = new UnityWebRequest("http://localhost:4000/api/reviews", "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();
        testCommentsGet = request.downloadHandler.text;
    }

    public void changeDarkness()
    {
        if (Dark)
        {
            contentUser.user.darkmode = false;
            StartCoroutine(changeDarknessI());
            Dark = false;
            Crud.setDark(Dark);
            LoginUsers.setDark(Dark);
            LoginUsers2.setDark(Dark);
            read();
        }
        else
        {
            contentUser.user.darkmode = true;
            StartCoroutine(changeDarknessI());
            Dark = true;
            Crud.setDark(Dark);
            LoginUsers.setDark(Dark);
            LoginUsers2.setDark(Dark);
            read();
        }
    }

    IEnumerator changeDarknessI()
    {
        var userUpdate = new LoginUsers.UserModel();
        userUpdate.id = contentUser.user.id;
        userUpdate.username = contentUser.user.username;
        userUpdate.password = contentUser.user.password;
        userUpdate.mail = contentUser.user.mail;
        userUpdate.isAdmin = contentUser.user.isAdmin;
        userUpdate.darkmode = contentUser.user.darkmode;
        var json = JsonConvert.SerializeObject(userUpdate);
        //var updateData = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        var byteArray = System.Text.Encoding.UTF8.GetBytes(json);
        UnityWebRequest request = UnityWebRequest.Put("http://localhost:4000/api/users/" + userUpdate.id, byteArray);
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + contentUser.access_token);
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();
        userUpdate = null;
    }

    public void create()
    {
        StartCoroutine(createI());
    }
    IEnumerator createI()
    {
        var review = new ReviewModel();
        review.content = form_create.transform.GetChild(1).GetComponent<InputField>().text;
        review.username = form_create.transform.GetChild(2).GetComponent<InputField>().text;
        review.target = form_create.transform.GetChild(3).GetComponent<InputField>().text;
        WWWForm form = new WWWForm();
        form.AddField("content", review.content);
        form.AddField("username", review.username);
        form.AddField("target", review.target);
        UnityWebRequest request = UnityWebRequest.Post("http://localhost:4000/api/reviews", form);
        request.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();
        /*var json = JsonConvert.SerializeObject(review);
        var data = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        using var client = new HttpClient();
        HttpResponseMessage response = await client.PostAsync("http://localhost:4000/api/reviews", data);
        var responseString = await response.Content.ReadAsStringAsync();*/
        //Debug.Log(responseString);
        form_create.transform.GetChild(1).GetComponent<InputField>().text = "";
        form_create.transform.GetChild(2).GetComponent<InputField>().text = "";
        form_create.transform.GetChild(3).GetComponent<InputField>().text = "";
        read();
    }

    public void get_id_delete(GameObject obj_delete)
    {
        idDelete = obj_delete.transform.GetChild(0).GetComponent<Text>().text;
    }
    public void delete()
    {
        StartCoroutine(deleteI());
    }
    IEnumerator deleteI()
    {
        /*using var client = new HttpClient();
        HttpResponseMessage response = await client.DeleteAsync("http://localhost:4000/api/reviews/" + idDelete);*/
        UnityWebRequest request = UnityWebRequest.Delete("http://localhost:4000/api/reviews/" + idDelete);
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();
        read();
    }

    string id_update;

    public void open_form_update(GameObject obj_update)
    {
        form_update.SetActive(true);
        form_update.transform.GetChild(1).GetComponent<InputField>().text = obj_update.transform.GetChild(1).GetComponent<Text>().text;
        form_update.transform.GetChild(2).GetComponent<InputField>().text = obj_update.transform.GetChild(2).GetComponent<Text>().text;
        form_update.transform.GetChild(3).GetComponent<InputField>().text = obj_update.transform.GetChild(3).GetComponent<Text>().text;
        idUpdate = obj_update.transform.GetChild(0).GetComponent<Text>().text;
    }
    public void update()
    {
        StartCoroutine(updateI());
    }
    IEnumerator updateI()
    {
        var reviewUpdate = new ReviewModel();
        reviewUpdate.id = int.Parse(idUpdate);
        reviewUpdate.content = form_update.transform.GetChild(1).GetComponent<InputField>().text;
        reviewUpdate.username = form_update.transform.GetChild(2).GetComponent<InputField>().text;
        reviewUpdate.target = form_update.transform.GetChild(3).GetComponent<InputField>().text;
        var json = JsonConvert.SerializeObject(reviewUpdate);
        //var updateData = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        var byteArray = System.Text.Encoding.UTF8.GetBytes(json);
        UnityWebRequest request = UnityWebRequest.Put("http://localhost:4000/api/reviews/" + idUpdate, byteArray);
        request.SetRequestHeader("Content-Type", "application/json");
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();
        /*using var client = new HttpClient();
        HttpResponseMessage response = await client.PutAsync("http://localhost:4000/api/reviews/" + idUpdate, updateData);*/
        read();
    }

    [DllImport("__Internal")]
    private static extern void OpenURLInExternalWindow(string url);

    public void report()
    {
        OpenURLInExternalWindow("http://localhost:5488/templates/ReviewsReport.pdf");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
