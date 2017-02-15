using Client.Abstraction;
using DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Client.ViewModel
{
    public partial class TTonKhoViewModel : BaseViewModel<TTonKhoDto>
    {
        partial void InitFilterPartial()
        {
            _NgayFilter.IsSorted = false;
        }

        public void CopyTonKhoToClipboard(bool? isHangNhaLam)
        {
            if (_NgayFilter.IsUsed == false || _MaKhoHangFilter.IsUsed == false)
            {
                return;
            }

            var qe = new QueryBuilder.QueryExpression();
            if (isHangNhaLam.HasValue)
            {
                qe.AddWhereOption<QueryBuilder.WhereExpression.WhereOptionBool, bool>(
                    QueryBuilder.WhereExpression.Equal,
                    string.Format("{0}Navigation.{1}", nameof(TMatHangDto.MaLoai), nameof(RLoaiHangDto.HangNhaLam))
                    , isHangNhaLam.Value);
            }
            var matHangs = ServiceLocator.Instance.GetInstance<IDataService<TMatHangDto>>().Get(qe).Items;

            qe = new QueryBuilder.QueryExpression();

            qe.AddWhereOption<QueryBuilder.WhereExpression.WhereOptionInt, int>(
              QueryBuilder.WhereExpression.Equal, nameof(TTonKhoDto.MaKhoHang), (int)_MaKhoHangFilter.FilterValue);
            qe.AddWhereOption<QueryBuilder.WhereExpression.WhereOptionDate, System.DateTime>(
            QueryBuilder.WhereExpression.Equal, nameof(TTonKhoDto.Ngay), (System.DateTime)_NgayFilter.FilterValue);
            qe.AddWhereOption<QueryBuilder.WhereExpression.WhereOptionIntList, List<int>>(
                QueryBuilder.WhereExpression.In, nameof(TTonKhoDto.MaMatHang), matHangs.Select(p => p.Ma).ToList());

            var tTonKhoes = ServiceLocator.Instance.GetInstance<IDataService<TTonKhoDto>>().Get(qe).Items;

            var builder = new StringBuilder();

            var matHangsDictionary = matHangs.ToDictionary(p => p.Ma, p => p);

            var sortedList = new SortedList<string, string>();

            var tongSoCoun = 0;
            var tongSoKg = 0;
            for (int i = 0; i < tTonKhoes.Count; i++)
            {
                var mh = matHangsDictionary[tTonKhoes[i].MaMatHang];
                var tenMH = mh.TenMatHangDayDu;
                var soKg = (tTonKhoes[i].SoLuong * mh.SoKy) / 10;
                var soCoun = tTonKhoes[i].SoLuong;
                var row = string.Format("{0}\t{1}\t{2}", tenMH, soCoun, soKg);
                tongSoCoun += soCoun;
                tongSoKg += soKg;
                sortedList.Add(tenMH, row);
            }

            foreach (var item in sortedList)
            {
                builder.AppendLine(item.Value);
            }

            builder.Insert(0, string.Format("{0:dd/MM/yyyy}\t{1:N0} cuộn\t{2:N0} kg{3}"
                , (System.DateTime)_NgayFilter.FilterValue, tongSoCoun, tongSoKg, System.Environment.NewLine));
            Clipboard.SetText(builder.ToString());
        }
    }
}
