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
            sources = excelHelper.ExcelToList<Medicine>().Where(x => x.ҩƷ���� != null && x.ҩƷ���� != "").ToList();
            Query();
        }
        public void Query()
        {
            var matches = sources;
            if (Search != null && Search != "")
            {
                matches = sources.Where(x => x.ҩƷ����.Contains(Search) || x.��λ��.Contains(Search) || x.ҩƷ����.Contains(Search)).ToList();
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
                var newMedichines = medichines.Where(x => x.ҩƷ���� != null && x.ҩƷ����.Length > 0).GroupBy(x => new { x.ҩƷ����, x.ҩƷ����, x.���, x.����, x.��λ, x.��װ��� }).Select(y => new Medicine
                {
                    ҩƷ���� = y.Key.ҩƷ����,
                    ҩƷ���� = y.Key.ҩƷ����,
                    ��� = y.Key.���,
                    ���� = y.Key.����,
                    ��λ = y.Key.��λ,
                    ��װ��� = y.Key.��װ���,
                    �������� = y.Sum(s => s.��������)
                }).ToList();
                var matchMedichines = excelHelper.ExcelToList<Medicine>(1).ToList();
                foreach (var medichine in newMedichines)
                {
                    var matched = matchMedichines.Find(x => x.ҩƷ���� == medichine.ҩƷ����);
                    if (matched != null)
                    {
                        medichine.��λ�� = matched.��λ��;
                    }
                }
                newMedichines = newMedichines.OrderBy(x => x.��λ��).ToList();
                newMedichines.Add(new Medicine { �������� = newMedichines.Sum(x => x.��������) });
                sources = newMedichines;
                excelHelper.ImportToExcel(newMedichines, DateTime.Now.ToString("yyyy-MM-dd"));
                GridModelList = new ObservableCollection<Medicine>();
                MedicineDbContext medicineDbContext = new MedicineDbContext();
                if (newMedichines != null)
                {
                    var existMedicines = medicineDbContext.MedicineInfo.ToList();
                    newMedichines.ForEach(x =>
                    {
                        if (x.���� == null || x.���� == "")
                        {
                            var dbMedichine = medicineDbContext.MedicineInfo.Where(y => y.Code == x.ҩƷ����).FirstOrDefault();
                            if (dbMedichine != null)
                            {
                                x.���� = dbMedichine.Factory;
                            }
                        }
                        var existMedicine = existMedicines.FirstOrDefault(y => y.Name == x.ҩƷ����);
                        GridModelList.Add(x);
                        if (existMedicine == null)
                        {
                            medicineDbContext.MedicineInfo.Add(new MedicineInfo
                            {
                                Code = x.ҩƷ����,
                                Name = x.ҩƷ����,
                                ShelfNum = x.��λ��,
                                Spec = x.���,
                                Inventory = x.��������,
                                Unit = x.��λ,
                                PackageSpec = x.��װ���,
                                Factory = x.����
                            });
                        }
                        else
                        {
                            existMedicine.Inventory = x.��������;
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
                var exists = GridModelList.FirstOrDefault(x => x.ҩƷ���� == model.ҩƷ����);
                if (exists != null)
                {
                    model.��ע = exists.��ע;
                }
            }
            GridModelList = new ObservableCollection<Medicine>();
            foreach (var model in matchMedichines)
            {
                if (model.���� == null || model.����.Length == 0)
                {
                    var matchMedichine = factoryMedichines.FirstOrDefault(x => x.ҩƷ���� == model.ҩƷ����);
                    if (matchMedichine != null)
                    {
                        model.���� = matchMedichine.����;
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