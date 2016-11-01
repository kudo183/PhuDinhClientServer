﻿using Client.Abstraction;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Startup += App_Startup;
            Exit += App_Exit;

            //DateTimePicker format is base on CurrentCulture not CurrentUICulture
            //System.Threading.Thread.CurrentThread.CurrentCulture =
            //System.Threading.Thread.CurrentThread.CurrentUICulture =
            //new System.Globalization.CultureInfo("vi-vn");
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            Settings.Instance.LoadSettings();

#if DEBUG
            System.Threading.Thread.CurrentThread.CurrentCulture =
            System.Threading.Thread.CurrentThread.CurrentUICulture =
            //new System.Globalization.CultureInfo("en-us");
            new System.Globalization.CultureInfo("vi-vn");

            Settings.Instance.UriRoot = "http://localhost:5000";
            ProtobufWebClient.Instance.Token = "CfDJ8P0zsQbbuUlBkhS-elYKeAcGLsOHUE2aXXYcY_ZYlRxDBvuqSenusoyRMKKXunn6953jTk4KeeiSkvgNJ5xRtaJ23J3fMSlP6rqvUo-aAwvBeSIjGyNbkNE1bv4RqMV9dm_Y3eec5SQZ-j-9ckRz-dI";
            //Settings.Instance.UriRoot = "http://luoithepvinhphat.com:5000";
            //ProtobufWebClient.Instance.Token = "CfDJ8H_g2vT3aWpLtytO4ZkizGgngqxMZZ2L4Kt_WsOUSUad1IB-r_h2C5BXqz3v7DpgaGi7REme7WIj5TJkNokTmEMKCMEXq823fkZTQXkWFvxJ2ZZoDiiCX4-XFhrqWpYpPb3Z6nYHPulWoEqxlcUsg-I";
            //StartupUri = new System.Uri("AllView.xaml", System.UriKind.Relative);
#endif

            ServiceLocator.Instance.Initialize(new Dictionary<Type, Type>()
            {
                { typeof(IDataService<>), typeof(ProtoBufDataService<>) },
                { typeof(IViewModelFactory), typeof(ViewModelFactory) }
            });

            //apply Window Style in App.xaml to all Window type
            FrameworkElement.StyleProperty.OverrideMetadata(typeof(Window), new FrameworkPropertyMetadata
            {
                DefaultValue = FindResource(typeof(Window))
            });

            //apply language to all FrameworkElement
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata()
            {
                DefaultValue = System.Windows.Markup.XmlLanguage.GetLanguage(System.Threading.Thread.CurrentThread.CurrentUICulture.Name)
            });
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            Settings.Instance.SaveSettings();
        }
    }
}
