using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;
using static System.Net.WebRequestMethods;

namespace GuildManager
{
    [Serializable]
    public class ApiErrorResponse
    {
        public Dictionary<string, List<string>> Errors { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
    }

    public static class HttpRequests
    {
        private const string URI = "http://localhost:5181/api/";

        public static async Task<Returned> Get<Returned>(string url) where Returned : class
        {
            UnityWebRequest getRequest = CreateRequest(url, RequestType.GET);
            await getRequest.SendWebRequest();

            if (GetRequestResult(getRequest))
            {
                return JsonConvert.DeserializeObject<Returned>(getRequest.downloadHandler.text);
            }
            else
            {
                return null;
            }
        }

        public static async Task<Returned> Post<Returned>(string url, object data) where Returned : class
        {
            UnityWebRequest postRequest = CreateRequest(url, RequestType.POST, data);
            await postRequest.SendWebRequest();

            if (GetRequestResult(postRequest))
            {
                return JsonConvert.DeserializeObject<Returned>(postRequest.downloadHandler.text);
            }
            else
            {
                return null;
            }
        }

        public static async Task<Returned> Put<Returned>(string url, object data) where Returned : class
        {
            UnityWebRequest putRequest = CreateRequest(url, RequestType.PUT, data);
            await putRequest.SendWebRequest();

            if (GetRequestResult(putRequest))
            {
                return JsonConvert.DeserializeObject<Returned>(putRequest.downloadHandler.text);
            }
            else
            {
                return null;
            }
        }

        public static async Task<bool> Delete(string url)
        {
            UnityWebRequest deleteRequest = CreateRequest(url, RequestType.DELETE);
            await deleteRequest.SendWebRequest();

            return GetRequestResult(deleteRequest);
        }

        private static UnityWebRequest CreateRequest(string url, RequestType type, object data = null)
        {
            string method = GetRequestMethod(type);

            UnityWebRequest request = new UnityWebRequest(URI + url, method);

            if (data != null)
            {
                var rawData = Encoding.UTF8.GetBytes(JsonUtility.ToJson(data));
                request.uploadHandler = new UploadHandlerRaw(rawData);
            }

            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            return request;
        }

        private static string GetRequestMethod(RequestType type)
        {
            switch (type)
            {
                case RequestType.GET:
                    return "GET";
                case RequestType.POST:
                    return "POST";
                case RequestType.PUT:
                    return "PUT";
                case RequestType.DELETE:
                    return "DELETE";
            }

            return "";
        }

        private static bool GetRequestResult(UnityWebRequest request)
        {
            if(request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.responseCode);
                Debug.Log(request.error);
            }

            if(request.responseCode == 400)
            {
                ApiErrorResponse error = JsonConvert.DeserializeObject<ApiErrorResponse>(request.downloadHandler.text);

                foreach(KeyValuePair<string, List<string>> err in error.Errors)
                {
                    Debug.Log($"Error at {err.Key} : \"{err.Value[0]}\"");
                }
            }

            //CODE REVIEW : Switch pour renvoyer les différents types d'erreurs ?
            return request.result == UnityWebRequest.Result.Success;
        }
    }
}