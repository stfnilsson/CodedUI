using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;

namespace CodedUItest
{
    public class MainViewModel : ViewModelBase
    {
        private bool _loaded;
        public bool Loaded
        {
            get { return _loaded; }
            set { Set(() => Loaded, ref _loaded, value); }
        }

        public ObservableCollection<Person> List { get; }
        public MainViewModel()
        {
            List = new ObservableCollection<Person>();
        }
        public async Task LoadAsync()
        {
            var persons = new List<Person>
            {
                new Person
                {
                    FirstName = "Jan",
                    LastName = "Banan"
                },
                new Person
                {
                    FirstName = "Test",
                    LastName = "Kalle"
                },
                new Person
                {
                    FirstName = "Jan",
                    LastName = "Banan"
                },
                new Person
                {
                    FirstName = "Test",
                    LastName = "Kalle"
                },
                new Person
                {
                    FirstName = "Jan",
                    LastName = "Banan"
                },
                new Person
                {
                    FirstName = "Test",
                    LastName = "Kalle"
                },
                new Person
                {
                    FirstName = "Jan",
                    LastName = "Banan"
                },
                new Person
                {
                    FirstName = "Test",
                    LastName = "Kalle"
                },
                new Person
                {
                    FirstName = "Jan",
                    LastName = "Banan"
                },
                new Person
                {
                    FirstName = "Test",
                    LastName = "Kalle"
                },
                new Person
                {
                    FirstName = "Jan",
                    LastName = "Banan"
                },
                new Person
                {
                    FirstName = "Joakim",
                    LastName = "Hello"
                },
                new Person
                {
                    FirstName = "Test",
                    LastName = "Kalle"
                },
                new Person
                {
                    FirstName = "Jan",
                    LastName = "Banan"
                },
                new Person
                {
                    FirstName = "Test",
                    LastName = "Kalle"
                },
                new Person
                {
                    FirstName = "Jan",
                    LastName = "Banan"
                },
                new Person
                {
                    FirstName = "Test",
                    LastName = "Kalle"
                },
                new Person
                {
                    FirstName = "Jan",
                    LastName = "Banan"
                },
                new Person
                {
                    FirstName = "Test",
                    LastName = "Kalle"
                },
                new Person
                {
                    FirstName = "Jan",
                    LastName = "Banan"
                },
                new Person
                {
                    FirstName = "Test",
                    LastName = "Kalle"
                },
                new Person
                {
                    FirstName = "Jan",
                    LastName = "Banan"
                },
                new Person
                {
                    FirstName = "Test",
                    LastName = "Kalle"
                },
                new Person
                {
                    FirstName = "Jan",
                    LastName = "Banan"
                },
                new Person
                {
                    FirstName = "Test",
                    LastName = "Kalle"
                },
                new Person
                {
                    FirstName = "Jan",
                    LastName = "Banan"
                },
                new Person
                {
                    FirstName = "Test",
                    LastName = "Kalle"
                },
                new Person
                {
                    FirstName = "Jan",
                    LastName = "Banan"
                },
                new Person
                {
                    FirstName = "Test",
                    LastName = "Kalle"
                },
                new Person
                {
                    FirstName = "Jan",
                    LastName = "Banan"
                },
                new Person
                {
                    FirstName = "Test",
                    LastName = "Kalle"
                },
                new Person
                {
                    FirstName = "Jan",
                    LastName = "Banan"
                },
                new Person
                {
                    FirstName = "Test",
                    LastName = "Kalle"
                },
                new Person
                {
                    FirstName = "Jan",
                    LastName = "Banan"
                },
                new Person
                {
                    FirstName = "Test",
                    LastName = "Kalle"
                },
                new Person
                {
                    FirstName = "Jan",
                    LastName = "Banan"
                },
                new Person
                {
                    FirstName = "Test",
                    LastName = "Kalle"
                }
            };
            // Task.Delay()
            Loaded = false;

            await Task.Delay(200).ConfigureAwait(false);

            DispatcherHelper.CheckBeginInvokeOnUI(() =>
            {
                foreach (var person in persons)
                {
                    List.Add(person);
                }

                Loaded = true;
            });

        }
    }
}