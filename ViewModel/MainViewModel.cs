using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using EFCoreDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace EFCoreDemo.ViewModel
{
    public class MainViewModel : ObservableRecipient
    {
        private IEnumerable<dynamic>? _barFoos;
        public IEnumerable<dynamic>? BarFoos
        {
            get => _barFoos;
            set => SetProperty(ref _barFoos, value);
        }

        public ICommand ToUpperCommand { get; set; }
        public ICommand ToLowerCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        
        private MyDbContext _context { get; }

        public MainViewModel(IDbContextFactory<MyDbContext> contextFactory)
        {
            _context = contextFactory.CreateDbContext();

            ToUpperCommand = new RelayCommand(() =>
            {
                foreach (var foo in _context.Foos)
                    foo.Name = foo.Name.ToUpper();
                foreach (var bar in _context.Bars)
                    bar.Name = bar.Name.ToUpper();

                RefreshFromView();
            });

            ToLowerCommand = new RelayCommand(() =>
            {
                foreach (var foo in _context.Foos)
                    foo.Name = foo.Name.ToLower();
                foreach (var bar in _context.Bars)
                    bar.Name = bar.Name.ToLower();

                RefreshFromView();
            });

            SaveCommand = new RelayCommand(() => _context.SaveChanges());

            RefreshCommand = new RelayCommand(RefreshFromDb);

            RefreshFromDb();
        }

        private void RefreshFromDb()
        {
            BarFoos = _context.Foos
                .SelectMany(foo => foo.Bars,
                    (foo, bar) =>
                        new
                        {
                            FooId = foo.Id,
                            FooName = foo.Name,
                            BarId = bar.Id,
                            BarName = bar.Name
                        })
                .ToList();
        }

        private void RefreshFromView()
        {
            var foos = _context.Foos
                .Include(foo => foo.Bars)
                .ToList();

            BarFoos = foos
                .SelectMany(foo => foo.Bars,
                    (foo, bar) =>
                        new
                        {
                            FooId = foo.Id,
                            FooName = foo.Name,
                            BarId = bar.Id,
                            BarName = bar.Name
                        })
                .ToList();
        }
    }
}
