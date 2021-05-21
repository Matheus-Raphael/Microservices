using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Enderecos.Application.Addresses.Commands.Abstractions;
using Enderecos.Domain._Core.Command;
using Enderecos.Domain._Core.Response;
using Enderecos.Domain._Core.Search;
using Enderecos.Domain.Addresses.Commands;
using Enderecos.Domain.Addresses.DTO;
using Enderecos.Domain.Addresses.Entities;
using Enderecos.Domain.States.DTO;
using Enderecos.Domain.States.Entities;
using Enderecos.Domain.States.QueryMessages;

namespace Enderecos.Application.Addresses.Commands.Handlers {

    public class AddressCreatorHandler : ICommandHandler<AddressCreatorCommand, Response<Address>> {

        //Dependencies
        private readonly IAddressCreator creator;
        private readonly ISearchHandler<StateFindFromCacheMsg, List<State>> searchState;

        public AddressCreatorHandler(IAddressCreator _creator,
                                     ISearchHandler<StateFindFromCacheMsg, List<State>> searchStateParam) {

            creator = _creator;
            searchState = searchStateParam;
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<Response<Address>> handleAsync(AddressCreatorCommand model) {

            var response = new Response<Address>();

            var filter = new StateFilter();
            filter.setQuery(StateProjections.basicOne.Key);

            var msg = new StateFindFromCacheMsg(filter);
            var result = await searchState.handleAsync(msg);

            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled)) {

                try {
                    foreach (var item in model.request.listRequest) {

                        var idState = result.Where(x => x.initials == item.initialsState).Select(x => x.id).FirstOrDefault();

                        if (idState == 0) {
                            response.error = true;
                            return response;
                        }

                        var form = new AddressForm(item.name, idState);

                        var entity = await creator.create(form);

                        response.results.Add(entity);
                    }

                    transaction.Complete();
                }
                catch (System.Exception) {
                    response.error = true;
                } 
            }

            return response;
        }
    }
}