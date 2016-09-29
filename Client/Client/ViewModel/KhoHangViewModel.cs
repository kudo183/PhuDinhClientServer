using SimpleDataGrid.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Client.ViewModel
{
    public class KhoHangViewModel : EditableGridViewModel<DTO.KhoHangDto>
    {
        private readonly List<DTO.KhoHangDto> _originalEntities = new List<DTO.KhoHangDto>();
        private readonly List<DTO.ChangedItem<DTO.KhoHangDto>> _changedItems =
            new List<DTO.ChangedItem<DTO.KhoHangDto>>();

        public KhoHangViewModel()
        {
            Entities = new ObservableCollection<DTO.KhoHangDto>();
            PagerViewModel = new PagerViewModel()
            {
                IsEnablePaging = true,
                CurrentPageIndex = 1,
                ItemCount = 0,
                PageCount = 1
            };
        }

        public void Load()
        {
            PagerViewModel.PropertyChanged -= PagerViewModel_PropertyChanged;

            Entities.Clear();
            _originalEntities.Clear();
            _changedItems.Clear();

            DTO.PagingResultDto<DTO.KhoHangDto> result;

            if (PagerViewModel.IsEnablePaging == true)
            {
                var qe = new QueryBuilder.QueryExpression();
                qe.PageIndex = PagerViewModel.CurrentPageIndex;

                qe.OrderOptions.Add(new QueryBuilder.OrderByExpression.OrderOption()
                {
                    IsAscending = true,
                    PropertyPath = "Ma"
                });

                result = ProtobufWebClient.Instance.Post<DTO.KhoHangDto>("khohang", "get", qe);
            }
            else
            {
                result = ProtobufWebClient.Instance.Get<DTO.KhoHangDto>("khohang", "getall");
            }

            foreach (var dto in result.Items)
            {
                Entities.Add(dto);
                _originalEntities.Add(dto);
            }

            PagerViewModel.ItemCount = Entities.Count;
            PagerViewModel.PageCount = result.PageCount;

            PagerViewModel.PropertyChanged += PagerViewModel_PropertyChanged;
        }

        public void Unload()
        {
            PagerViewModel.PropertyChanged -= PagerViewModel_PropertyChanged;
        }

        void PagerViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "CurrentPageIndex":
                    Console.WriteLine("CurrentPageIndex: " + PagerViewModel.CurrentPageIndex);
                    Load();
                    break;
                case "IsEnablePaging":
                    Console.WriteLine("IsEnablePaging: " + PagerViewModel.IsEnablePaging);
                    Load();
                    break;
            }
        }

        public void Save()
        {
            foreach (var entity in _originalEntities)
            {
                if (Entities.Any(p => p.Ma == entity.Ma) == false)
                {
                    _changedItems.Add(new DTO.ChangedItem<DTO.KhoHangDto>()
                    {
                        State = DTO.ChangeState.Delete,
                        Data = entity
                    });
                }
            }

            foreach (var entity in Entities)
            {
                if (entity.Ma == 0)
                {
                    _changedItems.Add(new DTO.ChangedItem<DTO.KhoHangDto>()
                    {
                        State = DTO.ChangeState.Add,
                        Data = entity
                    });
                }
                else if (entity.HasChange())
                {
                    _changedItems.Add(new DTO.ChangedItem<DTO.KhoHangDto>()
                    {
                        State = DTO.ChangeState.Update,
                        Data = entity
                    });
                }
            }

            var response = ProtobufWebClient.Instance.Save<DTO.KhoHangDto>("khohang", "save", _changedItems);

            Load();
        }
    }
}
