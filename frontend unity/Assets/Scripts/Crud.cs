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

public class Crud : MonoBehaviour
{

    public class ViewsModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int views { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

    public static string content;
    public static List<ViewsModel> contentArray;
    public static string idUpdate;
    public static string idDelete;

    public static LoginUsers.OverUserModel contentUser = null;
    public static LoginUsers.OverUserModel getUser(){ return contentUser; }
    public static void setUser(LoginUsers.OverUserModel user){ contentUser = user; }

    public static Boolean Dark = false;
    public static void setDark(Boolean valueDark) { Dark = valueDark; }
    public static bool getDark() { return Dark; }

    public GameObject itemParent, item, form_create, form_update, background, bkg_create, bkg_update, bkg_delete, txt_delete, txt_username;

    void Start()
    {
        
        txt_username.GetComponent<Text>().text = LoginUsers.getUsername();
        Dark = LoginUsers.getDark();
        contentUser = LoginUsers.getUser();
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
            UnityWebRequest request = new UnityWebRequest("http://localhost:4000/api/views", "GET");
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();
            contentArray = JsonConvert.DeserializeObject<List<ViewsModel>>(request.downloadHandler.text);
            foreach (ViewsModel model in contentArray)
            {
                GameObject tmp_item = Instantiate(item, itemParent.transform);
                tmp_item.transform.GetChild(0).GetComponent<Text>().color = Color.white;
                tmp_item.transform.GetChild(0).GetComponent<Text>().text = model.id.ToString();
                tmp_item.transform.GetChild(1).GetComponent<Text>().color = Color.white;
                tmp_item.transform.GetChild(1).GetComponent<Text>().text = model.name;
                tmp_item.transform.GetChild(2).GetComponent<Text>().color = Color.white;
                tmp_item.transform.GetChild(2).GetComponent<Text>().text = model.views.ToString();
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
            UnityWebRequest request = new UnityWebRequest("http://localhost:4000/api/views", "GET");
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();
            contentArray = JsonConvert.DeserializeObject<List<ViewsModel>>(request.downloadHandler.text);
            foreach (ViewsModel model in contentArray)
            {
                GameObject tmp_item = Instantiate(item, itemParent.transform);
                tmp_item.transform.GetChild(0).GetComponent<Text>().color = Color.black;
                tmp_item.transform.GetChild(0).GetComponent<Text>().text = model.id.ToString();
                tmp_item.transform.GetChild(1).GetComponent<Text>().color = Color.black;
                tmp_item.transform.GetChild(1).GetComponent<Text>().text = model.name;
                tmp_item.transform.GetChild(2).GetComponent<Text>().color = Color.black;
                tmp_item.transform.GetChild(2).GetComponent<Text>().text = model.views.ToString();
            }
        }
    }

    public void changeDarkness()
    {
        if (Dark)
        {
            contentUser.user.darkmode = false;
            StartCoroutine(changeDarknessI());
            Dark = false;
            LoginUsers.setDark(Dark);
            LoginUsers2.setDark(Dark);
            read();
        }
        else
        {
            contentUser.user.darkmode = true;
            StartCoroutine(changeDarknessI());
            Dark = true;
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
        var view = new ViewsModel();
        view.name = form_create.transform.GetChild(1).GetComponent<InputField>().text;
        view.views = int.Parse(form_create.transform.GetChild(2).GetComponent<InputField>().text);
        WWWForm form = new WWWForm();
        form.AddField("name", view.name);
        form.AddField("views", view.views);
        UnityWebRequest request = UnityWebRequest.Post("http://localhost:4000/api/views",form);
        request.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();
        form_create.transform.GetChild(1).GetComponent<InputField>().text = "";
        form_create.transform.GetChild(2).GetComponent<InputField>().text = "";
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
    IEnumerator deleteI(){
        UnityWebRequest request=UnityWebRequest.Delete("http://localhost:4000/api/views/" + idDelete);
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
        idUpdate = obj_update.transform.GetChild(0).GetComponent<Text>().text;
    }

    public void update()
    {
        StartCoroutine(updateI());
    }

    IEnumerator updateI(){
        var viewUpdate = new ViewsModel();
        viewUpdate.id = int.Parse(idUpdate);
        viewUpdate.name = form_update.transform.GetChild(1).GetComponent<InputField>().text;
        viewUpdate.views = int.Parse(form_update.transform.GetChild(2).GetComponent<InputField>().text);
        var json = JsonConvert.SerializeObject(viewUpdate);
        var byteArray = System.Text.Encoding.UTF8.GetBytes(json);
        UnityWebRequest request = UnityWebRequest.Put("http://localhost:4000/api/views/"+idUpdate,byteArray);
        request.SetRequestHeader("Content-Type", "application/json");
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();
        read();
    }
    
    // Update is called once per frame
    [DllImport("__Internal")]
     private static extern void OpenURLInExternalWindow(string url);
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            OpenURLInExternalWindow("http://localhost:5488/templates/ImagesReport.pdf");
        }

        if(Input.GetKeyDown(KeyCode.LeftShift)){
            OpenURLInExternalWindow("http://localhost:8080/Advanced%20Reality%20Help.html");
        }
    }
}
