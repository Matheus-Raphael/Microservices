using Enderecos.Domain.States.Entities;

namespace Enderecos.Domain.States.DTO.ToApi {

    public class StateResponse {

        public string id { get; set; }

        public string nameState { get; set; }

        public string initials { get; set; }

        public void fromEntity(State state) {

            id = state.id;
            nameState = state.nameState;
            initials = state.initials;
        }
    }

}
