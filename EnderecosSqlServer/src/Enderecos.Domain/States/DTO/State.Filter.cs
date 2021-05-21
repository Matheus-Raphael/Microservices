namespace Enderecos.Domain.States.DTO {

    public class StateFilter {

        public int[] ids { get; set; }

        public string initials { get; set; }

        public byte queryNumber { get; private set; }

        public void setQuery(byte _query) {
            queryNumber = _query;
        }
    }

}
