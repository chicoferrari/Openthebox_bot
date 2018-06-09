using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace SimpleEchoBot.Notifications
{
    public static class Notification
    {
        public static void SendNotification()
        {
            try
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    open = true
                });

                var request = WebRequest.CreateHttp("https://test-3a127.firebaseio.com/box/.json");
                request.Method = "POST";
                request.ContentType = "application/json";
                var buffer = Encoding.UTF8.GetBytes(json);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                var response = request.GetResponse();
                json = (new StreamReader(response.GetResponseStream())).ReadToEnd();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }
    }
}

