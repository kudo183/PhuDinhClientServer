using Client.Abstraction;
using DTO;
using QueryBuilder;
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
            Settings.Instance.UriRoot = "http://gaucon.net:5000";
            ProtobufWebClient.Instance.Token = "CfDJ8HgnTw785jZNmXvqKl3VWKEKSOcZaDX4ivr-A9SMmbD1SABQMO_1tODxmD1K6AThNhcfaIFTbb5Eo90j0_bqJqCkDVkqdHUaL5bb8rV_PLSSswlVc4eK5xGya9rIGWmMxJJYh3P1-6fJuvI15BSn41Q";
            StartupUri = new System.Uri("MainWindow.xaml", System.UriKind.Relative);

            Logger.Instance.LogLevel = Logger.LogLevelEnum.Debug;
#endif
            System.Threading.Thread.CurrentThread.CurrentUICulture =
            //new System.Globalization.CultureInfo("en-us");
            new System.Globalization.CultureInfo("vi-vn");
            ServiceLocator.Instance.Initialize(new Dictionary<Type, Type>()
            {
                { typeof(IDataService<>), typeof(ProtoBufDataService<>) },
                { typeof(IReportService), typeof(ProtoBufReportService) },
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

            InitReferenceDataManager();
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            Settings.Instance.SaveSettings();
        }

        private void InitReferenceDataManager()
        {
            ReferenceDataManager<RBaiXeDto>.Instance.SetOrderByOptions(new List<OrderByExpression.OrderOption>()
            {
                new OrderByExpression.OrderOption() {PropertyPath = nameof(RBaiXeDto.DiaDiemBaiXe), IsAscending = true }
            });
            ReferenceDataManager<RChanhDto>.Instance.SetOrderByOptions(new List<OrderByExpression.OrderOption>()
            {
                new OrderByExpression.OrderOption() {PropertyPath = nameof(RChanhDto.TenChanh), IsAscending = true }
            });
            ReferenceDataManager<RKhachHangDto>.Instance.SetOrderByOptions(new List<OrderByExpression.OrderOption>()
            {
                new OrderByExpression.OrderOption() {PropertyPath = nameof(RKhachHangDto.TenKhachHang), IsAscending = true }
            });
            ReferenceDataManager<RKhoHangDto>.Instance.SetOrderByOptions(new List<OrderByExpression.OrderOption>()
            {
                new OrderByExpression.OrderOption() {PropertyPath = nameof(RKhoHangDto.TenKho), IsAscending = true }
            });
            ReferenceDataManager<RLoaiChiPhiDto>.Instance.SetOrderByOptions(new List<OrderByExpression.OrderOption>()
            {
                new OrderByExpression.OrderOption() {PropertyPath = nameof(RLoaiChiPhiDto.TenLoaiChiPhi), IsAscending = true }
            });
            ReferenceDataManager<RNhaCungCapDto>.Instance.SetOrderByOptions(new List<OrderByExpression.OrderOption>()
            {
                new OrderByExpression.OrderOption() {PropertyPath = nameof(RNhaCungCapDto.TenNhaCungCap), IsAscending = true }
            });
            ReferenceDataManager<RNhanVienDto>.Instance.SetOrderByOptions(new List<OrderByExpression.OrderOption>()
            {
                new OrderByExpression.OrderOption() {PropertyPath = nameof(RNhanVienDto.TenNhanVien), IsAscending = true }
            });
            ReferenceDataManager<TMatHangDto>.Instance.SetOrderByOptions(new List<OrderByExpression.OrderOption>()
            {
                new OrderByExpression.OrderOption() {PropertyPath = nameof(TMatHangDto.TenMatHang), IsAscending = true }
            });
        }
    }
}
