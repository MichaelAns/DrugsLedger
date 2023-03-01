using DrugsLedger.Persistance.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace DrugsLedger.Desktop.ViewModels.Base
{
    internal abstract class TableViewModel<TModel> : ViewModel
        where TModel : BaseEntity, new()
    {
        public TableViewModel()
        {
            _drugsLedgerDbContextFactory = new();
            _updatedItemsIds = new List<int>();
            DeleteSelectedItem = new RelayCommand(DeleteItem, (obj) => true);
            AddNewRecord = new RelayCommand(AddRecord, (obj) => true);
            CommitChanges = new RelayCommand(Commit, (obj) => true);
        }

        protected readonly DrugsLedgerDbContextFactory _drugsLedgerDbContextFactory;
        private ObservableCollection<TModel> _items;
        private TModel _selectedItem;
        protected List<int> _updatedItemsIds;

        public TModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                if (_selectedItem != null)
                {
                    _updatedItemsIds.Add(_selectedItem.Id);
                }
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ObservableCollection<TModel> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }


        #region Операции с данными

        #region Команды
        public Command AddNewRecord { get; }
        public Command DeleteSelectedItem { get; }
        public Command CommitChanges { get; set; }

        #endregion

        #region Методы

        private void Commit(object obj)
        {
            try
            {
                List<TModel> dbData;
                var itemsIds = Items.Select(x => x.Id);

                // deleting removed items
                using (var dbContext = _drugsLedgerDbContextFactory.CreateDbContext())
                {
                    dbContext.Set<TModel>().RemoveRange(dbContext.Set<TModel>().Where(x => !itemsIds.Contains(x.Id)));
                    dbData = dbContext.Set<TModel>().ToList();
                    dbContext.SaveChanges();
                }

                // add and update items
                using (var dbContext = _drugsLedgerDbContextFactory.CreateDbContext())
                {
                    foreach (var item in Items)
                    {
                        // add item if it is not exists in DB
                        if (!dbData.Any(x => x.Id == item.Id))
                        {
                            //item.Id = 0;
                            dbContext.Set<TModel>().Add(item);
                        }
                    }

                    // update selected items
                    dbContext.UpdateRange(Items.Where(x => _updatedItemsIds.Contains(x.Id)));
                    _updatedItemsIds.Clear();

                    dbContext.SaveChanges();

                    }
                MessageBox.Show("Successfully!");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void AddRecord(object obj)
        {
            if (Items.Count != 0)
            {
                Items.Add(new TModel() { Id = MaxId() + 1 });
            }
            else
            {
                Items.Add(new TModel() { Id = 1 });
            }
        }

        private int MaxId()
        {
            int max = Items[0].Id;
            foreach (var item in Items)
            {
                if (item.Id > max)
                {
                    max = item.Id;
                }
            }
            return max;
        }

        private void DeleteItem(object obj)
        {
            if (Items.Count != 0 && SelectedItem != null)
            {
                var previousItemIndex = Items.IndexOf(SelectedItem) - 1;
                if (previousItemIndex >= 0 && previousItemIndex < Items.Count)
                {
                    var beforeSelectedItem = Items[previousItemIndex];
                    Items.Remove(SelectedItem);
                    SelectedItem = beforeSelectedItem;
                }
                else
                {
                    Items.Remove(SelectedItem);
                }
            }
        }
        #endregion

        #endregion
    }
}
