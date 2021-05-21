using Enderecos.Domain.Addresses.Entities;
using Enderecos.Domain.States.Entities;
using Microsoft.EntityFrameworkCore;

namespace Enderecos.Data.Infra._Core.Context.Abstractions {

    public interface IContextAppBase {

        DbSet<State> state { get; }
        DbSet<Address> address { get; }

        DbSet<T> Set<T>() where T : class;

        void Dispose();
    }
}
