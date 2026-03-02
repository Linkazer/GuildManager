using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace GuildManager
{
    [Serializable]
    public class ValidationProblemDetails
    {
        public string type;
        public string title;
        public int status;
        public Dictionary<string, string[]> errors;
    }

    public static class HttpRequests
    {
        public static async Task<Returned> Get<Returned>(string url) where Returned : class
        {
            UnityWebRequest getRequest = CreateRequest(url, RequestType.GET);
            await getRequest.SendWebRequest();

            if (GetRequestResult(getRequest))
            {
                return JsonUtility.FromJson<Returned>(getRequest.downloadHandler.text);
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
                return JsonUtility.FromJson<Returned>(postRequest.downloadHandler.text);
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
                return JsonUtility.FromJson<Returned>(putRequest.downloadHandler.text);
            }
            else
            {
                return null;
            }
        }

        public static async Task<bool> Delete<T>(string url) where T : class
        {
            UnityWebRequest deleteRequest = CreateRequest(url, RequestType.DELETE);
            await deleteRequest.SendWebRequest();

            return GetRequestResult(deleteRequest);
        }

        private static UnityWebRequest CreateRequest(string url, RequestType type, object data = null)
        {
            string method = GetRequestMethod(type);

            UnityWebRequest request = new UnityWebRequest(url, method);

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
            Debug.Log(request.responseCode);
            Debug.Log(request.error);

            if(request.responseCode == 400)
            {
                Debug.Log(request.downloadHandler.text);
            }

            //CODE REVIEW : Switch pour renvoyer les différents types d'erreurs ?
            return request.result == UnityWebRequest.Result.Success;
        }
    }
}