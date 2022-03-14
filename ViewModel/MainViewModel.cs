using System.Collections.Generic;
using System.Linq;
using EFCoreDemo.Data;
using EFCoreDemo.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace EFCoreDemo.ViewModel
{
    public class MainViewModel : ObservableRecipient
    {
        private IEnumerable<Foo>? _foos;
        public IEnumerable<Foo>? Foos
        {
            get => _foos;
            set => SetProperty(ref _foos, value);
        }

        public MainViewModel(IDbContextFactory<MyDbContext> contextFactory)
        {
            using var context = contextFactory.CreateDbContext();
            Foos = context.Foos
                .Include(foo => foo.Bar)
                .ToList();
        }
    }
}
