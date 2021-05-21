using System.Threading.Tasks;
using Enderecos.Api.Controllers;
using Enderecos.Domain._Core.Command;
using Enderecos.Domain._Core.Response;
using Enderecos.Domain.Addresses.Commands;
using Enderecos.Domain.Addresses.DTO.ToApi;
using Enderecos.Domain.Addresses.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enderecos.Api.Areas.Addresses.Controllers {

    /// <summary>
    /// Creator of address
    /// </summary>
    [ApiController, Route("v1/address")]
    public class AddressCreatorController : ApiBaseController {

        //Dependencies
        private readonly ICommandHandler<AddressCreatorCommand, Response<Address>> creatorAddress;

        /// <summary>
        /// Construtor
        /// </summary>
        public AddressCreatorController(ICommandHandler<AddressCreatorCommand, Response<Address>> creatorAddressParam) : base() {

            creatorAddress = creatorAddressParam;
        }

        /// <summary>
        /// Validate data and create a new Address
        /// </summary>
        /// <returns>Address Details</returns>
        /// <response code="200">Route Origin created successfully</response>
        /// <response code="400">Bad request. Info provided can not be consistent</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] AddressRequest request) {

            if (request == null) {
                return BadRequest("Invalid payload");
            }

            var command = new AddressCreatorCommand(request);
            var response = await creatorAddress.handleAsync(command);

            if (response.error) {
                return BadRequest("Registration error");
            }

            var responseApi = response.results;

            return Ok(responseApi);
        }
    }
}
