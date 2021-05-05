using System;
using System.Threading.Tasks;

namespace Kursach
{
    public interface IUnitOfWork : IDisposable
    {
        IEventsRepository Events { get; set; }
        IGamesRepository Games { get; set; }

        void Save();
        Task SaveAsync();
    }
}
