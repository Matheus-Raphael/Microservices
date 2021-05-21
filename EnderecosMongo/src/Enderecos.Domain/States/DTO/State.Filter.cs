namespace Enderecos.Domain.States.DTO {

    public class StateFilter {

        public string[] ids { get; set; }

        public byte queryNumber { get; private set; }

        public void setQuery(byte _query) {
            queryNumber = _query;
        }
    }

}
