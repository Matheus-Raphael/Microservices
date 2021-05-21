using System.Threading.Tasks;
using Enderecos.Domain.Addresses.DTO;
using Enderecos.Domain.Addresses.Entities;

namespace Enderecos.Application.Addresses.Commands.Abstractions {

    public interface IAddressCreator {

        /// <summary>
        /// 
        /// </summary>
        Task<Address> create(AddressForm form);
    }
}