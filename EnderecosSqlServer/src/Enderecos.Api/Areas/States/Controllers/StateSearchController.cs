using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enderecos.Api.Controllers;
using Enderecos.Domain.States.QueryMessages;
using Enderecos.Domain.States.DTO.ToApi;
using Enderecos.Domain._Core.Search;

namespace Enderecos.Api.Areas.States.Controllers {

    [ApiController, Route("v1/states")]
    public class StateSearchController : ApiBaseController {

        // Dependencies
        private readonly ISearchHandler<StateFindAllMsgToApi, List<StateResponse>> searchState;
        /// <summary>
        /// 
        /// </summary>
        public StateSearchController(ISearchHandler<StateFindAllMsgToApi, List<StateResponse>> searchStateParam) : base() {

            searchState = searchStateParam;
        }

        /// <summary>
        /// Search for states
        /// </summary>
        /// <returns>States</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get([FromQuery] StateRequest data) {

            var msg = new StateFindAllMsgToApi(data);
            var response = await searchState.handleAsync(msg);

            if (!response.Any()) {
                return NoContent();
            }

            var responseApi = new List<StateResponse>(response);
            return Ok(responseApi);
        }

    }

}
