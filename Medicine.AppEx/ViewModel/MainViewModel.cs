using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NPOI.SS.Formula.Atp;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Documents;

namespace Medicine.AppEx.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string search;
        private ExcelHelper excelHelper = new ExcelHelper();
        private List<Medicine> sources;
        private ObservableCollection<Medicine> gridModelList = new ObservableCollection<Medicine>();

        public MainViewModel()
        {
            ReadExcelCommand = new RelayCommand<string>(s => ReadExcel(s));
            QueryCommand = new RelayCommand(Query);
            MatchCommand = new RelayCommand(MatchLocation);
            MatchFactoryCommand = new RelayCommand(MatchFactory);
        }
        public ObservableCollection<Medicine> GridModelList
        {
            get => gridModelList;
            set
            {
                gridModelList = value;
                RaisePropertyChanged("");
            }
        }

        public string Search
        {
            get => search;
            set
            {
                search = value;
                RaisePropertyChanged(null);
            }
        }
        public void ReadExcel(string filePath)
        {
            excelHelper.OpenExcel(filePath);
            sources = excelHelper.ExcelToList<Medicine>().Where(x => x.药品名称 != null && x.药品名称 != "").ToList();
            Query();
        }
        public void Query()
        {
            var matches = sources;
            if (Search != null && Search != "")
            {
                matches = sources.Where(x => x.药品编码.Contains(Search) || x.货位号.Contains(Search) || x.药品名称.Contains(Search)).ToList();
            }
            GridModelList = new ObservableCollection<Medicine>();
            if (matches != null)
            {
                matches.ForEach(x => GridModelList.Add(x));
            }
        }
        public void MatchLocation()
        {
            try
            {
                ISheet sheet = excelHelper.GetSheet(DateTime.Now.ToString("yyyy-MM-dd"));
                if (sheet != null)
                {
                    excelHelper.RemoveSheet(sheet);
                }
                List<Medicine> medichines = excelHelper.ExcelToList<Medicine>().ToList();
                var newMedichines = medichines.Where(x => x.药品名称 != null && x.药品名称.Length > 0).GroupBy(x => new { x.药品名称, x.药品编码, x.规格, x.厂家, x.单位, x.包装规格 }).Select(y => new Medicine
                {
                    药品编码 = y.Key.药品编码,
                    药品名称 = y.Key.药品名称,
                    规格 = y.Key.规格,
                    厂家 = y.Key.厂家,
                    单位 = y.Key.单位,
                    包装规格 = y.Key.包装规格,
                    基本数量 = y.Sum(s => s.基本数量)
                }).ToList();
                var matchMedichines = excelHelper.ExcelToList<Medicine>(1).ToList();
                foreach (var medichine in newMedichines)
                {
                    var matched = matchMedichines.Find(x => x.药品名称 == medichine.药品名称);
                    if (matched != null)
                    {
                        medichine.货位号 = matched.货位号;
                    }
                }
                newMedichines = newMedichines.OrderBy(x => x.货位号).ToList();
                newMedichines.Add(new Medicine { 基本数量 = newMedichines.Sum(x => x.基本数量) });
                sources = newMedichines;
                excelHelper.ImportToExcel(newMedichines, DateTime.Now.ToString("yyyy-MM-dd"));
                GridModelList = new ObservableCollection<Medicine>();
                MedicineDbContext medicineDbContext = new MedicineDbContext();
                if (newMedichines != null)
                {
                    var existMedicines = medicineDbContext.MedicineInfo.ToList();
                    newMedichines.ForEach(x =>
                    {
                        if (x.厂家 == null || x.厂家 == "")
                        {
                            var dbMedichine = medicineDbContext.MedicineInfo.Where(y => y.Code == x.药品编码).FirstOrDefault();
                            if (dbMedichine != null)
                            {
                                x.厂家 = dbMedichine.Factory;
                            }
                        }
                        var existMedicine = existMedicines.FirstOrDefault(y => y.Name == x.药品名称);
                        GridModelList.Add(x);
                        if (existMedicine == null)
                        {
                            medicineDbContext.MedicineInfo.Add(new MedicineInfo
                            {
                                Code = x.药品编码,
                                Name = x.药品名称,
                                ShelfNum = x.货位号,
                                Spec = x.规格,
                                Inventory = x.基本数量,
                                Unit = x.单位,
                                PackageSpec = x.包装规格,
                                Factory = x.厂家
                            });
                        }
                        else
                        {
                            existMedicine.Inventory = x.基本数量;
                        }
                    });
                    medicineDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void MatchFactory()
        {
            ISheet sheet = excelHelper.GetSheet(DateTime.Now.ToString("yyyy-MM-dd"));
            if (sheet == null)
                return;
            var matchMedichines = excelHelper.ExcelToList<Medicine>(sheet).ToList();
            var factoryMedichines = excelHelper.ExcelToList<Medicine>(2).ToList();
            foreach(var model in matchMedichines){
                var exists = GridModelList.FirstOrDefault(x => x.药品编码 == model.药品编码);
                if (exists != null)
                {
                    model.备注 = exists.备注;
                }
            }
            GridModelList = new ObservableCollection<Medicine>();
            foreach (var model in matchMedichines)
            {
                if (model.厂家 == null || model.厂家.Length == 0)
                {
                    var matchMedichine = factoryMedichines.FirstOrDefault(x => x.药品编码 == model.药品编码);
                    if (matchMedichine != null)
                    {
                        model.厂家 = matchMedichine.厂家;
                    }
                }
                GridModelList.Add(model);
            }
            excelHelper.ImportToExcel(matchMedichines.ToList(), DateTime.Now.ToString("yyyy-MM-dd"));
            excelHelper.WorkBook.Close();
        }
        #region
        public RelayCommand<string> ReadExcelCommand
        {
            get; set;
        }
        public RelayCommand QueryCommand
        {
            get; set;
        }
        public RelayCommand MatchCommand
        {
            get; set;
        }
        public RelayCommand MatchFactoryCommand
        {
            get; set;
        }
        #endregion
    }
}