using Client.Abstraction;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Client.View
{
    public partial class TDonHangView : BaseView<DTO.TDonHangDto>
    {
        partial void InitUIPartial()
        {
            GridView.Columns[4].DisplayIndex = 1;
            GridView.Columns[1].DisplayIndex = 4;

            GridView.dataGrid.Columns[6].IsReadOnly = true;

            var btnPrintRemain = new Button()
            {
                Content = "In",
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                Width = 75,
                Margin = new System.Windows.Thickness(5)
            };
            btnPrintRemain.Click += BtnPrintRemain_Click;
            GridView.CustomMenuItems.Add(btnPrintRemain);

            var btnPrintAll = new Button()
            {
                Content = "In tất cả",
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                Width = 75,
                Margin = new System.Windows.Thickness(5)
            };
            btnPrintAll.Click += BtnPrintAll_Click;
            GridView.CustomMenuItems.Add(btnPrintAll);

            var btnTonKho = new Button()
            {
                Content = "Tồn kho",
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                Width = 75,
                Margin = new System.Windows.Thickness(5)
            };
            btnTonKho.Click += BtnTonKho_Click;
            GridView.CustomMenuItems.Add(btnTonKho);
        }

        private void BtnTonKho_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (GridView.dataGrid.SelectedItem == null)
                return;

            var donHang = GridView.dataGrid.SelectedItem as DTO.TDonHangDto; ;            
            var qe = new QueryBuilder.QueryExpression();
            qe.AddWhereOption<QueryBuilder.WhereExpression.WhereOptionInt, int>(
                QueryBuilder.WhereExpression.Equal, nameof(DTO.TChiTietDonHangDto.MaDonHang), donHang.ID);

            var tChiTietDonHangs = ServiceLocator.Instance.GetInstance<IDataService<DTO.TChiTietDonHangDto>>().Get(qe).Items;

            var maMatHangs = tChiTietDonHangs.Select(p => p.MaMatHang).ToList();

            qe = new QueryBuilder.QueryExpression();
            qe.AddWhereOption<QueryBuilder.WhereExpression.WhereOptionInt, int>(
                QueryBuilder.WhereExpression.Equal, nameof(DTO.TTonKhoDto.MaKhoHang), donHang.MaKhoHang);
            qe.AddWhereOption<QueryBuilder.WhereExpression.WhereOptionDate, System.DateTime>(
                QueryBuilder.WhereExpression.Equal, nameof(DTO.TTonKhoDto.Ngay), donHang.Ngay);
            qe.AddWhereOption<QueryBuilder.WhereExpression.WhereOptionIntList, List<int>>(
                QueryBuilder.WhereExpression.In, nameof(DTO.TTonKhoDto.MaMatHang), maMatHangs);
            
            var tTonKhoes = ServiceLocator.Instance.GetInstance<IDataService<DTO.TTonKhoDto>>().Get(qe).Items;

            var data = new List<CustomControl.MessageBox2.MessageBox2Data>();

            foreach (var tTonKho in tTonKhoes)
            {
                data.Add(new CustomControl.MessageBox2.MessageBox2Data
                {
                    Title = ReferenceDataManager<DTO.TMatHangDto>.Instance.GetList().Find(p => p.ID == tTonKho.MaMatHang).TenMatHangDayDu,
                    Content = tTonKho.SoLuong.ToString("N0")
                });
            }

            CustomControl.MessageBox2.Show("Ton Kho", data);
        }

        private void BtnPrintAll_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (GridView.dataGrid.SelectedItem == null)
                return;

            var donHang = GridView.dataGrid.SelectedItem as DTO.TDonHangDto; ;
            var dataService = ServiceLocator.Instance.GetInstance<IDataService<DTO.TChiTietDonHangDto>>();
            var qe = new QueryBuilder.QueryExpression();
            qe.WhereOptions.Add(new QueryBuilder.WhereExpression.WhereOptionInt()
            {
                Predicate = "=",
                PropertyPath = nameof(DTO.TChiTietDonHangDto.MaDonHang),
                Value = donHang.ID
            });
            var tChiTietDonHangs = dataService.Get(qe).Items;

            if (tChiTietDonHangs.Count == 0)
                return;

            var content = new List<string>();

            foreach (var ctdh in tChiTietDonHangs)
            {
                ctdh.TMatHang = ReferenceDataManager<DTO.TMatHangDto>.Instance.GetList().Find(p => p.ID == ctdh.MaMatHang);
                content.Add(string.Format("{0,3}  {1}", ctdh.SoLuong, ctdh.TMatHang.TenMatHangIn));
            }

            var tenKhachHang = ReferenceDataManager<DTO.RKhachHangDto>.Instance.GetList().Find(p => p.Ma == donHang.MaKhachHang).TenKhachHang;

            Print(tenKhachHang, content);
        }

        private void BtnPrintRemain_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (GridView.dataGrid.SelectedItem == null)
                return;

            var donHang = GridView.dataGrid.SelectedItem as DTO.TDonHangDto; ;

            var qe = new QueryBuilder.QueryExpression();
            qe.WhereOptions.Add(new QueryBuilder.WhereExpression.WhereOptionInt()
            {
                Predicate = "=",
                PropertyPath = nameof(DTO.TChiTietDonHangDto.MaDonHang),
                Value = donHang.ID
            });
            qe.WhereOptions.Add(new QueryBuilder.WhereExpression.WhereOptionBool()
            {
                Predicate = "=",
                PropertyPath = nameof(DTO.TChiTietDonHangDto.Xong),
                Value = false
            });
            var tChiTietDonHangs = ServiceLocator.Instance.GetInstance<IDataService<DTO.TChiTietDonHangDto>>().Get(qe).Items;

            if (tChiTietDonHangs.Count == 0)
                return;

            var content = new List<string>();

            var qe1 = new QueryBuilder.QueryExpression();
            qe1.WhereOptions.Add(new QueryBuilder.WhereExpression.WhereOptionInt()
            {
                Predicate = "=",
                PropertyPath = string.Format("MaChiTietDonHangNavigation.MaDonHang"),
                Value = donHang.ID
            });
            var tChiTietChuyenHangDonHangs = ServiceLocator.Instance.GetInstance<IDataService<DTO.TChiTietChuyenHangDonHangDto>>().Get(qe1).Items;
            foreach (var ctdh in tChiTietDonHangs)
            {
                var soLuong = tChiTietChuyenHangDonHangs.Where(p => p.MaChiTietDonHang == ctdh.ID).Sum(p => p.SoLuong);
                ctdh.TMatHang = ReferenceDataManager<DTO.TMatHangDto>.Instance.GetList().Find(p => p.ID == ctdh.MaMatHang);
                content.Add(string.Format("{0,3}  {1}", ctdh.SoLuong - soLuong, ctdh.TMatHang.TenMatHangIn));
            }

            var tenKhachHang = ReferenceDataManager<DTO.RKhachHangDto>.Instance.GetList().Find(p => p.Ma == donHang.MaKhachHang).TenKhachHang;

            Print(tenKhachHang, content);
        }

        private void Print(string title, List<string> content)
        {
            var document = new FlowDocument()
            {
                PagePadding = new System.Windows.Thickness(0),
                PageWidth = 181
            };

            var pTitle = new Paragraph()
            {
                TextAlignment = System.Windows.TextAlignment.Center,
                Margin = new System.Windows.Thickness(5),
                FontSize = 20
            };

            pTitle.Inlines.Add(title);

            document.Blocks.Add(pTitle);

            var pContent = new Paragraph()
            {
                Margin = new System.Windows.Thickness(0),
                FontSize = 18
            };

            foreach (var s in content)
            {
                pContent.Inlines.Add(s);
                pContent.Inlines.Add(new LineBreak());
            }

            document.Blocks.Add(pContent);

            var diag = new PrintDialog();

            diag.PrintDocument((document as IDocumentPaginatorSource).DocumentPaginator, "Caption");
        }
    }
}
