﻿using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace _6Sem_Lab2
{
    [Serializable]
    class ObservableModelData : ObservableCollection<ModelData>
    {
        private bool _hasChanged;

        public ObservableModelData()
        {
            CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) => HasChanged = true;
        }
        public bool HasChanged {
            get => _hasChanged;
            set => _hasChanged = value;
        }

        public void Add_ModelData(ModelData modelData) => Add(modelData);

        public void Remove_At(int index) => RemoveAt(index);

        public void AddDefaults()
        {
            Add_ModelData(new ModelData(10, -2));
            Add_ModelData(new ModelData(3, 2));
            Add_ModelData(new ModelData(24, 3));
            Add_ModelData(new ModelData(24, 5));
            Add_ModelData(new ModelData(50, 0));
            Add_ModelData(new ModelData(100, 5));
            Add_ModelData(new ModelData(24, -6));
        }

        public ModelData Farthest(int index) => (from item in Items
                                                 orderby Math.Abs(item.Parameter - Items[index].Parameter) descending
                                                 select item).First();


        public override string ToString()
        {
            string result = "Total items: " + Count + "\n";
            result += "Parameters of Data:\n";
            foreach (var item in Items)
            {
                result += item.Parameter + "\n";
            }
            return result;
        }
    }
}
