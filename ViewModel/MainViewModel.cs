using System.Collections.Generic;
using System.Linq;
using EFCoreDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Toolkit.Mvvm.ComponentModel;

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

        public MainViewModel(IDbContextFactory<MyDbContext> contextFactory)
        {
            using var context = contextFactory.CreateDbContext();

            BarFoos = context.Foos
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
