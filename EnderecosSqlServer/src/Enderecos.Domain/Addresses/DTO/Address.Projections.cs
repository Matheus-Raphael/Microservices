using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Enderecos.Domain.Addresses.Entities;

namespace Enderecos.Domain.Addresses.DTO {
    public class AddressProjections {

        //OPTIONS ENTITY
        public static KeyValuePair<byte, Expression<Func<Address, Address>>> basicOne = new(1, queryOne);

        //OPTIONS DTO
        public static KeyValuePair<byte, Expression<Func<Address, AddressDto>>> basicOneDto = new(2, queryOneDto);

        #region PROJECTIONS
        private static Expression<Func<Address, Address>> queryOne {
            get {
                return x => new Address {
                    id = x.id,
                    name = x.name,
                    idState = x.idState,
                };
            }
        }

        private static Expression<Func<Address, AddressDto>> queryOneDto {
            get {
                return x => new AddressDto {
                    id = x.id,
                    name = x.name,
                    idState = x.idState,
                };
            }
        }
        #endregion
    }
}