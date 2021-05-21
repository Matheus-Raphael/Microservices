namespace Enderecos.Domain.States.Entities {

    public class State : StateBase {

    }

    public class StateBase {

        public string id { get; set; }

        public string nameState { get; set; }

        public string initials { get; set; }
    }

}
