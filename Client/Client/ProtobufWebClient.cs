using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;

namespace Client
{
    public sealed class ProtobufWebClient
    {
        private static readonly ProtobufWebClient _instance = new ProtobufWebClient();

        public static ProtobufWebClient Instance
        {
            get { return _instance; }
        }

        public string Token { get; set; }

        public T Post<T>(string controller, string action, NameValueCollection data)
        {
            var uri = GetUri(controller, action);

            return FromBytes<T>(Post(uri, data));
        }

        public T Post<T>(string controller, string action, string json)
        {
            var uri = GetUri(controller, action);

            return FromBytes<T>(Post(uri, json));
        }

        public T Get<T>(string controller, string action)
        {
            var uri = GetUri(controller, action);

            return Get<T>(uri);
        }

        public T Get<T>(string uri)
        {
            return FromBytes<T>(Get(uri));
        }

        public void Login(string user, string pass)
        {
            var json = string.Format("{{user:\"{0}\", password:\"{1}\"}}", user, pass);
            var uri = string.Format("{0}/user/token", Settings.Instance.UriRoot);

            var token = Post(uri, json);

            Token = System.Text.Encoding.ASCII.GetString(token, 1, token.Length - 2);
        }

        private byte[] Get(string uri)
        {
            var client = new WebClient();
            client.Headers["response"] = "protobuf";
            client.Headers["token"] = Token;

            var response = client.DownloadData(uri);

            return response;
        }

        private byte[] Post(string uri, string json)
        {
            var data = new NameValueCollection();
            data.Add("json", json);

            return Post(uri, data);
        }

        private byte[] Post(string uri, NameValueCollection data)
        {
            var client = new WebClient();
            client.Headers["response"] = "protobuf";
            client.Headers["token"] = Token;

            var response = client.UploadValues(uri, data);

            return response;
        }

        private T FromBytes<T>(byte[] data)
        {
            var ms = new MemoryStream(data);

            var r = ProtoBuf.Serializer.Deserialize<T>(ms);

            return r;
        }

        private string GetUri(string controller, string action)
        {
            var uri = string.Format("{0}/{1}/{2}",
                Settings.Instance.UriRoot, controller, action);

            return uri;
        }

        private class MyWebClient : WebClient
        {
            protected override WebRequest GetWebRequest(Uri address)
            {
                HttpWebRequest request = base.GetWebRequest(address) as HttpWebRequest;
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                return request;
            }
        }
    }
}
