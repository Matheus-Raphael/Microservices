using Enderecos.Domain.States.Entities;

namespace Enderecos.Domain.States.DTO.ToApi {

    public class StateResponse {

        public int id { get; set; }

        public string nameState { get; set; }

        public void fromEntity(State state) {

            id = state.id;
            nameState = state.nameState;
        }
    }

}
