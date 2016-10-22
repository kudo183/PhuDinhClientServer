using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;

namespace Client
{
    public static class TextManager
    {
        static readonly Dictionary<string, string> _dic = new Dictionary<string, string>();
        static readonly string DefaultLanguage = "en-us";

        static TextManager()
        {
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject()) == true)
            {
                InitDefaultLanguageData();
                return;
            }

            var language = Thread.CurrentThread.CurrentUICulture.Name.ToLower();
            if (language == DefaultLanguage)
            {
                InitDefaultLanguageData();
                return;
            }

            var fileName = language + ".txt";
            var di = new System.IO.DirectoryInfo("text");
            var fi = di.GetFiles(fileName);
            if (fi.Length == 1)
            {
                var sr = fi[0].OpenText();
                var line = sr.ReadLine();
                while (string.IsNullOrEmpty(line) == false)
                {
                    var texts = line.Split(new[] { "\t\t" }, System.StringSplitOptions.RemoveEmptyEntries);
                    _dic.Add(texts[0], texts[1]);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
        }

        public static string Button_Ok { get { return GetText(); } }
        public static string LoginWindow_CannotConnect { get { return GetText(); } }
        public static string LoginWindow_LoginFailed { get { return GetText(); } }
        public static string LoginWindow_Title { get { return GetText(); } }
        public static string LoginWindow_TxtPassword { get { return GetText(); } }
        public static string LoginWindow_TxtUser { get { return GetText(); } }

        public static string GetText([CallerMemberName] string textKey = null)
        {
            string text;
            if (_dic.TryGetValue(textKey, out text) == true)
            {
                return text;
            }
            return "[no text]";
        }

        private static void InitDefaultLanguageData()
        {
            _dic.Add("Button_Ok", "Ok");
            _dic.Add("LoginWindow_CannotConnect", "Unable to connect to the remote server.");
            _dic.Add("LoginWindow_LoginFailed", "Wrong Username or Password.");
            _dic.Add("LoginWindow_Title", "Login");
            _dic.Add("LoginWindow_TxtPassword", "Password:");
            _dic.Add("LoginWindow_TxtUser", "Username:");
        }
    }
}
