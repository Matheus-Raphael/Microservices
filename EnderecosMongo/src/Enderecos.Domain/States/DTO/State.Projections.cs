using Enderecos.Domain.States.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Enderecos.Domain.States.DTO {

    public class StateProjections {

        //OPTIONS ENTITY
        public static KeyValuePair<byte, Expression<Func<State, State>>> basicOne = new KeyValuePair<byte, Expression<Func<State, State>>>(1, queryOne);

        #region PROJECTIONS

        private static Expression<Func<State, State>> queryOne {
            get {
                return x => new State {
                    id = x.id,
                    nameState = x.nameState,
                    initials = x.initials
                };
            }
        }

        #endregion

    }

}
